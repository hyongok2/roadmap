
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Avalonia.Threading;
using AvaloniaLoudnessMeter.DataModels;
using ManagedBass;
using Microsoft.VisualBasic.CompilerServices;
using NWaves.Signals;
using NWaves.Utils;

namespace AvaloniaLoudnessMeter.Sevices;

public class BassAudioCaptureService :IDisposable, IAudioCaptureService
{
    private int _device,_handle;

    private byte[] _buffer;

    private Queue<double> _Lufs = new Queue<double>();
    private Queue<double> _LufsLonger = new Queue<double>();
    private int mSilenceCount = 0;

    private int _capturedFrequency = 44100;
    
    private bool AudioChuckCaptured(int handle, IntPtr buffer, int length, IntPtr user)
    {
        if (_buffer == null || _buffer.Length < length)
        {
            _buffer = new byte[length];
        }

        Marshal.Copy(buffer, _buffer, 0, length);
        CalculateValues(_buffer);
        
        return true;
    }
    
    private void CalculateValues(byte[] buffer)
    {
        //Get total PCM16 samples in this buffers
        var sampleCount = buffer.Length / 2;
        var signal = new DiscreteSignal(_capturedFrequency, sampleCount);

        using var reader = new BinaryReader(new MemoryStream(buffer));

        for (int i = 0; i < sampleCount; i++)
        {
            signal[i] = reader.ReadInt16() / 32768f;
        }
            
        var lufs = Scale.ToDecibel(signal.Rms() * 1.2);
        _Lufs.Enqueue(lufs);

        if(_Lufs.Count > 10) _Lufs.Dequeue();
            
        var averageLufs = Math.Max(-60, _Lufs.Count > 0 ? _Lufs.Average() : -60);
        var averageLongLufs = Math.Max(-60, _LufsLonger.Count > 0 ? _LufsLonger.Average() : -60);
        
        if (_LufsLonger.Count > 0 && averageLufs + 5 < averageLongLufs)
        {
            // Count how long a silence has gone
            mSilenceCount++;
            
            // If its been lower now for 1000 or more counts...
            if (mSilenceCount > 50)
            {
                // Start dequeuing 
                if (_LufsLonger.Count > 0)
                {
                    // Add silence in front while removing noise from behind
                    // If we dont add silence and only remove, there average
                    // will increase not decrease
                    _LufsLonger.Enqueue(-60);
                    _LufsLonger.Dequeue();
                    _LufsLonger.Dequeue();
                }
            }
        }
        // Otherwise, normal sounds to add to overall longer average...
        else
        {
            // Reset silence count
            mSilenceCount = 0;
            
            // If we are not silent...
            if (averageLufs > -60)
                // Add current audio to average
                _LufsLonger.Enqueue(averageLufs);
            // Otherwise, start dequeuing the average while it is silent
            else if (_LufsLonger.Count > 0)
                _LufsLonger.Dequeue();
            
            // Max average
            if (_LufsLonger.Count > 60)
                _LufsLonger.Dequeue();
        }

        // Re-calculate long average
        averageLongLufs = Math.Max(-60, _LufsLonger.Count > 0 ? _LufsLonger.Average() : -60);
        
        AudioChunkAvailable?.Invoke(new AudioChunkData
        (
            // TODO: Make these calculations correct
            ShortTermLUFS: averageLongLufs,
            Loudness: averageLufs,
            LoudnessRange: averageLufs + (averageLufs * 0.9),
            RealtimeDynamics:  averageLufs + (averageLufs * 0.8),
            AverageRealtimeDynamics:  averageLufs + (averageLufs * 0.7),
            TruePeakMax:  averageLufs + (averageLufs * 0.6),
            IntegratedLUFS: averageLufs + (averageLufs * 0.5),
            MomentaryMaxLUFS:  averageLufs + (averageLufs * 0.4),
            ShortTermMaxLUFS:  averageLufs + (averageLufs * 0.3)
        ));
    }

    
    public Task<List<ChannelConfigurationItem>> GetChannelConfigurationsAsync()
    {
        return Task.FromResult(new List<ChannelConfigurationItem>(new[]
        {
            new ChannelConfigurationItem("Mono Stereo Configuration", "Mono", "Mono"),
            new ChannelConfigurationItem("Mono Stereo Configuration", "Stereo", "Stereo"),
            new ChannelConfigurationItem("5.1 Surround", "5.1 DTS - (L, R, Ls, Rs, C, LFE)", "5.1 DTS"),
            new ChannelConfigurationItem("5.1 Surround", "5.1 DTS - (L, R, C, LFE, Ls, Rs)", "5.1 ITU"),
            new ChannelConfigurationItem("5.1 Surround", "5.1 DTS - (L, C, R, Ls, Rs, LFE)", "5.1 FILM"),
        }));
    }
    public BassAudioCaptureService()
    {

        Bass.Init();

        // foreach(var device in RecordingDevice.Enumarate())
        //     Console.WriteLine($"{device.Index}: {device.Name}");

        // using var _captureDevice = new AudioCaptureService(1);

        // 사운드 파일을 저장하기 위한 방법, 여기에서는 일단 주석처리하지만, 나중에 참고할 수 있다.
        // var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MBass");
        // Directory.CreateDirectory(outputPath);
        // var filePath = Path.Combine(outputPath, DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".wav");
        // using var _writer = new WaveFileWriter(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read),new WaveFormat());

        // _captureDevice.DataAvailable += (buffer, length) =>
        // {
        //     //_writer.Write(buffer, length);
        //
        //     CalculateValues(buffer);
        // };
    }

    public void InitCapture(int deviceId = 1, int frequency = 44100)
    {
        _device = deviceId;
        try
        {
            Bass.RecordFree();
        }
        catch{}

        Bass.RecordInit(_device);

        _handle = Bass.RecordStart(frequency, 2, BassFlags.RecordPause, Period: 20, AudioChuckCaptured);
    }


    public event Action<AudioChunkData> AudioChunkAvailable;
    
    public void Start()
    {
        Bass.ChannelPlay(_handle);
    }

    public void Stop()
    {
        Bass.ChannelStop(_handle);
    }
    
    public void Dispose()
    {
        Bass.CurrentDevice = _device;
        Bass.RecordFree();
    }
    

    public void CaptureDefualtInput()
    {
        

    }


}