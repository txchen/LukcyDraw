﻿namespace LuckyDrawUI
{
    partial class LuckyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.luckyPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.luckyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // luckyPictureBox
            // 
            this.luckyPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.luckyPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.luckyPictureBox.Location = new System.Drawing.Point(77, 65);
            this.luckyPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.luckyPictureBox.Name = "luckyPictureBox";
            this.luckyPictureBox.Size = new System.Drawing.Size(451, 375);
            this.luckyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.luckyPictureBox.TabIndex = 0;
            this.luckyPictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LuckyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(623, 513);
            this.Controls.Add(this.luckyPictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LuckyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LuckyForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.luckyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox luckyPictureBox;
        private System.Windows.Forms.Timer timer1;
    }
}