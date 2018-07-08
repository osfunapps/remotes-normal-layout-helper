using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.program.valuesparser
{
    public class RectNodeObj
    {

        private string x, y, width, height;

        public string getX(){ return x; }
        public string getY(){ return y; }
        public string getWidth(){ return width; }
        public string getHeight(){ return height; }


        public RectNodeObj(string x, string y, string width, string height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
