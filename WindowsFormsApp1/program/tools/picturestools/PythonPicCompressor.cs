using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace LayoutProject
{
    internal class PythonPicCompressor
    {


        private string pythonScript = "\"" + Directory.GetCurrentDirectory() + "\\" + "TinyPngExe.py\"";
        private string COMPRESS_SUFIX = "_compressed";

        public void compressPic(string pythonPath, string apiKey, string picInput)
        {

            apiKey = FormatString(apiKey);
            picInput = FormatString(picInput);
            //string picOutput = picInput.Insert(picInput.LastIndexOf("."), COMPRESS_SUFIX);

            RunCmd(pythonPath, pythonScript, apiKey + picInput + picInput);
            //RunCmd(pythonPath, PYTHON_SCRIPT, apiKey + picInput + picInput);

        }

        private static void RunCmd(string pythonPath, string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonPath;
            start.Arguments = cmd + args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                }
            }
        }

        private string FormatString(string inputStr)
        {
            return " \"" + inputStr + "\"";
        }
    }
}