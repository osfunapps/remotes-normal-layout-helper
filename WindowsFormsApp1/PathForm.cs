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
using WindowsFormsApp1.program.tools;
using WindowsFormsApp1.program.tools.picturestools;
using WindowsFormsApp1.Properties;


namespace LayoutProject
{
    public partial class PathForm : Form, InitiatorCallBack, IPicCompressor, IXmlCleanerCallback
    {

        //instances
        private PythonPicCompressor picCompressor;
        private Initiator initiator;

        //checkers params
        private static bool removeWrongTvKeys;
        private static string remotesPathStr;
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
        private string[] appsDirsPaths;
        private static int currAppDirCycle;
        private static string nextAppPath;

        public PathForm()
        {
            setInstances();
            InitializeComponent();
            setCBItems();
            loadPreviousParams();
        }

        private void loadPreviousParams()
        {
            apiKeyTB.Text = Settings.Default.APIKey;
            remotesPathTB.Text = Settings.Default.remotesPath;
            TvPowerCB.Checked = Settings.Default.tvBtn;
            AvBtnCB.Checked = Settings.Default.avBtn;
            TvVolUpCB.Checked = Settings.Default.volUpBtn;
            TvVolDownCB.Checked = Settings.Default.volDownBtn;
            muteBtnCB.Checked = Settings.Default.muteBtn;
            PythonPathTB.Text = Settings.Default.pythonPath;
            validationCB.Text = Settings.Default.validationBtn;
            undoCB.Text = Settings.Default.undoBtn;
            tinyPngCompressionCB.Checked = Settings.Default.tinyPng;
        }


        private void setInstances()
        {
            initiator = new Initiator(this);
            picCompressor = new PythonPicCompressor(this);
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
            return nextAppPath + Finals.PATH_ORIGINAL_CONFIG_FILE;
        }

        internal static string getRemotePicPath()
        {
            return remotePicPath;
        }


        private void Browse_Xml_Path_clicked(object sender, EventArgs e)
        {
            xmlPathDialog.ShowDialog();
        }

        private void remotePicDialog_FileOk(object sender, CancelEventArgs e)
        {
            //remotePathTB.Text = TitleExporter(sender.ToString());
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            remotesPathTB.Text = TitleExporter(sender.ToString());
        }

