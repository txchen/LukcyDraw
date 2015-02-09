using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace LuckyDrawUI
{
    public enum Status
    {
        Stopped,
        Flashing,
        Celebrating,
    }
    public partial class Form1 : Form
    {
        List<string> _pictures = new List<string>();
        LuckyConfig _config = new LuckyConfig();

        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = _config;
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbPictureFolder.Text = folderBrowserDialog1.SelectedPath;
                LoadPictures(folderBrowserDialog1.SelectedPath);
                if (_pictures.Count > 0)
                {
                    PrepareForStart();
                }
            }
        }

        private void PrepareForStart()
        {
            this.Text = Title + "Preloading thumbnails";
            btnChooseFolder.Enabled = false;
            Thread th = new Thread(() =>
            {
                LuckyCore.LoadAndStart(_pictures, _config.ThumbnailWidth, _config.ThumbnailHeight);
                this.Invoke(new MethodInvoker(() =>
                    {
                        btnChooseFolder.Enabled = true;
                        btnStart.Enabled = true;
                        UpdateStatistics();
                    }));
            });
            th.Start();
        }

        private void LoadPictures(string path)
        {
            string[] pictures = Directory.GetFiles(path, "*.jpg");
            lvPicList.Items.Clear();
            _pictures = new List<string>();
            foreach (var pic in pictures)
            {
                ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(pic), pic);
                lvi.SubItems.Add(pic);
                lvi.Tag = pic;
                lvPicList.Items.Add(lvi);
                _pictures.Add(pic);
            }
        }

        private void lvPicList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvPicList.SelectedItems.Count > 0)
            {
                string picToLoad = lvPicList.SelectedItems[0].Tag.ToString();
                if (pictureBox1.Tag == null || pictureBox1.Tag.ToString() != picToLoad)
                {
                    pictureBox1.Load(lvPicList.SelectedItems[0].Tag.ToString());
                    pictureBox1.Tag = picToLoad;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LuckyForm luckyF = new LuckyForm(_config.PictureWidth, _config.PictureHeight, _config.IntervalInMs, _backGroundImage);
            luckyF.ShowDialog();
            UpdateStatistics();
        }

        private const string Title = "LuckyDraw - ";
        private void UpdateStatistics()
        {
            this.Text = String.Format(Title + "Total {0} Got {1}", LuckyCore.TotalCount, LuckyCore.LuckyCount);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LuckyCore.Reset();
            UpdateStatistics();
        }

        private Image _backGroundImage = null;
        private void btnChooseBG_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbBackFileName.Text = openFileDialog1.FileName;
                try
                {
                    _backGroundImage = Image.FromFile(tbBackFileName.Text);
                }
                catch { }
            }
        }
    }
}
