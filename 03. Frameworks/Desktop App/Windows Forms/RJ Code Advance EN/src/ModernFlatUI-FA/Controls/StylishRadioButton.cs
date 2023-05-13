using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernFlatUI_FA.Controls;

public class StylishRadioButton : RadioButton
{
    private Color checkedColor = Color.MediumSlateBlue;
    private Color uncheckedColor = Color.Gray;

    public Color CheckedColor
    {
        get => checkedColor; 
        set
        {
            checkedColor = value;
            Invalidate();
        }
    }
    public Color UncheckedColor
    {
        get => uncheckedColor; 
        set
        {
            uncheckedColor = value;
            Invalidate();
        }
    }

    public StylishRadioButton()
    {
        MinimumSize = new Size(0, 21);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics graphics = pevent.Graphics;
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        float rbBorderSize = 18F;
        float rbCheckSize = 12F;

        RectangleF rectRbBorder = new RectangleF()
        {
            X = 0.5F,
            Y = (Height - rbBorderSize) / 2,
            Width = rbBorderSize,
            Height = rbBorderSize
        };

        RectangleF rectRbCheck = new RectangleF()
        {
            X = rectRbBorder.X  + (rectRbBorder.Width - rbCheckSize)/2,
            Y = (Height - rbCheckSize) / 2,
            Width = rbCheckSize,
            Height = rbCheckSize
        };

        using(Pen penBorder = new Pen(checkedColor,1.6F))
        using(SolidBrush brushRbCheck = new SolidBrush(checkedColor))
        using(SolidBrush brushText = new SolidBrush(ForeColor))
        {
            graphics.Clear(BackColor);
            if(Checked)
            {
                graphics.DrawEllipse(penBorder, rectRbBorder);
                graphics.FillEllipse(brushRbCheck, rectRbCheck);
            }
            else
            {
                penBorder.Color = uncheckedColor;
                graphics.DrawEllipse(penBorder, rectRbBorder);
            }

            graphics.DrawString(Text,Font,brushText,rbBorderSize +8, (Height - TextRenderer.MeasureText(Text,Font).Height)/2);

        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Width = TextRenderer.MeasureText(Text, Font).Width + 30;
    }
}