        private string TitleExporter(string fileLongStr)
        {
            return fileLongStr.Substring(fileLongStr.IndexOf("FileName: ") + 10);

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

        public void OnFileMade()
        {
            if (tinyPngCompressionCB.Checked)
            {
                CompressPic(file600Path);
            }
            else
                NormalizeRemoteAndExit();
        }


        private void CreateZip()
        {
            ZipCreator.CreateZip(path1300 + "\\" + parentDirName + ".zip", file1300Path, GetXmlPath());
        }

        private void CompressPic(string picPath)
        {
            if (PythonPathTB.Text == "")
            {
                MessageBox.Show(Finals.ERR_NO_PYTHON_PATH);
                return;
            }
            if (apiKeyTB.Text == "")
            {
                MessageBox.Show(Finals.ERR_NO_API);
                return;
            }

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
            Settings.Default.undoBtn = undoCB.Text;
            Settings.Default.tinyPng = tinyPngCompressionCB.Checked;
            Settings.Default.pythonPath = PythonPathTB.Text;
            Settings.Default.APIKey = apiKeyTB.Text;
            Settings.Default.remotesPath = remotesPathTB.Text;
            Settings.Default.Save();
        }



        private string CreateResizedImages(string parentDir)
        {

            parentDirName = parentDir.Substring(parentDir.LastIndexOf("\\") + 1);
            remotePicPath = parentDir + Finals.PATH_ORIGINAL_REMOTE_IMG;
            if (!File.Exists(remotePicPath))
                remotePicPath = parentDir + Finals.PATH_ORIGINAL_REMOTE_IMG_2;
            if (!File.Exists(remotePicPath))
            {
                MessageBox.Show(Finals.ERR_NO_REMOTE_IMG);
                return null;
            }
            var path1300 = parentDir + "\\1300";
            file1300Path = path1300 + "\\" + parentDirName + Finals.SUFFIX_PNG;
            var path600 = parentDir + "\\600";
            file600Path = path600 + "\\" + parentDirName + Finals.SUFFIX_PNG;
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
            if (remotesPathTB.Text == "")
            {
                MessageBox.Show(Finals.ERR_NO_REMOTES_PATH);
                return;
            }
            
            if (goBtn.Text == Finals.BTN_GO_START)
                SetInitialParams();

            if (onlyTinyPNGCB.Checked)
            {
                MessageBox.Show(Finals.MSG_START_COMPRESS);
                CompressPic(remotesPathTB.Text);
                return;
            }

            UpdateRemoteName(appsDirsPaths[currAppDirCycle]);
            RunNextCycle();
        }

        private void SetInitialParams()
        {
            remotesPathStr = remotesPathTB.Text;

            var isParentDir = IsParentDirectoryToRemotes();
            if (isParentDir)
                appsDirsPaths = Directory.GetDirectories(remotesPathStr);
            else
                appsDirsPaths = new[] { remotesPathStr };

            picCompressor.SetParams(PythonPathTB.Text, apiKeyTB.Text);
            SaveParams();

        }

        private void RunNextCycle()
        {
            nextAppPath = appsDirsPaths[currAppDirCycle];
            currAppDirCycle++;
            RunCycle(nextAppPath);
        }


        private void RunCycle(string appDirPath)
        {






            backupHandler.CreateBackup(appDirPath);

            //create new logos and pictures here!
            path1300 = CreateResizedImages(appDirPath);
            if (path1300 == null)
            {
                MessageBox.Show("couldn't create resized images! exiting...");
                return;
            }

            var logoCreated = CreateLogo(appDirPath);
            if (!logoCreated)
            {
                MessageBox.Show("couldn't create logo! exiting...");
                return;
            }

            if (validationCB.SelectedItem != null)
                validationBtnName = validationCB.SelectedItem.ToString();

            if (undoCB.SelectedItem != null)
                undoBtnName = undoCB.SelectedItem.ToString();

            SetTvBtnsDict();
            initiator.RunPath(appDirPath, path1300);
        }

        public void OnCycleDone()
        {
            if (currAppDirCycle < appsDirsPaths.Length)
            {
                PrepareLayoutForNextCycle();
            }

            else
            {
                MessageBox.Show(Finals.MSG_DONE_REMOTE);
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception e) { }
                //Application.Exit();
            }
        }

        private void PrepareLayoutForNextCycle()
        {
            initiator.KillPreviousCycleElements();
            UpdateGoBtnText(Finals.BTN_GO_RESUME);
            UpdateRemoteName(appsDirsPaths[currAppDirCycle]);

        }

        private void UpdateGoBtnText(string newText)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateGoBtnText), new object[] { newText });
                return;
            }

            try
            {
                goBtn.Text = Finals.BTN_GO_RESUME;
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }


        }
        private void UpdateRemoteName(string nextAppPath)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateRemoteName), new object[] { nextAppPath });
                return;
            }

            try
            {
                currRemoteNameLabel.Text = Path.GetFileNameWithoutExtension(nextAppPath);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }


        }


        private bool IsParentDirectoryToRemotes()
        {
            if (!Directory.Exists(remotesPathStr)) return false;
            return Directory.GetFiles(remotesPathStr).All(file => !file.EndsWith(".png"));
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
                return;
            }
            if (picPath == file600Path)
            {
                picCompressor.CompressPic(file1300Path);
            }


        }

        private void NormalizeRemoteAndExit()
        {
            cleaner.NormalizeRemoteParams(GetXmlPath());
        }

        private void remotePathTB_TextChanged(object sender, EventArgs e)
        {

        }

        public void OnXmlCleaned()
        {
            CreateZip();
            MessageBox.Show("remote done");
            OnCycleDone();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static object GetUndoBtnName()
        {
            return undoBtnName;
        }

        private void onlyTinyPNGCB_CheckedChanged(object sender, EventArgs e)
        {
            buttonsGB.Enabled = !onlyTinyPNGCB.Checked;
            buttons2GB.Enabled = !onlyTinyPNGCB.Checked;
            tinyPngCompressionCB.Checked = onlyTinyPNGCB.Checked;
        }
    }


}
