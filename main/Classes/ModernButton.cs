using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace client.Classes
{
    public class ModernButton : Button
    {
        private bool isHovered = false;
        private bool isPressed = false;

        public int CornerRadius { get; set; } = 6;
        public Color BorderColor { get; set; } = Color.FromArgb(78, 78, 78);
        public Color HoverBackColor { get; set; } = Color.Empty;

        public ModernButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            TabStop = false;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            isPressed = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color parentBack = Parent != null ? Parent.BackColor : Color.FromArgb(18, 18, 18);
            g.Clear(parentBack);

            Color fillColor = BackColor;
            if (isPressed)
            {
                fillColor = ShiftColor(fillColor, -15);
            }
            else if (isHovered)
            {
                fillColor = HoverBackColor != Color.Empty ? HoverBackColor : ShiftColor(fillColor, 18);
            }

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            int radius = Math.Min(CornerRadius, Math.Min(rect.Width, rect.Height) / 2);

            using (GraphicsPath path = CreateRoundedRect(rect, radius))
            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen borderPen = new Pen(isHovered ? ShiftColor(BorderColor, 25) : BorderColor, 1f))
            {
                g.FillPath(brush, path);
                g.DrawPath(borderPen, path);
            }

            TextRenderer.DrawText(
                g,
                Text,
                Font,
                ClientRectangle,
                Enabled ? ForeColor : Color.Gray,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
            );
        }

        private static Color ShiftColor(Color c, int delta)
        {
            return Color.FromArgb(
                c.A,
                Math.Max(0, Math.Min(255, c.R + delta)),
                Math.Max(0, Math.Min(255, c.G + delta)),
                Math.Max(0, Math.Min(255, c.B + delta))
            );
        }

        private static GraphicsPath CreateRoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

