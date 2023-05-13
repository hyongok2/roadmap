using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ModernFlatUI_FA.Controls;

public class StylishDatePicker : DateTimePicker
{
    private Color skinColor = Color.MediumSlateBlue;
    private Color textColor = Color.White;
    private Color borderColor = Color.PaleVioletRed;
    private int borderSize = 0;

    private bool dropDown = false;
    private Image calenderIcon = Properties.Resources.calendarWhite;
    private RectangleF iconButtonArea;
    private const int calendarIconWidth = 34;
    private const int arrowIconWidth = 17;

    public Color SkinColor
    {
        get => skinColor;
        set
        {
            skinColor = value;
            if(skinColor.GetBrightness() >= 0.8)
                calenderIcon = Properties.Resources.calendarDark;
            else
                calenderIcon = Properties.Resources.calendarWhite;

            Invalidate();
        }
    }
    public Color TextColor
    {
        get => textColor; 
        set
        {
            textColor = value;
            Invalidate();
        }
    }
    public Color BorderColor
    {
        get => borderColor; 
        set
        {
            borderColor = value;
            Invalidate();
        }
    }
    public int BorderSize
    {
        get => borderSize; 
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    public StylishDatePicker()
    {
        SetStyle(ControlStyles.UserPaint, true);
        MinimumSize = new Size(0, 35);
        Font = new Font(Font.Name, 9.5F);
    }

    protected override void OnDropDown(EventArgs eventargs)
    {
        base.OnDropDown(eventargs);
        dropDown = true;
    }

    protected override void OnCloseUp(EventArgs eventargs)
    {
        base.OnCloseUp(eventargs); 
        dropDown = false;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        e.Handled = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using(Graphics graphics = CreateGraphics())
        using(Pen penBorder = new Pen(borderColor,borderSize))
        using(SolidBrush skinBrush= new SolidBrush(skinColor))
        using(SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50,64,64,64)))
        using(SolidBrush textBrush = new SolidBrush(textColor))
        using(StringFormat textFormat = new StringFormat())
        {
            RectangleF clientArea = new RectangleF(0, 0, Width - 0.5F, Height - 0.5F);
            RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth,0,calendarIconWidth, clientArea.Height);
            penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            textFormat.LineAlignment = StringAlignment.Center;  

            graphics.FillRectangle(skinBrush, clientArea);
            graphics.DrawString("   " + Text, Font, textBrush, clientArea, textFormat);
            if(dropDown == true) graphics.FillRectangle(openIconBrush, iconArea);
            if (borderSize >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);

            graphics.DrawImage(calenderIcon, Width - calenderIcon.Width-9,(Height - calenderIcon.Height)/2);
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        int iconWidth = GetIconButtonWidth();
        iconButtonArea = new RectangleF(Width - iconWidth,0,iconWidth,Height);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if(iconButtonArea.Contains(e.Location))
        {
            Cursor = Cursors.Hand;
        }
        else Cursor= Cursors.Default;   
    }

    private int GetIconButtonWidth()
    {
        int textWidth = TextRenderer.MeasureText(Text, Font).Width;
        if (textWidth <= Width - (calendarIconWidth + 20))
        {
            return calendarIconWidth;
        }
        else return arrowIconWidth;
    }

}
