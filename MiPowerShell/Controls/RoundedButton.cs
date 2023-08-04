using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPowerShell.Controls
{
    public class RoundedButton : Button
    {
        public int CornerRadius { get; set; } = 20;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddRoundedRectangle(new Rectangle(0, 0, this.Width, this.Height), CornerRadius);
            this.Region = new System.Drawing.Region(grPath);

            // Draw the border
            using (Pen pen = new Pen(this.FlatAppearance.BorderColor, this.FlatAppearance.BorderSize))
            {
                e.Graphics.DrawPath(pen, grPath);
            }

            base.OnPaint(e);
        }
    }
    public static class GraphicsPathExtensions
    {
        public static void AddRoundedRectangle(this GraphicsPath path, Rectangle rectangle, int cornerRadius)
        {
            int diam = cornerRadius * 2;
            Size size = new Size(diam, diam);
            Rectangle arc = new Rectangle(rectangle.Location, size);
            path.AddArc(arc, 180, 90);
            arc.X = rectangle.Right - diam;
            path.AddArc(arc, 270, 90);
            arc.Y = rectangle.Bottom - diam;
            path.AddArc(arc, 0, 90);
            arc.X = rectangle.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
        }
    }
}
