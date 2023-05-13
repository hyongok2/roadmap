using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ModernFlatUI_FA.Controls;

[DefaultEvent(nameof(OnSelectedIndexChanged))]
public class StylishComboBox : UserControl
{
    private Color backColor  = Color.WhiteSmoke;
    private Color iconColor = Color.MediumSlateBlue;
    private Color listBackColor = Color.FromArgb(230,228,245);
    private Color listTextColor = Color.DimGray;
    private Color borderColor = Color.MediumSlateBlue;
    private int borderSize = 1;
    private int iconWidth = 14;

    private ComboBox cmbList;
    private Label lblText;
    private Button btnIcon;

    [Category("CustomStyle")]
    public new Color BackColor
    {
        get => backColor; set
        {
            backColor = value;
            lblText.BackColor = backColor;
            btnIcon.BackColor = backColor;  
        }
    }
    [Category("CustomStyle")]
    public Color IconColor
    {
        get => iconColor; set
        {
            iconColor = value;
            btnIcon.Invalidate();
        }
    }
    [Category("CustomStyle")]
    public Color ListBackColor
    {
        get => listBackColor; set
        {
            listBackColor = value;
            cmbList.BackColor = listBackColor;
        }
    }
    [Category("CustomStyle")]
    public Color ListTextColor
    {
        get => listTextColor; set
        {
            listTextColor = value;
            cmbList.ForeColor = listTextColor;
        }
    }
    [Category("CustomStyle")]
    public Color BorderColor
    {
        get => borderColor; set
        {
            borderColor = value;
            base.BackColor= borderColor;
        }
    }
    [Category("CustomStyle")]
    public int BorderSize
    {
        get => borderSize; set
        {
            borderSize = value;
            Padding = new Padding(borderSize);
            AdjustComboBoxDimensions();
        }
    }
    [Category("CustomStyle")]
    public override Color ForeColor
    {
        get => base.ForeColor; set
        {
            base.ForeColor = value;
            lblText.ForeColor = value;
        }
    }
    [Category("CustomStyle")]
    [AllowNull]
    public override Font Font
    {
        get => base.Font; 
        set
        {
            base.Font = value;
            lblText.Font = value;
            cmbList.Font = value;
        }
    }
    [Category("CustomStyle")]
    public string Texts
    {
        get { return lblText.Text; }
        set { lblText.Text = value; }
    }
    [Category("CustomStyle")]
    public ComboBoxStyle DropDownStyle
    {
        get { return cmbList.DropDownStyle; }
        set 
        { 
            if(cmbList.DropDownStyle!= ComboBoxStyle.Simple) 
                cmbList.DropDownStyle = value;
        }
    }
    [Category("CustomData")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(true)]
    [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=7.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [MergableProperty(false)]
    public ComboBox.ObjectCollection Items
    {
        get
        {
            return cmbList.Items;
        }
    }

    [Category("CustomData")]
    [DefaultValue(null)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [AttributeProvider(typeof(IListSource))]
    public object DataSource
    {
        get => cmbList.DataSource;
        set => cmbList.DataSource = value;
    }
    [Category("CustomData")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(true)]
    [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=7.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public AutoCompleteStringCollection AutoCompleteCustomSource
    {
        get
        {
            return cmbList.AutoCompleteCustomSource;
        }
        set
        {
            cmbList.AutoCompleteCustomSource= value;
        }
    }
    [Category("CustomData")]
    [DefaultValue(AutoCompleteMode.None)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public AutoCompleteMode AutoCompleteMode
    {
        get
        {
            return cmbList.AutoCompleteMode;
        }
        set
        {
            cmbList.AutoCompleteMode = value;
        }
    }
    [Category("CustomData")]
    [DefaultValue(AutoCompleteSource.None)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public AutoCompleteSource AutoCompleteSource
    {
        get
        {
            return cmbList.AutoCompleteSource;
        }
        set
        {
            cmbList.AutoCompleteSource = value;
        }
    }
    [Category("CustomData")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedIndex
    {
        get
        {
            return cmbList.SelectedIndex;
        }
        set
        {
            cmbList.SelectedIndex = value;
        }
    }
    [Category("CustomData")]
    [Browsable(false)]
    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object SelectedItem
    {
        get
        {
            return cmbList.SelectedItem;
        }
        set
        {
            cmbList.SelectedItem = value;
        }
    }

    public event EventHandler? OnSelectedIndexChanged;

    public StylishComboBox()
    {
        cmbList = new ComboBox();
        lblText =   new Label();
        btnIcon = new Button();
        SuspendLayout();

        cmbList.BackColor= listBackColor;
        cmbList.Font = new Font(Font.Name, 10F);
        cmbList.ForeColor = listTextColor;
        cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);
        cmbList.Resize += new EventHandler(ComboBox_Resize);

        btnIcon.Dock = DockStyle.Right;
        btnIcon.FlatStyle = FlatStyle.Flat;
        btnIcon.FlatAppearance.BorderSize= 0;
        btnIcon.BackColor = backColor;
        btnIcon.Size = new Size(30, 30);
        btnIcon.Cursor= Cursors.Hand;
        btnIcon.Click += new EventHandler(Icon_Click);
        btnIcon.Paint += new PaintEventHandler(Icon_Paint);

        lblText.Dock = DockStyle.Fill;
        lblText.AutoSize = false;
        lblText.BackColor = backColor;
        lblText.TextAlign = ContentAlignment.MiddleLeft;
        lblText.Padding = new Padding(8,0,0,0);
        lblText.Font = new Font(Font.Name, 10F);
        lblText.Click += new EventHandler(Surface_Click);
        lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
        lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

        Controls.Add(lblText);
        Controls.Add(btnIcon);
        Controls.Add(cmbList);
        MinimumSize = new Size(200, 32);
        ForeColor = Color.DimGray;
        Size = new Size(200, 32);
        Padding = new Padding(BorderSize);
        base.BackColor = borderColor;
        ResumeLayout();

        AdjustComboBoxDimensions();
    }

    private void AdjustComboBoxDimensions()
    {
        cmbList.Width= lblText.Width + iconWidth;
        cmbList.Location = new Point()
        {
            X = Width - Padding.Right - cmbList.Width - iconWidth,
            Y = lblText.Bottom - cmbList.Height
        };
    }

    private void ComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (OnSelectedIndexChanged != null)
            OnSelectedIndexChanged.Invoke(sender, e);

        lblText.Text = cmbList.Text;
    }
    private void ComboBox_TextChanged(object? sender, EventArgs e)
    {
        lblText.Text = cmbList.Text;
    }

    private void Icon_Click(object? sender, EventArgs e)
    {
        cmbList.Select();
        cmbList.DroppedDown = true;
    }
    private void Icon_Paint(object? sender, PaintEventArgs e)
    {
        int iconHeight = 6;
        var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2 , (btnIcon.Height - iconHeight)/2 , iconWidth, iconHeight);
        Graphics graphics = e.Graphics;
        
        using(GraphicsPath path = new GraphicsPath())
        using(Pen pen = new Pen(iconColor,2))
        {
            graphics.SmoothingMode= SmoothingMode.AntiAlias;
            path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
            path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
            graphics.DrawPath(pen, path);
        }
     }

    private void Surface_Click(object? sender, EventArgs e)
    {
        OnClick(e);
        cmbList.Select();
        if(cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
        {
            cmbList.DroppedDown= true;
        }
    }

    private void ComboBox_Resize(object? sender, EventArgs e)
    {
        AdjustComboBoxDimensions();
    }

    private void Surface_MouseLeave(object? sender, EventArgs e)
    {
        OnMouseLeave(e);
    }

    private void Surface_MouseEnter(object? sender, EventArgs e)
    {
        OnMouseEnter(e);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        AdjustComboBoxDimensions();
    }
}
