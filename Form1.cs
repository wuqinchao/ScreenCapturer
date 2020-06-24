using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenCapturer
{
    public partial class Form1 : Form
    {
        List<FScreen> fcaptures = new List<FScreen>(); 
        private Color LineColor = Color.Red;
        private Hotkey hotkey = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_capture_Click(object sender, EventArgs e)
        {
            StartCapture();
        }
        private void StartCapture()
        {
            if (fcaptures.Count > 0) return;
            if (chk_save_to.Checked && string.IsNullOrEmpty(t_folder.Text))
            {
                MessageBox.Show("请设置自动保存的目录");
                return;
            }
            CloseChild();
            for (var i = 0; i< Screen.AllScreens.Length; i++)
            {
                fcaptures.Add(CaptureScreen(i));
            }            
        }

        private void CloseChild()
        {
            if (fcaptures.Count == 0) return;
            while(fcaptures.Count>0)
            {
                fcaptures[0].Close();
            }
            fcaptures.Clear();
        }

        private FScreen CaptureScreen(int index)
        {
            var fcapture = new FScreen(index);

            fcapture.SaveToClipboard = chk_save_clipboard.Checked;

            fcapture.SaveToFolder = chk_save_to.Checked;
            fcapture.Folder = t_folder.Text;

            fcapture.FixRect = t_fix_rect.Checked;
            fcapture.FixWidth = decimal.ToInt32(t_fix_width.Value);
            fcapture.FixHeight = decimal.ToInt32(t_fix_height.Value);

            fcapture.Transform = chk_transform.Checked;
            fcapture.TransformWidth = decimal.ToInt32(t_trans_width.Value);
            fcapture.TransformHeight = decimal.ToInt32(t_trans_height.Value);

            fcapture.LineColor = LineColor;
            fcapture.ShowInTaskbar = false;

            fcapture.FormClosed += Fcapture_FormClosed;
            fcapture.Show();

            return fcapture;
        }
        private void Fcapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(fcaptures.Contains(sender))
            {
                fcaptures.Remove((FScreen)sender);
            }
            CloseChild();
            FScreen.ClearTouchID();
        }
        private void t_fix_rect_CheckedChanged(object sender, EventArgs e)
        {
            if(fcaptures.Count > 0)
            {
                fcaptures.ForEach(x => x.FixRect = t_fix_rect.Checked);
            }
        }
        private void btn_folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                folder.ShowNewFolderButton = true;
                if (folder.ShowDialog() != DialogResult.OK) return;
                t_folder.Text = folder.SelectedPath;
                if (fcaptures.Count > 0)
                {
                    fcaptures.ForEach(x => x.Folder = folder.SelectedPath);
                }
            }
        }
        private void chk_save_to_CheckedChanged(object sender, EventArgs e)
        {
            btn_folder.Enabled = chk_save_to.Checked;
        }
        private void chk_save_clipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (fcaptures.Count > 0)
            {
                fcaptures.ForEach(x => x.SaveToClipboard = chk_save_clipboard.Checked);
            }
        }
        private void chk_transform_CheckedChanged(object sender, EventArgs e)
        {
            if (fcaptures.Count > 0)
            {
                fcaptures.ForEach(x => x.Transform = chk_transform.Checked);
            }
        }
        private void btn_color_Click(object sender, EventArgs e)
        {
            using(ColorDialog f = new ColorDialog())
            {
                f.Color = LineColor;
                if(f.ShowDialog() == DialogResult.OK)
                {
                    t_color.BackColor = LineColor = f.Color;
                    if (fcaptures.Count > 0)
                    {
                        fcaptures.ForEach(x => x.LineColor = f.Color);
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hotkey = new Hotkey()
            {
                Modifiers = (Keys)393216, // CTRL+ALT
                Key = Keys.X,
                Handle = this.Handle,
            };
            hotkey.OnHits += Hotkey_OnHits;
            hotkey.Start();
        }
        private void Hotkey_OnHits(object sender, EventArgs e)
        {
            if(fcaptures.Count == 0)
            {
                StartCapture();
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotkey.Stop();
        }
    }
}
