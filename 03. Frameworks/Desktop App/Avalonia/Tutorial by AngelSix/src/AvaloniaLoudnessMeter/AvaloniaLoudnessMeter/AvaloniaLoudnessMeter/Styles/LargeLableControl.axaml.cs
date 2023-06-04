using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace AvaloniaLoudnessMeter;

public class LargeLableControl : TemplatedControl
{
    public static readonly StyledProperty<string> LargeTextProperty = AvaloniaProperty.Register<LargeLableControl, string>(
        nameof(LargeText),"LARGE TEXT");

    public string LargeText
    {
        get => GetValue(LargeTextProperty);
        set => SetValue(LargeTextProperty, value);
    }

    public static readonly StyledProperty<string> SmallTextProperty = AvaloniaProperty.Register<LargeLableControl, string>(
    nameof(SmallText), "SMALL TEXT");

    public string SmallText
    {
        get => GetValue(SmallTextProperty);
        set => SetValue(SmallTextProperty, value);
    }
}