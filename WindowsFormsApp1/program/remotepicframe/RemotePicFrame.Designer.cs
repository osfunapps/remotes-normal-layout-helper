using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.program.example
{
    partial class RemotePicFrame
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
            this.remotePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.remotePic)).BeginInit();
            this.SuspendLayout();
            // 
            // remotePic
            // 
            this.remotePic.ErrorImage = null;
            this.remotePic.InitialImage = null;
            this.remotePic.Location = new System.Drawing.Point(0, -1);
            this.remotePic.Name = "pictureBox1";
            this.remotePic.Size = new System.Drawing.Size(463, 1700);
            this.remotePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.remotePic.TabIndex = 2;
            this.remotePic.TabStop = false;
            this.remotePic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Remote_Pic_MouseDown);
            this.remotePic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Remote_Pic_MouseMove);
            this.remotePic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Remote_Pic_MouseUp);
            this.remotePic.Paint += new PaintEventHandler(this.Remote_Pic_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(335, 313);
            this.Controls.Add(this.remotePic);
            this.Name = "Form1";

            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.remotePic)).EndInit();
            this.ResumeLayout(false);
            this.TopMost = false;
            this.FormClosing += new FormClosingEventHandler(this.onFormClosing);
            this.Shown += new EventHandler(this.FormShown);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox remotePic;
    }
}