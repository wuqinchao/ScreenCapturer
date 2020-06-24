using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenCapturer
{
    public partial class FScreen : Form
    {
        public static int TouchScreenID = -1;
        /// <summary>
        /// 遮罩层画刷
        /// </summary>
        private Brush brush_mask = new SolidBrush(Color.FromArgb(125, Color.Black));
        /// <summary>
        /// 文字背景画刷
        /// </summary>
        private Brush brush_info = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
        /// <summary>
        /// 截图信息类
        /// </summary>
        private CaptureRectangle captureRect = new CaptureRectangle();
        /// <summary>
        /// 屏幕序号
        /// </summary>
        private int ScreenIndex = 0;
        /// <summary>
        /// 当前屏幕基础截图
        /// </summary>
        public Bitmap ScreenCapture;
        /// <summary>
        /// 是否固定截图大小(固定后不允许调整截图大小)
        /// </summary>
        public bool FixRect = true;
        public int FixWidth = 200;
        public int FixHeight = 200;
        /// <summary>
        /// 是否保存到剪切板
        /// </summary>
        public bool SaveToClipboard = true;
        /// <summary>
        /// 是否保存到目录
        /// </summary>
        public bool SaveToFolder = false;
        public string Folder;
        /// <summary>
        /// 是否需要在保存时调整截图大小
        /// </summary>
        public bool Transform = false;
        public int TransformWidth = 0;
        public int TransformHeight = 0;
        /// <summary>
        /// 截图时的标线颜色
        /// </summary>
        public Color LineColor = Color.Red;
        /// <summary>
        /// 当前鼠标点
        /// </summary>
        private Point now = Point.Empty;
        private Point PointLT
        {
            get => captureRect.PLT;
            set => captureRect.PLT = value;
        }
        private Point PointRB
        {
            get => captureRect.PRB;
            set => captureRect.PRB = value;
        }
        private int CaptureWidth => captureRect.CaptureWidth;
        private int CaptureHeight => captureRect.CaptureHeight;
        private bool InDrawMode;
        private CaptrueHitType hitType = CaptrueHitType.None;

        public static void ClearTouchID()
        {
            TouchScreenID = -1;
        }
        public FScreen(int index)
        {
            InitializeComponent();
            ScreenIndex = index;
            CopyScreen();
        }
        private void FScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void FScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                // 如果是多个屏幕,仅允许1个屏幕获得截屏权限
                if (TouchScreenID != -1 && TouchScreenID != ScreenIndex) return;
                if (PointLT == Point.Empty)
                {
                    if (TouchScreenID == -1) TouchScreenID = ScreenIndex;
                    InDrawMode = true;
                    now = PointLT = e.Location;
                    if (FixRect)
                    {
                        PointRB = new Point(e.X + FixWidth, e.Y + FixHeight);
                        hitType = CaptrueHitType.InPlace;
                        this.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        PointRB = PointLT;
                        hitType = CaptrueHitType.RightBottom;
                        this.Cursor = Cursors.SizeNWSE;
                    }
                    Draw();
                }
                else
                {
                    hitType = captureRect.TestPoint(e.X, e.Y, !FixRect);
                    if (hitType == CaptrueHitType.None) return;
                    InDrawMode = true;
                    now = e.Location;
                    this.Cursor = CaptureRectangle.CursorsMap[hitType];
                }
            }
        }
        private void FScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if(InDrawMode)
            {
                InDrawMode = false;
                now = Point.Empty;
                hitType = CaptrueHitType.None;
                this.Cursor = Cursors.Default;
            }
        }
        private void FScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (!InDrawMode) return;
            var offset_x = e.X - now.X;
            var offset_y = e.Y - now.Y;
            now = new Point(e.X, e.Y);
            if (hitType == CaptrueHitType.LeftTop)
            {
                var temp = PointLT = e.Location;
                if (CaptureWidth < 0 && CaptureHeight < 0)
                {
                    PointLT = PointRB;
                    PointRB = temp;
                    hitType = CaptrueHitType.RightBottom;
                }
                else if (CaptureHeight < 0)
                {
                    PointLT = new Point(PointLT.X, PointRB.Y);
                    PointRB = new Point(PointRB.X, temp.Y);
                    hitType = CaptrueHitType.LeftBottom;
                }
                else if (CaptureWidth < 0)
                {
                    PointLT = new Point(PointRB.X, PointLT.Y);
                    PointRB = new Point(temp.X, PointRB.Y);
                    hitType = CaptrueHitType.RightTop;
                }
            }
            else if (hitType == CaptrueHitType.Top)
            {
                var temp = PointLT = new Point(PointLT.X, PointLT.Y + offset_y);
                if (CaptureHeight < 0) // 上下翻转
                {
                    PointLT = new Point(PointLT.X, PointRB.Y);
                    PointRB = new Point(PointRB.X, temp.Y);
                    hitType = CaptrueHitType.Bottom;
                }
            }
            else if (hitType == CaptrueHitType.RightTop)
            {
                var t1 = PointLT = new Point(PointLT.X, e.Y);
                var t2 = PointRB = new Point(e.X, PointRB.Y);
                if (CaptureWidth < 0 && CaptureHeight < 0)
                {
                    PointRB = new Point(PointLT.X, e.Y);
                    PointLT = new Point(e.X, t2.Y);
                    hitType = CaptrueHitType.LeftBottom;
                }
                else if (CaptureHeight < 0)
                {
                    PointLT = new Point(PointLT.X, PointRB.Y);
                    PointRB = new Point(e.X, e.Y);
                    hitType = CaptrueHitType.RightBottom;
                }
                else if (CaptureWidth < 0)
                {
                    PointRB = new Point(PointLT.X, PointRB.Y);
                    PointLT = new Point(e.X, e.Y);
                    hitType = CaptrueHitType.LeftTop;
                }
            }
            else if (hitType == CaptrueHitType.Right)
            {
                var temp = PointRB = new Point(PointRB.X + offset_x, PointRB.Y);
                if (CaptureWidth < 0) // 右左翻转
                {
                    PointRB = new Point(PointLT.X, PointRB.Y);
                    PointLT = new Point(temp.X, PointLT.Y);
                    hitType = CaptrueHitType.Left;
                }
            }
            else if (hitType == CaptrueHitType.RightBottom)
            {
                var temp = PointRB = e.Location;
                if (CaptureWidth < 0 && CaptureHeight < 0)
                {
                    PointRB = PointLT;
                    PointLT = temp;
                    hitType = CaptrueHitType.LeftTop;
                }
                else if (CaptureHeight < 0)
                {
                    PointRB = new Point(PointRB.X, PointLT.Y);
                    PointLT = new Point(PointLT.X, temp.Y);
                    hitType = CaptrueHitType.RightTop;
                }
                else if (CaptureWidth < 0)
                {
                    PointRB = new Point(PointLT.X, PointRB.Y);
                    PointLT = new Point(temp.X, PointLT.Y);
                    hitType = CaptrueHitType.LeftBottom;
                }
            }
            else if (hitType == CaptrueHitType.Bottom)
            {
                var temp = PointRB = new Point(PointRB.X, PointRB.Y + offset_y);
                if (CaptureHeight < 0) // 下上翻转
                {
                    PointRB = new Point(PointRB.X, PointLT.Y);
                    PointLT = new Point(PointLT.X, temp.Y);
                    hitType = CaptrueHitType.Top;
                }
            }
            else if (hitType == CaptrueHitType.LeftBottom)
            {
                var t1 = PointLT = new Point(e.X, PointLT.Y);
                var t2 = PointRB = new Point(PointRB.X, e.Y);
                if (CaptureWidth < 0 && CaptureHeight < 0)
                {
                    PointRB = new Point(e.X, PointLT.Y);
                    PointLT = new Point(t2.X, e.Y);
                    hitType = CaptrueHitType.RightTop;
                }
                else if (CaptureHeight < 0)
                {
                    PointRB = new Point(PointRB.X, PointLT.Y);
                    PointLT = new Point(e.X, e.Y);
                    hitType = CaptrueHitType.LeftTop;
                }
                else if (CaptureWidth < 0)
                {
                    PointLT = new Point(PointRB.X, PointLT.Y);
                    PointRB = new Point(e.X, e.Y);
                    hitType = CaptrueHitType.RightBottom;
                }
            }
            else if (hitType == CaptrueHitType.Left)
            {
                var temp = PointLT = new Point(PointLT.X + offset_x, PointLT.Y);
                if (CaptureWidth < 0) // 左右翻转
                {
                    PointLT = new Point(PointRB.X, PointLT.Y);
                    PointRB = new Point(temp.X, PointRB.Y);
                    hitType = CaptrueHitType.Right;
                }
            }
            else if (hitType == CaptrueHitType.InPlace)
            {
                PointLT = new Point(PointLT.X + offset_x, PointLT.Y + offset_y);
                PointRB = new Point(PointRB.X + offset_x, PointRB.Y + offset_y);
            }
            Draw();
        }
        private void Draw(Graphics graphics = null)
        {
            using (Bitmap bmp = (Bitmap)ScreenCapture.Clone())
            {
                using(Graphics g = Graphics.FromImage(bmp))
                {
                    // 画透明遮罩层
                    g.FillRectangle(brush_mask, 0, 0, bmp.Width, bmp.Height);

                    if (captureRect.CanDraw)
                    {
                        // 没有异或笔,只能重画一次被框选的范围, 覆盖遮罩层
                        g.DrawImage(ScreenCapture, captureRect.CaptureRect, PointLT.X, PointLT.Y, CaptureWidth, CaptureHeight, GraphicsUnit.Pixel);
                        // 画矩形
                        captureRect.Draw(g, LineColor);
                        // 画文字
                        CaptrueTitle.Draw(g, Brushes.White, brush_info, Font, captureRect);
                    }
                }
                if (graphics == null)
                {
                    using(Graphics g = this.CreateGraphics())
                    {
                        g.DrawImage(bmp, 0, 0);
                    }
                }
                else
                {
                    graphics.DrawImage(bmp, 0, 0);
                }
            }
        }
        private void FScreen_Load(object sender, EventArgs e)
        {
            this.Left = Screen.AllScreens[ScreenIndex].WorkingArea.X;
            this.WindowState = FormWindowState.Maximized;
        }
        private void CopyScreen()
        {
            ScreenCapture = new Bitmap(Screen.AllScreens[ScreenIndex].Bounds.Width, Screen.AllScreens[ScreenIndex].Bounds.Height);
            using (Graphics g = Graphics.FromImage(ScreenCapture))
            {
                g.CopyFromScreen(new Point(Screen.AllScreens[ScreenIndex].WorkingArea.X, 0), new Point(0, 0), Screen.AllScreens[ScreenIndex].Bounds.Size);
            }
        }
        private void FScreen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (captureRect.PointIn(e.Location))
            {
                using (var target = new Bitmap(CaptureWidth, CaptureHeight))
                {
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(ScreenCapture, new Rectangle(0, 0, target.Width, target.Height), PointLT.X, PointLT.Y, target.Width, target.Height, GraphicsUnit.Pixel);
                    }

                    if (SaveToClipboard)
                    {
                        SaveClipboard(target);
                    }

                    if (SaveToFolder && !string.IsNullOrEmpty(Folder))
                    {
                        SaveBimap(target);
                    }

                    this.Close();
                }
            }
        }
        private void SaveClipboard(Bitmap image)
        {
            if (Transform && TransformWidth > 0 && TransformHeight > 0)
            { 
                using(var target = new Bitmap(image, TransformWidth, TransformHeight))
                {
                    Clipboard.SetImage(target);
                }
            }
            else
            {
                Clipboard.SetImage(image);
            }
        }
        private void SaveBimap(Bitmap image)
        {
            if (SaveToFolder && !string.IsNullOrEmpty(Folder))
            {
                if (!Directory.Exists(Folder))
                {
                    Directory.CreateDirectory(Folder);
                }
                var path = Path.Combine(Folder, $"{DateTime.Now:yyMMddHHmmss}.jpg");

                if (Transform && TransformWidth > 0 && TransformHeight > 0)
                {
                    using (var target = new Bitmap(image, TransformWidth, TransformHeight))
                    {
                        target.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                else
                {
                    image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
        private void FScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            brush_mask.Dispose();
            brush_info.Dispose();
        }
        private void FScreen_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }
    }    
}
