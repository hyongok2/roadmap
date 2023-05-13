using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ModernFlatUI_FA.Controls;

public enum TextPosition
{
    Left,
    Right,
    Center,
    Sliding,
    None
}

public class StylishProgressBar : ProgressBar
{
    private Color channelColor = Color.LightSteelBlue;
    private Color sliderColor = Color.RoyalBlue;
    private Color foreBackColor = Color.RoyalBlue;
    private int channelHeight = 6;
    private int sliderHeight = 6;
    private TextPosition showValue = TextPosition.Right;
    private string symbolBefore = "";
    private string symbolAfter = "";
    private bool showMaximum = false;

    private bool paintBack = false;
    private bool stopPainting = false;

    public StylishProgressBar()
    {
        SetStyle(ControlStyles.UserPaint,true);
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
    public int ChannelHeight
    {
        get => channelHeight; set
        {
            channelHeight = value;
            Invalidate();
        }
    }
    [Category("CustomStyle")]
    public int SliderHeight
    {
        get => sliderHeight; set
        {
            sliderHeight = value;
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
        if(stopPainting == false)
        {
            if(paintBack == false)
            {
                Graphics graphics= pevent.Graphics;
                Rectangle rectChannel = new Rectangle(0, 0, Width, ChannelHeight);

                using(var brushChannel = new SolidBrush(channelColor))
                {
                    if(channelHeight >= sliderHeight)
                    {
                        rectChannel.Y = Height - channelHeight;
                    }
                    else
                    {
                        rectChannel.Y = Height - ((channelHeight + sliderHeight) / 2);
                    }

                    graphics.Clear(Parent!.BackColor);
                    graphics.FillRectangle(brushChannel, rectChannel);

                    if(DesignMode == false)
                    {
                       // paintBack= true;
                    }
                }
            }

            if(Value == Maximum || Value == Minimum )
                paintBack= false;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if(stopPainting==false) 
        {
            Graphics graphics= e.Graphics;
            double scaleFactor = (((double)Value -Minimum) / ((double)Maximum - Minimum));
            int sliderWidth = (int)(Width*scaleFactor);
            Rectangle rectSlider = new Rectangle(0,0,sliderWidth, sliderHeight);

            using(var brushSlider = new SolidBrush(sliderColor))
            {
                if(sliderHeight >= channelHeight)
                {
                    rectSlider.Y = Height - sliderHeight;
                }
                else
                {
                    rectSlider.Y = Height - ((sliderHeight + channelHeight) / 2);
                }

                if(sliderWidth >1)
                {
                    graphics.FillRectangle(brushSlider, rectSlider);
                }
                if(showValue != TextPosition.None)
                {
                    DrawValueText(graphics, sliderWidth, rectSlider);
                }
            }
        }

        //if (Value == Maximum) stopPainting = true;
        //else stopPainting = false;
    }

    private void DrawValueText(Graphics graphics, int sliderWidth, Rectangle rectSlider)
    {
        string text = symbolBefore + Value.ToString() + symbolAfter;
        if(showMaximum) text = text + "/" +symbolBefore + Maximum.ToString()+ symbolAfter;
        var textSize = TextRenderer.MeasureText(text, Font);
        var rectText = new Rectangle(0,0,textSize.Width + 2, textSize.Height + 2);
        using (var brushText = new SolidBrush(ForeColor))
        using (var brushTextBack = new SolidBrush(foreBackColor))
        using (var textFormat = new StringFormat())
        {
            switch(showValue)
            {
                case TextPosition.Left:
                    rectText.X = 0;
                    textFormat.Alignment = StringAlignment.Near;
                    break;
                case TextPosition.Right:
                    rectText.X = Width - textSize.Width;
                    textFormat.Alignment = StringAlignment.Far;
                    break;
                case TextPosition.Center:
                    rectText.X = (Width - textSize.Width)/2;
                    textFormat.Alignment = StringAlignment.Center;
                    break;
                case TextPosition.Sliding:
                    rectText.X = sliderWidth -textSize.Width;
                    textFormat.Alignment = StringAlignment.Center;
                    using(var brushClear = new SolidBrush(Parent!.BackColor))
                    {
                        var rect = rectSlider;
                        rect.Y = rectText.Y;
                        rect.Height= rectText.Height;
                        graphics.FillRectangle(brushClear, rect);
                    }
                    break;
            }
            graphics.FillRectangle(brushTextBack, rectText);
            graphics.DrawString(text,Font,brushText,rectText,textFormat);
        }
    }
}
