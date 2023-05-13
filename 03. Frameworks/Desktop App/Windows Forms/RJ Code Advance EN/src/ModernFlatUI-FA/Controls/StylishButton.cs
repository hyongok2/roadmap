using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernFlatUI_FA.Controls;

public class StylishButton : Button
{
    private int borderSize = 0;
    private int borderRadius = 30;
    private Color borderColor = Color.PaleVioletRed;

    [Category("Custom")]
    public int BorderSize 
    { 
        get => borderSize; 
        set
        {
            borderSize = value; 
            Invalidate();
        } 
    }
    [Category("Custom")]
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            if (value <= Height)
                borderRadius = value;
            else borderRadius = Height;
            Invalidate();
        }
    }
    [Category("Custom")]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    public StylishButton()
    {
        FlatStyle= FlatStyle.Flat;
        FlatAppearance.BorderSize= 0;
        Size = new System.Drawing.Size(150, 40);
        BackColor = Color.MediumSlateBlue;
        ForeColor= Color.White;
        Resize += new EventHandler(Button_Resize);
    }


    private GraphicsPath GetFigurePath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        float curveSize = radius * 2;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();

        return path;
    }


    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode= SmoothingMode.AntiAlias;

        RectangleF rectSurface = new RectangleF(0, 0, Width, Height);
        RectangleF rectBorder = new RectangleF(1, 1, Width - 0.8F, Height - 1);

        if(BorderRadius > 2)
        {
            using(GraphicsPath pathSurface = GetFigurePath(rectSurface,BorderRadius))
            using(GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1F))
            using(Pen penSurface = new Pen(Parent!.BackColor,2))
            using(Pen penBorder = new Pen(BorderColor,BorderSize))
            {
                penBorder.Alignment = PenAlignment.Inset;
                Region = new Region(pathSurface);
                pevent.Graphics.DrawPath(penSurface, pathSurface);

                if(BorderSize >= 1)
                    pevent.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        else
        {
            Region = new Region(rectSurface);
            if(BorderSize >= 1)
            {
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder,0,0,Width-1, Height-1);
                }
            }
        }

    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    private void Container_BackColorChanged(object? sender, EventArgs e)
    {
        if(DesignMode) Invalidate();
    }

    private void Button_Resize(object? sender, EventArgs e)
    {
        if (borderRadius > Height)
            borderRadius = Height;
    }
}
