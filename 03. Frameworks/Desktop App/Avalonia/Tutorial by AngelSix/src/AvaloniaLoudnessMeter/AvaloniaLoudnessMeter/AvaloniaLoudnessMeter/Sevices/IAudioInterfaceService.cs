using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaLoudnessMeter.DataModels;

namespace AvaloniaLoudnessMeter.Sevices;

public interface IAudioInterfaceService
{
    Task<List<ChannelConfigurationItem>> GetChannelConfigurationsAsync();
}