namespace AvaloniaLoudnessMeter.DataModels;

public class ChannelConfigurationItem
{
    public string? Group { get; set; }
    public string? Text { get; set; }
    public string? ShortText { get; set; }

    public ChannelConfigurationItem(string group, string text, string shortText)
    {
        Group = group;
        Text = text;
        ShortText = shortText;
    }
}

