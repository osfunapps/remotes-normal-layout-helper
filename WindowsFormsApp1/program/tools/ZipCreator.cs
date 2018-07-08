
using System.IO;
using System.IO.Compression;
using System.Windows.Forms.VisualStyles;

namespace LayoutProject
{

    internal class ZipCreator

    {

        /// <summary>
        /// will insert any number of files to a zip file and put it in a requested output.
        /// </summary>
        /// <param name="outputPath">where to put the zip file</param>
        /// <param name="paths">the paths of the files to add to the zip</param>
        public static void CreateZip(string outputPath, params string[] paths)
        {
            //Creates a new, blank zip file to work with - the file will be
            //finalized when the using statement completes
            if (File.Exists(outputPath))
                File.Delete(outputPath);
            using (ZipArchive zipFile = ZipFile.Open(outputPath, ZipArchiveMode.Create))
            {

                foreach (string path in paths)
                {
                    var fileName = path.Substring(path.LastIndexOf("\\")+1);
                    zipFile.CreateEntryFromFile(path, fileName);
                }
            }


        }
    }
}