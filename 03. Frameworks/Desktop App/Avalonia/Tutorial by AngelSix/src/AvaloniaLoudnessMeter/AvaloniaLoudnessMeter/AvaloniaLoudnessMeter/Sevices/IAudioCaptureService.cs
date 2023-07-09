using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaLoudnessMeter.DataModels;

namespace AvaloniaLoudnessMeter.Sevices;

public interface IAudioCaptureService
{
    Task<List<ChannelConfigurationItem>> GetChannelConfigurationsAsync();

    void InitCapture(int deviceId = 1, int frequency = 44100);
    void Start();
    void Stop();

    event Action<AudioChunkData> AudioChunkAvailable;
}