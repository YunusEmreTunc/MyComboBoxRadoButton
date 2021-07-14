using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace MyComboBoxRadioButton
{
    /// <summary>
    /// <seealso cref="MyRadioButton"/> sınıfı, <seealso cref="RadioButton"/> sınıfından türetilmiştir.
    /// </summary>
    public partial class MyRadioButton : RadioButton
    {
        private Color checkedColor = Color.MediumSlateBlue;
        private Color uncheckedColor = Color.Gray;
        public Color CheckedColor
        {
            get
            {
                return checkedColor;
            }
            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }
        public Color UnCheckedColor
        {
            get
            {
                return uncheckedColor;

            }
            set
            {
                uncheckedColor = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2,
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
                Y = (this.Height - rbCheckSize) / 2,
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            using Pen penBorder = new(checkedColor, 1.6F);
            using SolidBrush brushRbCheck = new(checkedColor);
            using SolidBrush brushText = new(this.ForeColor);
            graphics.Clear(this.BackColor);
            if (this.Checked)
            {
                graphics.DrawEllipse(penBorder, rectRbBorder);
                graphics.FillEllipse(brushRbCheck, rectRbCheck);
            }
            else
            {
                penBorder.Color = uncheckedColor;
                graphics.DrawEllipse(penBorder, rectRbBorder);
            }
            graphics.DrawString(this.Text, this.Font, brushText,
                rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 18;
        }
    }
}
