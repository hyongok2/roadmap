using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernFlatUI_FA.Controls;

public class VerticalProgressBar : ProgressBar
{
    public enum TextPosition
    {
        Top,
        Bottom,
        Middle,
        Sliding,
        None
    }
    private Color channelColor = Color.LightSteelBlue;
    private Color sliderColor = Color.RoyalBlue;
    private Color foreBackColor = Color.RoyalBlue;
    private int channelWidth = 6;
    private int sliderWidth = 6;
    private TextPosition showValue = TextPosition.Bottom;
    private string symbolBefore = "";
    private string symbolAfter = "";
    private bool showMaximum = false;

    private bool paintBack = false;
    private bool stopPainting = false;

    public VerticalProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        ForeColor = Color.White;
    }
    [Category("CustomStyle")]
    public Color ChannelColor
    {
        get => channelColor; set
        {
            channelColor = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public Color SliderColor
    {
        get => sliderColor; set
        {
            sliderColor = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public Color ForeBackColor
    {
        get => foreBackColor; set
        {
            foreBackColor = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public int ChannelWidth
    {
        get => channelWidth; set
        {
            channelWidth = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public int SliderWidth
    {
        get => sliderWidth; set
        {
            sliderWidth = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public TextPosition ShowValue
    {
        get => showValue; set
        {
            showValue = value;
            Invalidate();
        }
    }

    [Category("CustomStyle")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [AllowNull]
    public override Font Font
    {
        get
        {
            return base.Font;
        }

        set
        {
            base.Font = value;
        }
    }

    [Category("CustomStyle")]
    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }

        set
        {
            base.ForeColor = value;
        }
    }
    [Category("CustomStyle")]
    public string SymbolBefore
    {
        get => symbolBefore; set
        {
            symbolBefore = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public string SymbolAfter
    {
        get => symbolAfter; set
        {
            symbolAfter = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public bool ShowMaximum
    {
        get => showMaximum; set
        {
            showMaximum = value;
            Invalidate();
        }
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (stopPainting == false)
        {
            if (paintBack == false)
            {
                Graphics graphics = pevent.Graphics;
                Rectangle rectChannel = new Rectangle(0, 0, ChannelWidth, Height);

                using (var brushChannel = new SolidBrush(channelColor))
                {
                    if (channelWidth >= sliderWidth)
                    {
                        rectChannel.X = Width - channelWidth;
                    }
                    else
                    {
                        rectChannel.X = Width - ((channelWidth + sliderWidth) / 2);
                    }

                    graphics.Clear(Parent!.BackColor);
                    graphics.FillRectangle(brushChannel, rectChannel);

                    if (DesignMode == false)
                    {
                        //paintBack = true;
                    }
                }
            }

            if (Value == Maximum || Value == Minimum)
                paintBack = false;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (stopPainting == false)
        {
            Graphics graphics = e.Graphics;
            double scaleFactor = (((double)Value - Minimum) / ((double)Maximum - Minimum));
            int sliderHeight = (int)(Height * scaleFactor);
            Rectangle rectSlider = new Rectangle(0, 0, SliderWidth, sliderHeight);

            using (var brushSlider = new SolidBrush(sliderColor))
            {
                if (sliderWidth >= channelWidth)
                {
                    rectSlider.X = Width - sliderWidth;
                }
                else
                {
                    rectSlider.X = Width - ((sliderWidth + channelWidth) / 2);
                }
                rectSlider.Y = Height - sliderHeight;
                if (sliderHeight > 1)
                {
                    graphics.FillRectangle(brushSlider, rectSlider);
                }
                if (showValue != TextPosition.None)
                {
                    DrawValueText(graphics, sliderHeight, rectSlider);
                }
            }
        }

        //if (Value == Maximum) stopPainting = true;
        //else stopPainting = false;
    }

    private void DrawValueText(Graphics graphics, int sliderWidth, Rectangle rectSlider)
    {
        string text = symbolBefore + Value.ToString() + symbolAfter;
        if (showMaximum) text = text + "/" + symbolBefore + Maximum.ToString() + symbolAfter;
        var textSize = TextRenderer.MeasureText(text, Font);
        var rectText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);
        using (var brushText = new SolidBrush(ForeColor))
        using (var brushTextBack = new SolidBrush(foreBackColor))
        using (var textFormat = new StringFormat())
        {
            switch (showValue)
            {
                case TextPosition.Top:
                    rectText.Y = 0;
                    textFormat.Alignment = StringAlignment.Center;
                    break;
                case TextPosition.Bottom:
                    rectText.Y = Height - textSize.Height;
                    textFormat.Alignment = StringAlignment.Center;
                    break;
                case TextPosition.Middle:
                    rectText.Y = (Height - textSize.Height) / 2;
                    textFormat.Alignment = StringAlignment.Center;
                    break;
                case TextPosition.Sliding:
                    rectText.Y = Height - sliderWidth;
                    textFormat.Alignment = StringAlignment.Center;
                    using (var brushClear = new SolidBrush(Parent!.BackColor))
                    {
                        var rect = rectSlider;
                        rect.X = rectText.X;
                        rect.Width = rectText.Width;
                        graphics.FillRectangle(brushClear, rect);
                    }
                    break;
            }
            graphics.FillRectangle(brushTextBack, rectText);
            graphics.DrawString(text, Font, brushText, rectText, textFormat);
        }
    }


}
