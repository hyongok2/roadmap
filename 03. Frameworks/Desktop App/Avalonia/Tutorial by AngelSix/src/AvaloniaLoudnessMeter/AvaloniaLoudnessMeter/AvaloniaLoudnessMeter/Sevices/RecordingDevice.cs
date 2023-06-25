using System;
using System.Collections.Generic;
using ManagedBass;

namespace AvaloniaLoudnessMeter.Sevices;

public class RecordingDevice : IDisposable
{
    public string Name { get; }
    public int Index { get; }

    public RecordingDevice(int index, string name)
    {
        Name = name;
        Index = index;
    }

    public static IEnumerable<RecordingDevice> Enumarate()
    {
        for (var i = 0; Bass.RecordGetDeviceInfo(i, out var info); ++i)
        {
            yield return new RecordingDevice(i, info.Name);
        }
            
    }

    public void Dispose()
    {
        Bass.CurrentRecordingDevice = Index;
        Bass.RecordFree();
    }

    public override string ToString() => Name;
}