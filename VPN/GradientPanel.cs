// File: GradientPanel.cs
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VPN
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    public class GradientPanel : Panel
    {
        [Category("Appearance")]
        public Color GradientTopLeft { get; set; } = Color.FromArgb(24, 34, 64);

        [Category("Appearance")]
        public Color GradientBottomRight { get; set; } = Color.FromArgb(14, 22, 40);

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;
             var brush = new LinearGradientBrush(ClientRectangle, GradientTopLeft, GradientBottomRight, 45f);
            e.Graphics.FillRectangle(brush, ClientRectangle);
        }
    }
}
