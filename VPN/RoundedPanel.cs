using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VPN
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    public class RoundedPanel : Panel
    {
        private int _cornerRadius = 16;
        private int _borderThickness = 1;
        private Color _borderColor = Color.FromArgb(40, 80, 140);

        [Category("Appearance")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = Math.Max(0, value); Invalidate(); UpdateRegion(); }
        }

        [Category("Appearance")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = Math.Max(0, value); Invalidate(); UpdateRegion(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.FromArgb(18, 26, 48);
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Avoid flicker; we'll paint background ourselves in OnPaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var fillPath = BuildRoundPath(GetInnerRect(0), CornerRadius))
            using (var fill = new SolidBrush(BackColor))
            {
                g.FillPath(fill, fillPath);
            }

            if (BorderThickness > 0)
            {
                float inset = BorderThickness / 2f;
                var r = new RectangleF(inset, inset, Width - 1f - 2 * inset, Height - 1f - 2 * inset);

                using (var borderPath = BuildRoundPath(r, Math.Max(0, CornerRadius - (int)inset)))
                using (var pen = new Pen(BorderColor, BorderThickness))
                {
                    g.DrawPath(pen, borderPath);
                }
            }

            base.OnPaint(e);
        }

        private RectangleF GetInnerRect(int shrink)
        {
            return new RectangleF(shrink, shrink, Width - 2f * shrink, Height - 2f * shrink);
        }

        private GraphicsPath BuildRoundPath(RectangleF rect, int radius)
        {
            float d = radius * 2f;
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            path.AddArc(rect.Left, rect.Top, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Top, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void UpdateRegion()
        {
             var path = BuildRoundPath(new RectangleF(0, 0, Width, Height), CornerRadius);
            Region = new Region(path);
        }
    }
}
