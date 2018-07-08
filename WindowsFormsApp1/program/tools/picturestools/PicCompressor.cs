using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinifyAPI;

namespace WindowsFormsApp1.program.tools.picturestools
{
    internal class PicCompressor
    {
        private readonly IPicCompressor _callback;

        public PicCompressor(IPicCompressor callback)
        {
            _callback = callback;
            
        }

        public void SetApiKey(string apiKey)
        {
            Tinify.Key = apiKey;
        }

        public async Task CompressPic(string picPath)
        {
            var source = Tinify.FromFile(picPath);
            await source.ToFile(picPath);
            _callback.OnCompressionDone(picPath);
        }
    }

    public interface IPicCompressor
    {
        void OnCompressionDone(string picPath);
    }
}