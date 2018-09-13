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
            this.remotesPathTB = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.xmlPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.remotesBrowseBtn = new System.Windows.Forms.Button();
            this.remotePicDialog = new System.Windows.Forms.OpenFileDialog();
            this.TvPowerCB = new System.Windows.Forms.CheckBox();
            this.AvBtnCB = new System.Windows.Forms.CheckBox();
            this.TvVolUpCB = new System.Windows.Forms.CheckBox();
            this.TvVolDownCB = new System.Windows.Forms.CheckBox();
            this.muteBtnCB = new System.Windows.Forms.CheckBox();
            this.validationCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tinyPngCompressionCB = new System.Windows.Forms.CheckBox();
            this.tinyPngCB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apiKeyTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PythonPathTB = new System.Windows.Forms.TextBox();
            this.pythonPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonsGB = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttons2GB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.undoCB = new System.Windows.Forms.ComboBox();
            this.onlyTinyPNGCB = new System.Windows.Forms.CheckBox();
            this.currRemoteNameLabel = new System.Windows.Forms.Label();
            this.tinyPngCB.SuspendLayout();
            this.buttonsGB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.buttons2GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(177, 273);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 37);
            this.goBtn.TabIndex = 0;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.Go_Click);
            // 
            // remotesPathTB
            // 
            this.remotesPathTB.AllowDrop = true;
            this.remotesPathTB.Location = new System.Drawing.Point(97, 22);
            this.remotesPathTB.Name = "remotesPathTB";
            this.remotesPathTB.Size = new System.Drawing.Size(229, 20);
            this.remotesPathTB.TabIndex = 1;
            this.remotesPathTB.TextChanged += new System.EventHandler(this.XmlPathTB_TextChanged);
            this.remotesPathTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.XmlPathDropHandler);
            this.remotesPathTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterHandler);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 26);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(79, 13);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Remote/s Path";
            // 
            // xmlPathDialog
            // 
            this.xmlPathDialog.FileName = "xmlPathDialog";
            this.xmlPathDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // remotesBrowseBtn
            // 
            this.remotesBrowseBtn.Location = new System.Drawing.Point(331, 15);
            this.remotesBrowseBtn.Name = "remotesBrowseBtn";
            this.remotesBrowseBtn.Size = new System.Drawing.Size(83, 31);
            this.remotesBrowseBtn.TabIndex = 5;
            this.remotesBrowseBtn.Text = "Browse...";
            this.remotesBrowseBtn.UseVisualStyleBackColor = true;
            this.remotesBrowseBtn.Click += new System.EventHandler(this.Browse_Xml_Path_clicked);
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
            this.validationCB.BackColor = System.Drawing.Color.White;
            this.validationCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.validationCB.FormattingEnabled = true;
            this.validationCB.Location = new System.Drawing.Point(108, 24);
            this.validationCB.Name = "validationCB";
            this.validationCB.Size = new System.Drawing.Size(59, 21);
            this.validationCB.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Validation Button";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(418, 301);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "LOG";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked_1);
            // 
            // tinyPngCompressionCB
            // 
            this.tinyPngCompressionCB.AutoSize = true;
            this.tinyPngCompressionCB.Location = new System.Drawing.Point(227, 172);
            this.tinyPngCompressionCB.Name = "tinyPngCompressionCB";
            this.tinyPngCompressionCB.Size = new System.Drawing.Size(15, 14);
            this.tinyPngCompressionCB.TabIndex = 22;
            this.tinyPngCompressionCB.UseVisualStyleBackColor = true;
            this.tinyPngCompressionCB.CheckedChanged += new System.EventHandler(this.tinyPngCompressionCB_CheckedChanged);
            // 
            // tinyPngCB
            // 
            this.tinyPngCB.Controls.Add(this.label2);
            this.tinyPngCB.Controls.Add(this.apiKeyTB);
            this.tinyPngCB.Controls.Add(this.label5);
            this.tinyPngCB.Controls.Add(this.PythonPathTB);
            this.tinyPngCB.Enabled = false;
            this.tinyPngCB.Location = new System.Drawing.Point(219, 172);
            this.tinyPngCB.Name = "tinyPngCB";
            this.tinyPngCB.Size = new System.Drawing.Size(216, 87);
            this.tinyPngCB.TabIndex = 21;
            this.tinyPngCB.TabStop = false;
            this.tinyPngCB.Text = "      Pic Compressor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tiny API Key";
            // 
            // apiKeyTB
            // 
            this.apiKeyTB.AllowDrop = true;
            this.apiKeyTB.Location = new System.Drawing.Point(82, 53);
            this.apiKeyTB.Name = "apiKeyTB";
            this.apiKeyTB.Size = new System.Drawing.Size(117, 20);
            this.apiKeyTB.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Python Path";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // PythonPathTB
            // 
            this.PythonPathTB.AllowDrop = true;
            this.PythonPathTB.Location = new System.Drawing.Point(82, 23);
            this.PythonPathTB.Name = "PythonPathTB";
            this.PythonPathTB.Size = new System.Drawing.Size(117, 20);
            this.PythonPathTB.TabIndex = 22;
            // 
            // pythonPathDialog
            // 
            this.pythonPathDialog.FileName = "pythonPathDialog";
            // 
            // buttonsGB
            // 
            this.buttonsGB.Controls.Add(this.TvPowerCB);
            this.buttonsGB.Controls.Add(this.AvBtnCB);
            this.buttonsGB.Controls.Add(this.TvVolUpCB);
            this.buttonsGB.Controls.Add(this.TvVolDownCB);
            this.buttonsGB.Controls.Add(this.muteBtnCB);
            this.buttonsGB.Location = new System.Drawing.Point(14, 74);
            this.buttonsGB.Name = "buttonsGB";
            this.buttonsGB.Size = new System.Drawing.Size(421, 87);
            this.buttonsGB.TabIndex = 24;
            this.buttonsGB.TabStop = false;
            this.buttonsGB.Text = "Add These Buttons";
            this.buttonsGB.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pathLabel);
            this.groupBox2.Controls.Add(this.remotesPathTB);
            this.groupBox2.Controls.Add(this.remotesBrowseBtn);
            this.groupBox2.Location = new System.Drawing.Point(14, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 56);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // buttons2GB
            // 
            this.buttons2GB.Controls.Add(this.label1);
            this.buttons2GB.Controls.Add(this.undoCB);
            this.buttons2GB.Controls.Add(this.label3);
            this.buttons2GB.Controls.Add(this.validationCB);
            this.buttons2GB.Location = new System.Drawing.Point(14, 172);
            this.buttons2GB.Name = "buttons2GB";
            this.buttons2GB.Size = new System.Drawing.Size(192, 87);
            this.buttons2GB.TabIndex = 25;
            this.buttons2GB.TabStop = false;
            this.buttons2GB.Text = "Buttons";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Undo Button";
            // 
            // undoCB
            // 
            this.undoCB.BackColor = System.Drawing.Color.White;
            this.undoCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.undoCB.FormattingEnabled = true;
            this.undoCB.Location = new System.Drawing.Point(108, 53);
            this.undoCB.Name = "undoCB";
            this.undoCB.Size = new System.Drawing.Size(59, 21);
            this.undoCB.TabIndex = 15;
            // 
            // onlyTinyPNGCB
            // 
            this.onlyTinyPNGCB.AutoSize = true;
            this.onlyTinyPNGCB.Location = new System.Drawing.Point(14, 291);
            this.onlyTinyPNGCB.Name = "onlyTinyPNGCB";
            this.onlyTinyPNGCB.Size = new System.Drawing.Size(87, 17);
            this.onlyTinyPNGCB.TabIndex = 30;
            this.onlyTinyPNGCB.Text = "only tinyPNG";
            this.onlyTinyPNGCB.UseVisualStyleBackColor = true;
            this.onlyTinyPNGCB.CheckedChanged += new System.EventHandler(this.onlyTinyPNGCB_CheckedChanged);
            // 
            // currRemoteNameLabel
            // 
            this.currRemoteNameLabel.AutoSize = true;
            this.currRemoteNameLabel.Font = new System.Drawing.Font("Arial", 15F);
            this.currRemoteNameLabel.ForeColor = System.Drawing.Color.Red;
            this.currRemoteNameLabel.Location = new System.Drawing.Point(279, 277);
            this.currRemoteNameLabel.Name = "currRemoteNameLabel";
            this.currRemoteNameLabel.Size = new System.Drawing.Size(0, 23);
            this.currRemoteNameLabel.TabIndex = 31;
            // 
            // PathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.currRemoteNameLabel);
            this.Controls.Add(this.onlyTinyPNGCB);
            this.Controls.Add(this.tinyPngCompressionCB);
            this.Controls.Add(this.buttons2GB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonsGB);
            this.Controls.Add(this.tinyPngCB);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.goBtn);
            this.Name = "PathForm";
            this.Text = "Layout Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tinyPngCB.ResumeLayout(false);
            this.tinyPngCB.PerformLayout();
            this.buttonsGB.ResumeLayout(false);
            this.buttonsGB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.buttons2GB.ResumeLayout(false);
            this.buttons2GB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RemotePathDropHandler(object sender, DragEventArgs e)
        {
            //remotePathTB.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
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
            remotesPathTB.Text = ((string[]) e.Data.GetData(DataFormats.FileDrop, false))[0];

            string[] fileData = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < fileData.Length; i++)
            {
                Console.WriteLine(fileData[i]);
            }
        }



        protected void setCBItems()
        {
            foreach (string btnName in Enum.GetNames(typeof(VirtualKeyCode))) { 
                this.validationCB.Items.Add(btnName);
                this.undoCB.Items.Add(btnName);
            }
        }


        #endregion

        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox remotesPathTB;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.OpenFileDialog xmlPathDialog;
        private System.Windows.Forms.Button remotesBrowseBtn;
        private System.Windows.Forms.OpenFileDialog remotePicDialog;
        private System.Windows.Forms.CheckBox TvPowerCB;
        private System.Windows.Forms.CheckBox AvBtnCB;
        private System.Windows.Forms.CheckBox TvVolUpCB;
        private System.Windows.Forms.CheckBox TvVolDownCB;
        private System.Windows.Forms.CheckBox muteBtnCB;
        private System.Windows.Forms.ComboBox validationCB;
        private System.Windows.Forms.Label label3;
        private LinkLabel linkLabel1;
        internal CheckBox tinyPngCompressionCB;
        private GroupBox tinyPngCB;
        private Label label5;
        private TextBox PythonPathTB;
        private OpenFileDialog pythonPathDialog;
        private GroupBox buttonsGB;
        private GroupBox groupBox2;
        private GroupBox buttons2GB;
        private Label label1;
        private ComboBox undoCB;
        private Label label2;
        private TextBox apiKeyTB;
        private CheckBox onlyTinyPNGCB;
        private Label currRemoteNameLabel;
    }
}

