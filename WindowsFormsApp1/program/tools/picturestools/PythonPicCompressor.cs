using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.program.tools.picturestools;
using WindowsFormsApp1.Properties;

namespace LayoutProject
{
    internal class PythonPicCompressor
    {



        private string pythonScript = "\"" + Directory.GetCurrentDirectory() + "\\" + "TinyPngExe.py\"";
        private string COMPRESS_SUFIX = "_compressed";
        private string apiKey;
        private string pythonPath;
        private IPicCompressor callback;


        public PythonPicCompressor(IPicCompressor callback)
        {
            this.callback = callback;
        }


        public void CompressPic(string picInput)
        {
            RunCmd(pythonScript, picInput);
        }

        private void RunCmd(string cmd, string picInput)
        {
            var formattedPicPath = FormatString(picInput);


            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonPath;
            start.Arguments = cmd + apiKey + formattedPicPath + formattedPicPath;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                    callback.OnCompressionDone(picInput);
                }
            }
        }

        private string FormatString(string inputStr)
        {
            return " \"" + inputStr + "\"";
        }

        public void SetParams(string pythonPath, string apiKey)
        {
            this.apiKey = FormatString(apiKey);
            this.pythonPath = pythonPath;
        }
    }
}