using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernFlatUI_FA.Controls;

public class ToggleButton : CheckBox
{
    private Color onBackColor = Color.MediumSlateBlue;
    private Color onToggleColor = Color.WhiteSmoke;
    private Color offBackColor = Color.Gray;
    private Color offToggleColor = Color.Gainsboro;
    private bool solidStyle = true;

    [Category("Custom")]
    public Color OnBackColor 
    { 
        get => onBackColor;
        set
        {
            onBackColor = value; 
            Invalidate();
        } 
    }
    [Category("Custom")]
    public Color OnToggleColor 
    { 
        get => onToggleColor;
        set 
        {
            onToggleColor = value;
            Invalidate();
        }
    }
    [Category("Custom")]
    public Color OffBackColor
    {
        get => offBackColor;
        set
        {
            offBackColor = value;
            Invalidate();
        }
    }
    [Category("Custom")]
    public Color OffToggleColor
    {
        get => offToggleColor;
        set
        {
            offToggleColor = value;
            Invalidate();
        }
    }

    [Category("Custom")]
    [DefaultValue(true)]
    public bool SolidStyle
    { 
        get => solidStyle;
        set
        {
            solidStyle = value;
            Invalidate();
        }
    }

    public ToggleButton()
    {
        MinimumSize = new System.Drawing.Size(45, 22);
    }

    private GraphicsPath GetFigurePath()
    {
        int arcSize = Height - 1;
        Rectangle leftArc = new Rectangle(0,0,arcSize,arcSize);
        Rectangle rightArc = new Rectangle(Width - arcSize - 2,0,arcSize,arcSize);

        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(leftArc, 90, 180);
        path.AddArc(rightArc, 270, 180);
        path.CloseFigure();

        return path;    
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        int toggleSize = Height - 5;
        pevent.Graphics.SmoothingMode= SmoothingMode.AntiAlias;
        pevent.Graphics.Clear(Parent.BackColor);

        if(this.Checked)
        {
            if(solidStyle)
                pevent.Graphics.FillPath(new SolidBrush(OnBackColor),GetFigurePath());
            else
                pevent.Graphics.DrawPath(new Pen(OnBackColor,2), GetFigurePath());
            pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
        }
        else
        {
            if (solidStyle)
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
            else
                pevent.Graphics.DrawPath(new Pen(OffBackColor, 2), GetFigurePath());
            pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
        }
    }


}
