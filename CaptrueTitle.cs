using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapturer
{
    public class CaptrueTitle
    {
        public const int Padding = 3;
        public const int MarginBottom = 4;
        public static void Draw(Graphics g, Brush forceBrush, Brush backBrush, Font font, CaptureRectangle target)
        {
            var info = $"{target.CaptureWidth} x {target.CaptureHeight}";
            var infoSize = g.MeasureString(info, font);
            g.FillRectangle(backBrush, target.PLT.X, target.PLT.Y - infoSize.Height - Padding * 2 - MarginBottom, infoSize.Width + Padding * 2, infoSize.Height + Padding * 2);
            g.DrawString(info, font, forceBrush, target.PLT.X + Padding, target.PLT.Y - infoSize.Height - MarginBottom - Padding);
        }
    }
}
