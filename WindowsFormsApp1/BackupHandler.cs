using System.IO;

namespace LayoutProject
{
    internal class BackupHandler
    {
        private string BACKUP = "backup";

        public void CreateBackup(string xmlPathStr)
        {
            var originalName = Path.GetFileName(xmlPathStr);
            var suffix = originalName.Substring(originalName.IndexOf("."));
            var backupName = originalName.Substring(0, originalName.IndexOf(".")) + " " + BACKUP + suffix;
            var parentDir = Directory.GetParent(xmlPathStr);
            File.Copy(xmlPathStr, parentDir + "\\" + backupName);
        }
    }
}