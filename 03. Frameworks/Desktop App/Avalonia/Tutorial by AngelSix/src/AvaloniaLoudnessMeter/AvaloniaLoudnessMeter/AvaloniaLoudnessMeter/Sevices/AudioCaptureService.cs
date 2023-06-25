
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ManagedBass;
using Microsoft.VisualBasic.CompilerServices;

namespace AvaloniaLoudnessMeter.Sevices;

public delegate void DataAvailableHandler(byte[] buffer, int length);

public class AudioCaptureService :IDisposable
{
    private int _device,_handle;

    private byte[] _buffer;

    private bool Procedure(int handle, IntPtr buffer, int length, IntPtr user)
    {
        if (_buffer == null || _buffer.Length < length)
        {
            _buffer = new byte[length];
        }

        Marshal.Copy(buffer, _buffer, 0, length);
        DataAvailable?.Invoke(_buffer, length);
        
        return true;
    }
    public AudioCaptureService(int deviceId)
    {
        _device = deviceId;

        Bass.Init();
        Bass.RecordInit(_device);

        _handle = Bass.RecordStart(44100, 2, BassFlags.RecordPause, Procedure);
    }

    public event DataAvailableHandler DataAvailable;

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