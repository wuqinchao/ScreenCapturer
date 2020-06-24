using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapturer
{
    /// <summary>
    /// 标识点
    /// </summary>
    public class FlagPoint
    {
        private static int HalfFlagPoint = 3;
        private static int FullFlagPoint = HalfFlagPoint * 2;
        private CaptrueHitType hitType = CaptrueHitType.None;
        public int X = int.MinValue;
        public int Y = int.MinValue;
        /// <summary>
        /// 标识点区域
        /// </summary>
        public Rectangle FlagRect => new Rectangle(X - HalfFlagPoint, Y - HalfFlagPoint, FullFlagPoint, FullFlagPoint);
        /// <summary>
        /// 标识点
        /// </summary>
        public Point Flag
        {
            get
            {
                if (X == int.MinValue || Y == int.MinValue)
                {
                    return Point.Empty;
                }
                return new Point(X, Y);
            }
            set { X = value.X; Y = value.Y; }
        }
        public CaptrueHitType HitType => hitType;
        public bool IsEmpty => X == int.MinValue || Y == int.MinValue;
        public bool IncludePoint(Point point)
        {
            Rectangle rect = FlagRect;
            return point.X >= rect.X && point.X <= rect.X + rect.Width && point.Y >= rect.Y && point.Y <= rect.Y + rect.Height;
        }
    }
}
