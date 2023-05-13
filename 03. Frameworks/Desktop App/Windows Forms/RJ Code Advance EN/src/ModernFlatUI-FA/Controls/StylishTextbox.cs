using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernFlatUI_FA.Controls
{
    [DefaultEvent(nameof(_TextChanged))]
    public partial class StylishTextbox : UserControl
    {
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlineStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocus = false;
        private int borderRadius = 0;

        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = string.Empty;
        private bool isPlaceholder  = false;
        private bool isPasswordChar = false;    


        public StylishTextbox()
        {
            InitializeComponent();
        }

        public event EventHandler? _TextChanged;

        [Category("CustomStyle")]
        public Color BorderColor
        {
            get => borderColor; set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("CustomStyle")]
        public int BorderSize
        {
            get => borderSize; set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("CustomStyle")]
        public bool UnderlineStyle
        {
            get => underlineStyle; set
            {
                underlineStyle = value;
                Invalidate();
            }
        }

        [Category("CustomStyle")]
        public bool PasswordChar
        {
            get { return isPasswordChar;}
            set
            {
                isPasswordChar = value;
                textBox1.UseSystemPasswordChar = value;
            }
        }

        [Category("CustomStyle")]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set
            {
                textBox1.Multiline = value;
            }
        }

        [Category("CustomStyle")]
        public override Color BackColor
        {
            get => base.BackColor; set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("CustomStyle")]
        public override Color ForeColor
        {
            get => base.ForeColor; set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("CustomStyle")]
        public HorizontalAlignment TextAlign
        {
            get { return textBox1.TextAlign; }
            set { textBox1.TextAlign = value; }
        }

        [Category("CustomStyle")]
        [AllowNull]
        public override Font Font
        {
            get => base.Font; 
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if(DesignMode) { UpdateControlHeight(); }
            }
        }

        [Category("CustomStyle")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }


        [Category("CustomStyle")]
        public Color BorderFocusColor
        {
            get => borderFocusColor; set
            {
                borderFocusColor = value;
            }
        }

        [Category("CustomStyle")]
        public int BorderRadius
        {
            get => borderRadius; set
            {
                if(value>0)
                {
                    borderRadius = value;
                    Invalidate();
                }
            }
        }

        [Category("CustomStyle")]
        public Color PlaceholderColor
        {
            get => placeholderColor; set
            {
                placeholderColor = value;
                if(isPlaceholder)
                {
                    textBox1.ForeColor = value;
                }
            }
        }

        [Category("CustomStyle")]
        public string PlaceholderText
        {
            get => placeholderText; set
            {
                placeholderText = value;
                textBox1.Text = "";
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder= true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics= e.Graphics;

            if(borderRadius > 1 && borderRadius > borderSize)
            {
                var rectBorderSmooth = ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize >0 ? borderSize : 1;

                using(GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth,borderRadius))
                using(GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using(Pen penBorderSmooth = new Pen(Parent!.BackColor,smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    Region = new Region(pathBorderSmooth);

                    if (borderRadius > 15) SetTextBoxRoundedRegion();
                    graphics.SmoothingMode= SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;

                    if (isFocus)
                    {
                        penBorder.Color = borderFocusColor;
                        //penBorder.Width = borderSize * 2;
                    }

                    if (underlineStyle)
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);

                    }
                    else
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.DrawPath(penBorder,pathBorder);
                    }
                }
                return;
            }

            using(Pen penBorder = new Pen(borderColor, borderSize))
            {
                Region = new Region(ClientRectangle);
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (isFocus)
                {
                    penBorder.Color = borderFocusColor;
                    //penBorder.Width = borderSize * 2;
                }

                if (underlineStyle)
                {
                    graphics.DrawLine(penBorder, 0, Height - 1, Width, Height - 1);

                }
                else
                {
                    graphics.DrawRectangle(penBorder, 0, 0, Width - 0.5F, Height - 0.5F);
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if(Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize*2);
                textBox1.Region = new Region(pathTxt);
            }
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }


        private void UpdateControlHeight()
        {
           if(textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", Font).Height + 1;
                textBox1.Multiline= true;   
                textBox1.MinimumSize = new Size(0,txtHeight);
                textBox1.Multiline= false;

                Height = textBox1.Height + Padding.Top + Padding.Bottom ;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(_TextChanged!= null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocus= true;
            Invalidate();
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocus = false;
            Invalidate();
            SetPlaceholder();
        }
    }
}
