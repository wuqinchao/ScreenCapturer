namespace ScreenCapturer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_capture = new System.Windows.Forms.Button();
            this.t_fix_rect = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_fix_width = new System.Windows.Forms.NumericUpDown();
            this.t_fix_height = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_save_to = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t_folder = new System.Windows.Forms.TextBox();
            this.btn_folder = new System.Windows.Forms.Button();
            this.chk_save_clipboard = new System.Windows.Forms.CheckBox();
            this.chk_transform = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.t_trans_width = new System.Windows.Forms.NumericUpDown();
            this.t_trans_height = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.t_color = new System.Windows.Forms.Panel();
            this.btn_color = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t_fix_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_fix_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_trans_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_trans_height)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_capture
            // 
            this.btn_capture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_capture.Location = new System.Drawing.Point(12, 352);
            this.btn_capture.Name = "btn_capture";
            this.btn_capture.Size = new System.Drawing.Size(306, 53);
            this.btn_capture.TabIndex = 0;
            this.btn_capture.Text = "截图";
            this.btn_capture.UseVisualStyleBackColor = true;
            this.btn_capture.Click += new System.EventHandler(this.btn_capture_Click);
            // 
            // t_fix_rect
            // 
            this.t_fix_rect.AutoSize = true;
            this.t_fix_rect.Location = new System.Drawing.Point(12, 22);
            this.t_fix_rect.Name = "t_fix_rect";
            this.t_fix_rect.Size = new System.Drawing.Size(72, 16);
            this.t_fix_rect.TabIndex = 1;
            this.t_fix_rect.Text = "固定大小";
            this.t_fix_rect.UseVisualStyleBackColor = true;
            this.t_fix_rect.CheckedChanged += new System.EventHandler(this.t_fix_rect_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "固定宽：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "固定高：";
            // 
            // t_fix_width
            // 
            this.t_fix_width.Location = new System.Drawing.Point(71, 52);
            this.t_fix_width.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.t_fix_width.Name = "t_fix_width";
            this.t_fix_width.Size = new System.Drawing.Size(50, 21);
            this.t_fix_width.TabIndex = 3;
            this.t_fix_width.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // t_fix_height
            // 
            this.t_fix_height.Location = new System.Drawing.Point(238, 52);
            this.t_fix_height.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.t_fix_height.Name = "t_fix_height";
            this.t_fix_height.Size = new System.Drawing.Size(50, 21);
            this.t_fix_height.TabIndex = 3;
            this.t_fix_height.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "像素";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "像素";
            // 
            // chk_save_to
            // 
            this.chk_save_to.AutoSize = true;
            this.chk_save_to.Location = new System.Drawing.Point(12, 188);
            this.chk_save_to.Name = "chk_save_to";
            this.chk_save_to.Size = new System.Drawing.Size(108, 16);
            this.chk_save_to.TabIndex = 5;
            this.chk_save_to.Text = "自动保存到目录";
            this.chk_save_to.UseVisualStyleBackColor = true;
            this.chk_save_to.CheckedChanged += new System.EventHandler(this.chk_save_to_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "目录：";
            // 
            // t_folder
            // 
            this.t_folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t_folder.Location = new System.Drawing.Point(58, 217);
            this.t_folder.Multiline = true;
            this.t_folder.Name = "t_folder";
            this.t_folder.ReadOnly = true;
            this.t_folder.Size = new System.Drawing.Size(260, 58);
            this.t_folder.TabIndex = 6;
            // 
            // btn_folder
            // 
            this.btn_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_folder.Enabled = false;
            this.btn_folder.Location = new System.Drawing.Point(243, 281);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(75, 23);
            this.btn_folder.TabIndex = 7;
            this.btn_folder.Text = "选择目录";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // chk_save_clipboard
            // 
            this.chk_save_clipboard.AutoSize = true;
            this.chk_save_clipboard.Checked = true;
            this.chk_save_clipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_save_clipboard.Location = new System.Drawing.Point(12, 155);
            this.chk_save_clipboard.Name = "chk_save_clipboard";
            this.chk_save_clipboard.Size = new System.Drawing.Size(96, 16);
            this.chk_save_clipboard.TabIndex = 5;
            this.chk_save_clipboard.Text = "保存到剪切板";
            this.chk_save_clipboard.UseVisualStyleBackColor = true;
            this.chk_save_clipboard.CheckedChanged += new System.EventHandler(this.chk_save_clipboard_CheckedChanged);
            // 
            // chk_transform
            // 
            this.chk_transform.AutoSize = true;
            this.chk_transform.Location = new System.Drawing.Point(12, 89);
            this.chk_transform.Name = "chk_transform";
            this.chk_transform.Size = new System.Drawing.Size(132, 16);
            this.chk_transform.TabIndex = 1;
            this.chk_transform.Text = "保存时转换截图大小";
            this.chk_transform.UseVisualStyleBackColor = true;
            this.chk_transform.CheckedChanged += new System.EventHandler(this.chk_transform_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "宽：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "高：";
            // 
            // t_trans_width
            // 
            this.t_trans_width.Location = new System.Drawing.Point(71, 114);
            this.t_trans_width.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.t_trans_width.Name = "t_trans_width";
            this.t_trans_width.Size = new System.Drawing.Size(50, 21);
            this.t_trans_width.TabIndex = 3;
            this.t_trans_width.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // t_trans_height
            // 
            this.t_trans_height.Location = new System.Drawing.Point(238, 114);
            this.t_trans_height.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.t_trans_height.Name = "t_trans_height";
            this.t_trans_height.Size = new System.Drawing.Size(50, 21);
            this.t_trans_height.TabIndex = 3;
            this.t_trans_height.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "像素";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "像素";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "线条颜色：";
            // 
            // t_color
            // 
            this.t_color.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.t_color.BackColor = System.Drawing.Color.Red;
            this.t_color.Location = new System.Drawing.Point(78, 323);
            this.t_color.Name = "t_color";
            this.t_color.Size = new System.Drawing.Size(151, 12);
            this.t_color.TabIndex = 9;
            // 
            // btn_color
            // 
            this.btn_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_color.Location = new System.Drawing.Point(243, 317);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(75, 23);
            this.btn_color.TabIndex = 10;
            this.btn_color.Text = "选择颜色";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label11.Location = new System.Drawing.Point(87, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "固定大小选中时，不能调整大小";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 417);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.t_color);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.t_folder);
            this.Controls.Add(this.chk_save_clipboard);
            this.Controls.Add(this.chk_save_to);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.t_trans_height);
            this.Controls.Add(this.t_trans_width);
            this.Controls.Add(this.t_fix_height);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t_fix_width);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_transform);
            this.Controls.Add(this.t_fix_rect);
            this.Controls.Add(this.btn_capture);
            this.Name = "Form1";
            this.Text = "屏幕截图";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_fix_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_fix_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_trans_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_trans_height)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_capture;
        private System.Windows.Forms.CheckBox t_fix_rect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown t_fix_width;
        private System.Windows.Forms.NumericUpDown t_fix_height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_save_to;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_folder;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.CheckBox chk_save_clipboard;
        private System.Windows.Forms.CheckBox chk_transform;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown t_trans_width;
        private System.Windows.Forms.NumericUpDown t_trans_height;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel t_color;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Label label11;
    }
}

