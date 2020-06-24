using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapturer
{
    public class CaptureRectangle
    {
        public static readonly Dictionary<CaptrueHitType, Cursor> CursorsMap = new Dictionary<CaptrueHitType, Cursor>();
        private static int HalfFlagPoint = 3;
        private static int FullFlagPoint = HalfFlagPoint * 2;
        /// <summary>
        /// 左上角
        /// </summary>
        public Point PLT = Point.Empty;
        /// <summary>
        /// 右下角
        /// </summary>
        public Point PRB = Point.Empty;
        public bool CanDraw => !PLT.IsEmpty && !PRB.IsEmpty;
        public Point PLB => CanDraw ? new Point(PLT.X, PRB.Y) : Point.Empty;
        public Point PRT => CanDraw ? new Point(PRB.X, PLT.Y) : Point.Empty;
        public Point PL => CanDraw ? new Point(PLT.X, PLT.Y + (PRB.Y - PLT.Y) / 2) : Point.Empty;
        public Point PT => CanDraw ? new Point(PLT.X + ((PRB.X - PLT.X) / 2), PLT.Y) : Point.Empty;
        public Point PR => CanDraw ? new Point(PRB.X, PLT.Y + ((PRB.Y - PLT.Y) / 2)) : Point.Empty;
        public Point PB => CanDraw ? new Point(PLT.X + ((PRB.X - PLT.X) / 2), PRB.Y) : Point.Empty;
        public int CaptureWidth => CanDraw ? PRB.X - PLT.X : 0;
        public int CaptureHeight => CanDraw ? PLB.Y - PLT.Y : 0;
        public Rectangle CaptureRect => new Rectangle(PLT.X, PLT.Y, CaptureWidth, CaptureHeight);
        static CaptureRectangle()
        {
            CursorsMap.Add(CaptrueHitType.LeftTop, Cursors.SizeNWSE);
            CursorsMap.Add(CaptrueHitType.RightTop, Cursors.SizeNESW);
            CursorsMap.Add(CaptrueHitType.RightBottom, Cursors.SizeNWSE);
            CursorsMap.Add(CaptrueHitType.LeftBottom, Cursors.SizeNESW);
            CursorsMap.Add(CaptrueHitType.Left, Cursors.SizeWE);
            CursorsMap.Add(CaptrueHitType.Top, Cursors.SizeNS);
            CursorsMap.Add(CaptrueHitType.Right, Cursors.SizeWE);
            CursorsMap.Add(CaptrueHitType.Bottom, Cursors.SizeNS);
            CursorsMap.Add(CaptrueHitType.InPlace, Cursors.SizeAll);
            CursorsMap.Add(CaptrueHitType.None, Cursors.Default);
        }
        public CaptrueHitType TestPoint(int x, int y, bool resize = true)
        {
            if (resize && PointInFlag(PLT, x, y))
            {
                return CaptrueHitType.LeftTop;
            }
            else if (resize && PointInFlag(PRT, x, y))
            {
                return CaptrueHitType.RightTop;
            }
            else if (resize && PointInFlag(PRB, x, y))
            {
                return CaptrueHitType.RightBottom;
            }
            else if (resize && PointInFlag(PLB, x, y))
            {
                return CaptrueHitType.LeftBottom;
            }
            else if (resize && PointInLine(PLT, PRT, x, y))
            {
                return CaptrueHitType.Top;
            }
            else if (resize && PointInLine(PRT, PRB, x, y))
            {
                return CaptrueHitType.Right;
            }
            else if (resize && PointInLine(PLB, PRB, x, y))
            {
                return CaptrueHitType.Bottom;
            }
            else if (resize && PointInLine(PLT, PLB, x, y))
            {
                return CaptrueHitType.Left;
            }
            else if (x >= PLT.X && x <= PRB.X && y >= PLT.Y && y <= PRB.Y)
            {
                return CaptrueHitType.InPlace;
            }
            return CaptrueHitType.None;
        }
        public bool PointIn(Point p)
        {
            return PointInRect(p, PLT, PRB);
        }
        public void Draw(Graphics g, Color color)
        {
            using (Pen pen = new Pen(color, 2))
            {
                // 画框选的矩形
                Rectangle t = new Rectangle(PLT.X, PLT.Y, CaptureWidth, CaptureHeight);
                g.DrawRectangle(pen, t);
                // 画8个点
                using (Brush br = new SolidBrush(color))
                {
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PL));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PT));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PR));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PB));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PLT));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PRT));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PRB));
                    g.FillRectangle(br, CaptureRectangle.Point2FlagPoint(PLB));
                }
            }
        }
        public static bool PointInFlag(Point flag, int x, int y)
        {
            return x >= flag.X - HalfFlagPoint
                && x <= flag.X + HalfFlagPoint
                && y >= flag.Y - HalfFlagPoint
                && y <= flag.Y + HalfFlagPoint;
        }
        public static Rectangle Point2FlagPoint(Point p)
        {
            return new Rectangle(p.X - HalfFlagPoint, p.Y - HalfFlagPoint, FullFlagPoint, FullFlagPoint);
        }
        private static bool PointInRect(int curX, int curY, Rectangle rect)
        {
            return curX >= rect.X && curX <= rect.X + rect.Width && curY >= rect.Y && curY <= rect.Y + rect.Height;
        }
        private static bool PointInRect(Point p, Point lt, Point rb)
        {
            return p.X >= lt.X && p.X <= rb.X && p.Y >= lt.Y && p.Y <= rb.Y;
        }
        private static bool PointInLine(Point p1, Point p2, int curX, int curY)
        {
            if (p1.X == p2.X) // |
            {
                return Math.Abs(p1.X - curX) < 2 && (curY <= Math.Max(p1.Y, p2.Y) && curY >= Math.Min(p1.Y, p2.Y));
            }
            else if (p1.Y == p2.Y) // -
            {
                return Math.Abs(p1.Y - curY) < 2 && (curX <= Math.Max(p1.X, p2.X) && curX >= Math.Min(p1.X, p2.X));
            }
            return false;
        }
    }
}
