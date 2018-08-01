using LayoutProject.program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program;
using WindowsFormsApp1.program.tools.picturestools;
using WindowsFormsApp1.Properties;


namespace LayoutProject
{
    public partial class PathForm : Form, InitiatorCallBack, IPicCompressor, IXmlCleanerCallback
    {

        //instances
        private PicCompressor picCompressor;
        private Initiator initiator;

        //checkers params
        private static bool removeWrongTvKeys;
        private static string xmlPathStr;
        private static string remotePicPath;
        internal static bool startOver;
        private static string validationBtnName;
        private static string undoBtnName;

        //strings
        private string path1300;
        private string parentDirName;
        public static string file1300Path;
        private string file600Path;
        private XMLCleaner cleaner;
        private BackupHandler backupHandler;

        public PathForm()
        {
            setInstances();
            InitializeComponent();
            setValidationCBItems();
            loadPreviousParams();
        }

        private void loadPreviousParams()
        {
            apiKeyTB.Text = Settings.Default.APIKey;
            remotePathTB.Text = Settings.Default.remotePath;
            xmlPathTB.Text = Settings.Default.xmlPath;
            TvPowerCB.Checked = Settings.Default.tvBtn;
            AvBtnCB.Checked = Settings.Default.avBtn;
            TvVolUpCB.Checked = Settings.Default.volUpBtn;
            TvVolDownCB.Checked = Settings.Default.volDownBtn;
            muteBtnCB.Checked = Settings.Default.muteBtn;
            validationCB.Text = Settings.Default.validationBtn;
            startOverCB.Checked = Settings.Default.startOver;
            removeTvKeysCB.Checked = Settings.Default.removeTvKeys;
            tinyPngCompressionCB.Checked = Settings.Default.tinyPng;
        }


        private void setInstances()
        {
            initiator = new Initiator(this);
            picCompressor = new PicCompressor(this);
            cleaner = new XMLCleaner(this);
            backupHandler = new BackupHandler();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        internal CheckBox GetTvBtnCB()
        {
            return TvPowerCB;
        }

        internal CheckBox GetAvBtnCB()
        {
            return AvBtnCB;
        }

        internal CheckBox GetMuteBtnCB()
        {
            return muteBtnCB;
        }


        internal CheckBox GetVolUpCB()
        {
            return TvVolUpCB;
        }


        internal CheckBox GetVolDownCB()
        {
            return TvVolDownCB;
        }


        private void SetTvBtnsDict()
        {
            TvBtns tvBtnCB = new TvBtns();
            tvBtnCB.SetTvBtnsDict(this);
        }

        internal static string GetXmlPath()
        {
            return xmlPathStr;
        }

        internal static string getRemotePicPath()
        {
            return remotePicPath;
        }


        private void Browse_Xml_Path_clicked(object sender, EventArgs e)
        {
            xmlPathDialog.ShowDialog();
        }

        private void Browse_Remote_Pic_Path_clicked(object sender, EventArgs e)
        {
            remotePicDialog.ShowDialog();
        }

        private void remotePicDialog_FileOk(object sender, CancelEventArgs e)
        {
            remotePathTB.Text = TitleExporter(sender.ToString());
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            xmlPathTB.Text = TitleExporter(sender.ToString());
        }

        private string TitleExporter(string fileLongStr)
        {
            return fileLongStr.ToString().Substring(fileLongStr.ToString().IndexOf("FileName: ") + 10);

        }

        public static string GetValidationBtnName()
        {
            return validationBtnName;
        }

        public static bool GetRunOver()
        {
            return startOver;
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Logger.GetTxt());
        }

        public static bool RemoveWrongTvKeys { get => removeWrongTvKeys; set => removeWrongTvKeys = value; }

        private void XmlPathTB_TextChanged(object sender, EventArgs e)
        {

        }


        private void tinyPngCompressionCB_CheckedChanged(object sender, EventArgs e)
        {
            tinyPngCB.Enabled = tinyPngCompressionCB.Checked;
        }

        public void onFileMade()
        {
            if (tinyPngCompressionCB.Checked)
            {
                picCompressor.SetApiKey(apiKeyTB.Text);
                MessageBox.Show("click ok to start compression and wait");
                CompressPic(file600Path);
            }
            else
                ZipCreator.CreateZip(path1300 + "\\" + parentDirName + ".zip", file1300Path, xmlPathStr);
        }


