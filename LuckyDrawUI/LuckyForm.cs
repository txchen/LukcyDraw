using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuckyDrawUI
{
    public partial class LuckyForm : Form
    {
        private Status _status = Status.Stopped;
        private const string Title = "Lucky... ";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            luckyPictureBox.Location = new Point(
                (this.Width - luckyPictureBox.Width) / 2,
                (this.Height - luckyPictureBox.Height) / 2
                );
        }

        public LuckyForm(int picWidth, int picHeight, int interval, Image bgImage)
        {
            InitializeComponent();
            luckyPictureBox.Height = picHeight;
            luckyPictureBox.Width = picWidth;
            timer1.Interval = interval;
            if (bgImage != null)
            {
                this.BackgroundImage = bgImage;
            }
            luckyPictureBox.Hide();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Close();
                        break;
                    case Keys.Enter:
                    case Keys.Space:
                        KeyEntered();
                        break;
                }

            }
            return false;
        }

        private void KeyEntered()
        {
            if (_status == Status.Flashing)
            {
                // stop and celebrate
                _status = Status.Celebrating;
                timer1.Stop();
                // show full picture
                luckyPictureBox.Load(LuckyCore.CurrentPicUrl);
                LuckyCore.Celebrate();
            }
            else
            {
                // start drawing
                _status = Status.Flashing;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LuckyCore.NextRand();
            luckyPictureBox.Image = new Bitmap(LuckyCore.CurrentPicThumb);
            luckyPictureBox.Show();
            this.Text = Title + LuckyCore.CurrentPicUrl;
        }
    }
}
