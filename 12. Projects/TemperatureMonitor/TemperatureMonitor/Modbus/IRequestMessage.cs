namespace TemperatureMonitor.Modbus
{
    public interface IRequestMessage
    {
        public byte[] Message { get; }
    }
}