        private void CompressPic(string picPath)
        {
            picCompressor.CompressPic(picPath);
        }

        private void SaveParams()
        {

            Settings.Default.Upgrade();

            Settings.Default.tvBtn = TvPowerCB.Checked;
            Settings.Default.avBtn = AvBtnCB.Checked;
            Settings.Default.volUpBtn = TvVolUpCB.Checked;
            Settings.Default.volDownBtn = TvVolDownCB.Checked;
            Settings.Default.muteBtn = muteBtnCB.Checked;
            Settings.Default.validationBtn = validationCB.Text;
            Settings.Default.startOver = startOverCB.Checked;
            Settings.Default.removeTvKeys = removeTvKeysCB.Checked;
            Settings.Default.tinyPng = tinyPngCompressionCB.Checked;
            Settings.Default.APIKey = apiKeyTB.Text;
            Settings.Default.remotePath = remotePathTB.Text;
            Settings.Default.xmlPath = xmlPathTB.Text;

            Settings.Default.Save();
        }



        private string CreateResizedImages(string parentDir)
        {

            var path1300 = parentDir + "\\1300";
            file1300Path = parentDir + "\\1300" + "\\remote.png";
            var path600 = parentDir + "\\600";
            parentDirName = parentDir.Substring(parentDir.LastIndexOf("\\"));
            file600Path = path600 + "\\" + parentDirName + ".png";
            if (!Directory.Exists(path1300))
                Directory.CreateDirectory(path1300);
            if (!Directory.Exists(path600))
                Directory.CreateDirectory(path600);
            var remote1300Success = PicResizer.ResizeImage(0, 1300, file1300Path, remotePicPath);
            var remote600Success = PicResizer.ResizeImage(0, 600, file600Path, remotePicPath);
            if (remote1300Success && remote600Success)
                return path1300;
            return null;
        }


        private bool CreateLogo(string parentDir)
        {
            Image img = PicToSquare.CropImage(remotePicPath);
            var logoSuccess = PicResizer.ResizeImage(512, 512, parentDir + "\\logo.png", "", img);
            return logoSuccess;
        }


        private void Go_Click(object sender, EventArgs e)
        {

            xmlPathStr = xmlPathTB.Text;
            remotePicPath = remotePathTB.Text;
            SaveParams();
            backupHandler.CreateBackup(xmlPathStr);
            var parentDir = remotePicPath.Substring(0, remotePicPath.LastIndexOf("\\"));

            //create new logos and pictures here!
            bool doNewChanges = true;
            if (doNewChanges)
            {
                path1300 = CreateResizedImages(parentDir);
                if (path1300 == null)
                {
                    MessageBox.Show("couldn't create resized images! exiting...");
                    return;
                }

                var logoCreated = CreateLogo(parentDir);
                if (!logoCreated)
                {
                    MessageBox.Show("couldn't create logo! exiting...");
                    return;
                }
            }


            removeWrongTvKeys = removeTvKeysCB.Checked;

            
            startOver = startOverCB.Checked;
            if (xmlPathTB.Text.Equals("") && tinyPngCompressionCB.Checked)
            {
                picCompressor.SetApiKey(apiKeyTB.Text);
                CompressPic(file1300Path);
                return;
            }

            if (validationCB.SelectedItem != null)
                validationBtnName = validationCB.SelectedItem.ToString();
            SetTvBtnsDict();
            initiator.RunPath(xmlPathStr, path1300);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void OnCompressionDone(string picPath)
        {
            if (picPath == file1300Path)
            {
                NormalizeRemoteAndExit();
                ZipCreator.CreateZip(path1300 + "\\" + parentDirName + ".zip", file1300Path, xmlPathStr);
                OnXmlCleaned();
                return;
            }
            if (picPath == file600Path)
            {
                picCompressor.CompressPic(file1300Path);
            }


        }

        private void NormalizeRemoteAndExit()
        {
            cleaner.NormalizeRemoteParams(xmlPathStr);
        }

        private void remotePathTB_TextChanged(object sender, EventArgs e)
        {

        }

        public void OnXmlCleaned()
        {
            MessageBox.Show("DONE!");
            Application.Exit();
            Environment.Exit(1);
        }
    }


}
