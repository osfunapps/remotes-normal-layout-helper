using System;
using System.Windows.Forms;
using LayoutProject.program;
using WindowsFormsApp1.program.tools;
namespace LayoutProject
{
    partial class PathForm : Form
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
            this.goBtn = new System.Windows.Forms.Button();
            this.xmlPathTB = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.remotePathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xmlPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.XmlBrowseBtn = new System.Windows.Forms.Button();
            this.RemotePicBrowseBtn = new System.Windows.Forms.Button();
            this.remotePicDialog = new System.Windows.Forms.OpenFileDialog();
            this.TvPowerCB = new System.Windows.Forms.CheckBox();
            this.AvBtnCB = new System.Windows.Forms.CheckBox();
            this.TvVolUpCB = new System.Windows.Forms.CheckBox();
            this.TvVolDownCB = new System.Windows.Forms.CheckBox();
            this.muteBtnCB = new System.Windows.Forms.CheckBox();
            this.validationCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startOverCB = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.removeTvKeysCB = new System.Windows.Forms.CheckBox();
            this.tinyPngCompressionCB = new System.Windows.Forms.CheckBox();
            this.tinyPngCB = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.apiKeyTB = new System.Windows.Forms.TextBox();
            this.pythonPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tinyPngCB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(214, 379);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 37);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.Go_Click);
            // 
            // xmlPathTB
            // 
            this.xmlPathTB.AllowDrop = true;
            this.xmlPathTB.Location = new System.Drawing.Point(86, 16);
            this.xmlPathTB.Name = "xmlPathTB";
            this.xmlPathTB.Size = new System.Drawing.Size(266, 20);
            this.xmlPathTB.TabIndex = 1;
            this.xmlPathTB.TextChanged += new System.EventHandler(this.XmlPathTB_TextChanged);
            this.xmlPathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.XmlPathDropHandler);
            this.xmlPathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 19);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(54, 13);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "XML Path";
            // 
            // remotePathTB
            // 
            this.remotePathTB.AllowDrop = true;
            this.remotePathTB.Location = new System.Drawing.Point(86, 46);
            this.remotePathTB.Name = "remotePathTB";
            this.remotePathTB.Size = new System.Drawing.Size(266, 20);
            this.remotePathTB.TabIndex = 3;
            this.remotePathTB.TextChanged += new System.EventHandler(this.remotePathTB_TextChanged);
            this.remotePathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.RemotePathDropHandler);
            this.remotePathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remote Path";
            // 
            // xmlPathDialog
            // 
            this.xmlPathDialog.FileName = "xmlPathDialog";
            this.xmlPathDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // XmlBrowseBtn
            // 
            this.XmlBrowseBtn.Location = new System.Drawing.Point(360, 16);
            this.XmlBrowseBtn.Name = "XmlBrowseBtn";
            this.XmlBrowseBtn.Size = new System.Drawing.Size(75, 20);
            this.XmlBrowseBtn.TabIndex = 5;
            this.XmlBrowseBtn.Text = "Browse...";
            this.XmlBrowseBtn.UseVisualStyleBackColor = true;
            this.XmlBrowseBtn.Click += new System.EventHandler(this.Browse_Xml_Path_clicked);
            // 
            // RemotePicBrowseBtn
            // 
            this.RemotePicBrowseBtn.Location = new System.Drawing.Point(360, 45);
            this.RemotePicBrowseBtn.Name = "RemotePicBrowseBtn";
            this.RemotePicBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.RemotePicBrowseBtn.TabIndex = 6;
            this.RemotePicBrowseBtn.Text = "Browse...";
            this.RemotePicBrowseBtn.UseVisualStyleBackColor = true;
            this.RemotePicBrowseBtn.Click += new System.EventHandler(this.Browse_Remote_Pic_Path_clicked);
            // 
            // remotePicDialog
            // 
            this.remotePicDialog.FileName = "openFileDialog1";
            this.remotePicDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.remotePicDialog_FileOk);
            // 
            // TvPowerCB
            // 
            this.TvPowerCB.AutoSize = true;
            this.TvPowerCB.Checked = true;
            this.TvPowerCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TvPowerCB.Location = new System.Drawing.Point(39, 24);
            this.TvPowerCB.Name = "TvPowerCB";
            this.TvPowerCB.Size = new System.Drawing.Size(107, 17);
            this.TvPowerCB.TabIndex = 7;
            this.TvPowerCB.Text = "TV Power Button";
            this.TvPowerCB.UseVisualStyleBackColor = true;
            // 
            // AvBtnCB
            // 
            this.AvBtnCB.AutoSize = true;
            this.AvBtnCB.Checked = true;
            this.AvBtnCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AvBtnCB.Location = new System.Drawing.Point(39, 55);
            this.AvBtnCB.Name = "AvBtnCB";
            this.AvBtnCB.Size = new System.Drawing.Size(94, 17);
            this.AvBtnCB.TabIndex = 8;
            this.AvBtnCB.Text = "Source Button";
            this.AvBtnCB.UseVisualStyleBackColor = true;
            // 
            // TvVolUpCB
            // 
            this.TvVolUpCB.AutoSize = true;
            this.TvVolUpCB.Checked = true;
            this.TvVolUpCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TvVolUpCB.Location = new System.Drawing.Point(167, 19);
            this.TvVolUpCB.Name = "TvVolUpCB";
            this.TvVolUpCB.Size = new System.Drawing.Size(129, 17);
            this.TvVolUpCB.TabIndex = 9;
            this.TvVolUpCB.Text = "TV Volume Up Button";
            this.TvVolUpCB.UseVisualStyleBackColor = true;
            // 
            // TvVolDownCB
            // 
            this.TvVolDownCB.AutoSize = true;
            this.TvVolDownCB.Checked = true;
            this.TvVolDownCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TvVolDownCB.Location = new System.Drawing.Point(167, 55);
            this.TvVolDownCB.Name = "TvVolDownCB";
            this.TvVolDownCB.Size = new System.Drawing.Size(143, 17);
            this.TvVolDownCB.TabIndex = 10;
            this.TvVolDownCB.Text = "TV Volume Down Button";
            this.TvVolDownCB.UseVisualStyleBackColor = true;
            // 
            // muteBtnCB
            // 
            this.muteBtnCB.AutoSize = true;
            this.muteBtnCB.Checked = true;
            this.muteBtnCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.muteBtnCB.Location = new System.Drawing.Point(319, 33);
            this.muteBtnCB.Name = "muteBtnCB";
            this.muteBtnCB.Size = new System.Drawing.Size(84, 17);
            this.muteBtnCB.TabIndex = 12;
            this.muteBtnCB.Text = "Mute Button";
            this.muteBtnCB.UseVisualStyleBackColor = true;
            // 
            // validationCB
            // 
            this.validationCB.FormattingEnabled = true;
            this.validationCB.Location = new System.Drawing.Point(137, 194);
            this.validationCB.Name = "validationCB";
            this.validationCB.Size = new System.Drawing.Size(242, 21);
            this.validationCB.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "With Validation Button";
            // 
            // startOverCB
            // 
            this.startOverCB.AutoSize = true;
            this.startOverCB.Location = new System.Drawing.Point(19, 226);
            this.startOverCB.Name = "startOverCB";
            this.startOverCB.Size = new System.Drawing.Size(142, 17);
            this.startOverCB.TabIndex = 16;
            this.startOverCB.Text = "Run over existing values";
            this.startOverCB.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(406, 403);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "LOG";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked_1);
            // 
            // removeTvKeysCB
            // 
            this.removeTvKeysCB.AutoSize = true;
            this.removeTvKeysCB.Location = new System.Drawing.Point(19, 249);
            this.removeTvKeysCB.Name = "removeTvKeysCB";
            this.removeTvKeysCB.Size = new System.Drawing.Size(135, 17);
            this.removeTvKeysCB.TabIndex = 18;
            this.removeTvKeysCB.Text = "Remove wrong tv keys";
            this.removeTvKeysCB.UseVisualStyleBackColor = true;
            // 
            // tinyPngCompressionCB
            // 
            this.tinyPngCompressionCB.AutoSize = true;
            this.tinyPngCompressionCB.Location = new System.Drawing.Point(19, 287);
            this.tinyPngCompressionCB.Name = "tinyPngCompressionCB";
            this.tinyPngCompressionCB.Size = new System.Drawing.Size(147, 17);
            this.tinyPngCompressionCB.TabIndex = 22;
            this.tinyPngCompressionCB.Text = "Add tiny png compression";
            this.tinyPngCompressionCB.UseVisualStyleBackColor = true;
            this.tinyPngCompressionCB.CheckedChanged += new System.EventHandler(this.tinyPngCompressionCB_CheckedChanged);
            // 
            // tinyPngCB
            // 
            this.tinyPngCB.Controls.Add(this.label5);
            this.tinyPngCB.Controls.Add(this.apiKeyTB);
            this.tinyPngCB.Enabled = false;
            this.tinyPngCB.Location = new System.Drawing.Point(14, 310);
            this.tinyPngCB.Name = "tinyPngCB";
            this.tinyPngCB.Size = new System.Drawing.Size(421, 63);
            this.tinyPngCB.TabIndex = 21;
            this.tinyPngCB.TabStop = false;
            this.tinyPngCB.Text = "Pic Compressor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "API Key";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // apiKeyTB
            // 
            this.apiKeyTB.AllowDrop = true;
            this.apiKeyTB.Location = new System.Drawing.Point(123, 26);
            this.apiKeyTB.Name = "apiKeyTB";
            this.apiKeyTB.Size = new System.Drawing.Size(242, 20);
            this.apiKeyTB.TabIndex = 22;
            // 
            // pythonPathDialog
            // 
            this.pythonPathDialog.FileName = "pythonPathDialog";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TvPowerCB);
            this.groupBox1.Controls.Add(this.AvBtnCB);
            this.groupBox1.Controls.Add(this.TvVolUpCB);
            this.groupBox1.Controls.Add(this.TvVolDownCB);
            this.groupBox1.Controls.Add(this.muteBtnCB);
            this.groupBox1.Location = new System.Drawing.Point(14, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 87);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add These Buttons";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tinyPngCompressionCB);
            this.Controls.Add(this.tinyPngCB);
            this.Controls.Add(this.removeTvKeysCB);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.startOverCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.validationCB);
            this.Controls.Add(this.RemotePicBrowseBtn);
            this.Controls.Add(this.XmlBrowseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remotePathTB);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.xmlPathTB);
            this.Controls.Add(this.goBtn);
            this.Name = "PathForm";
            this.Text = "Layout Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tinyPngCB.ResumeLayout(false);
            this.tinyPngCB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RemotePathDropHandler(object sender, DragEventArgs e)
        {
            remotePathTB.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        }

        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void XmlPathDropHandler(object sender, DragEventArgs e)
        {
            xmlPathTB.Text = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];

            string[] fileData = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < fileData.Length; i++)
            {
                Console.WriteLine(fileData[i]);
            }
        }



        protected void setValidationCBItems()
        {
            foreach (string btnName in Enum.GetNames(typeof(VirtualKeyCode)))
                this.validationCB.Items.Add(btnName);
        }


        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox xmlPathTB;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox remotePathTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog xmlPathDialog;
        private System.Windows.Forms.Button XmlBrowseBtn;
        private System.Windows.Forms.Button RemotePicBrowseBtn;
        private System.Windows.Forms.OpenFileDialog remotePicDialog;
        private System.Windows.Forms.CheckBox TvPowerCB;
        private System.Windows.Forms.CheckBox AvBtnCB;
        private System.Windows.Forms.CheckBox TvVolUpCB;
        private System.Windows.Forms.CheckBox TvVolDownCB;
        private System.Windows.Forms.CheckBox muteBtnCB;
        private System.Windows.Forms.ComboBox validationCB;
        private System.Windows.Forms.Label label3;
        private CheckBox startOverCB;
        private LinkLabel linkLabel1;
        private CheckBox removeTvKeysCB;
        internal CheckBox tinyPngCompressionCB;
        private GroupBox tinyPngCB;
        private Label label5;
        private TextBox apiKeyTB;
        private OpenFileDialog pythonPathDialog;
        private GroupBox groupBox1;
    }
}

