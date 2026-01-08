using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VPN
{
    [ToolboxItem(true)]
    [DesignerCategory("Code")]
    public class PillButton : Button
    {
        private bool _hover, _pressed;

        public PillButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            TabStop = true;
            Cursor = Cursors.Hand;

            FillColor = Color.FromArgb(44, 123, 255);
            HoverFillColor = ControlPaint.Light(FillColor);
            PressedFillColor = ControlPaint.Dark(FillColor);
            DisabledFillColor = Color.FromArgb(70, 70, 80);

            TextColor = Color.White;
            DisabledTextColor = Color.FromArgb(200, 200, 200);

            BorderColor = Color.Transparent;
            BorderThickness = 0;
            CornerRadius = -1;
        }

        [Category("Appearance")] public Color FillColor { get; set; }
        [Category("Appearance")] public Color HoverFillColor { get; set; }
        [Category("Appearance")] public Color PressedFillColor { get; set; }
        [Category("Appearance")] public Color DisabledFillColor { get; set; }

        [Category("Appearance")] public Color TextColor { get; set; }
        [Category("Appearance")] public Color DisabledTextColor { get; set; }

        [Category("Appearance")] public Color BorderColor { get; set; }
        [Category("Appearance")] public int BorderThickness { get; set; }
        [Category("Appearance")] public int CornerRadius { get; set; }

        protected override void OnMouseEnter(System.EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(System.EventArgs e) { _hover = false; _pressed = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs me) { if (me.Button == MouseButtons.Left) { _pressed = true; Invalidate(); } base.OnMouseDown(me); }
        protected override void OnMouseUp(MouseEventArgs me) { _pressed = false; Invalidate(); base.OnMouseUp(me); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var parentBack = Parent?.BackColor ?? SystemColors.Control;
            g.Clear(parentBack);

            int radius = CornerRadius < 0 ? Height / 2 : CornerRadius;
            var rect = ClientRectangle;
            rect.Inflate(-1, -1);

             var path = RoundPath(rect, radius);

            Region = new Region(path);

            Color fill = Enabled
                ? (_pressed ? PressedFillColor : _hover ? HoverFillColor : FillColor)
                : DisabledFillColor;

            using (var sb = new SolidBrush(fill))
                g.FillPath(sb, path);

            if (BorderThickness > 0 && BorderColor.A > 0)
            {
                float inset = BorderThickness / 2f;
                var br = new RectangleF(rect.X + inset, rect.Y + inset,
                                        rect.Width - 2 * inset, rect.Height - 2 * inset);
                 var bpath = RoundPath(br, Math.Max(0, radius - (int)inset));
                 var pen = new Pen(BorderColor, BorderThickness);
                g.DrawPath(pen, bpath);
            }

            var color = Enabled ? TextColor : DisabledTextColor;
            TextRenderer.DrawText(
                g, Text, Font, rect, color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static GraphicsPath RoundPath(RectangleF r, int radius)
        {
            float d = radius * 2f;
            var p = new GraphicsPath();
            if (radius <= 0) { p.AddRectangle(r); return p; }

            p.AddArc(r.Left, r.Top, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Top, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.Left, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
