using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.program.tools;

namespace LayoutProject
{
    internal class BackupHandler
    {
        private string BACKUP = "backup";

        public void CreateBackup(string appDirPath)
        {
            var configFilePath = appDirPath + Finals.PATH_ORIGINAL_CONFIG_FILE;
            if (!File.Exists(configFilePath))
            {
                MessageBox.Show(Finals.ERR_NO_CONFIG_FILE);
                return;
            }
            var backupPath = configFilePath.Substring(0, configFilePath.IndexOf(".")) + " " + BACKUP + ".xml";
            File.Copy(configFilePath, backupPath, true);
        }
    }
}