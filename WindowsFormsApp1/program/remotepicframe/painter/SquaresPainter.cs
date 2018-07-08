using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.example;

namespace WindowsFormsApp1.program.remotepicframe.painter
{
    class SquaresPainter
    {

        private Color SQUARE_COLOR = Color.MediumSlateBlue;
        private Color CURRENT_SQUARE_COLOR = Color.DarkOrange;

        //instances
        private RemotePicFrame picFrame;

        public SquaresPainter(RemotePicFrame picFrame)
        {
            this.picFrame = picFrame;
        }

        public void PaintSquare(object sender, PaintEventArgs e)
        {


            if (picFrame.RectanglesList.Count == 0) return;
            //Draw a rectangle with 1pixel wide line

            using (var pen = new Pen(SQUARE_COLOR, 1))
                foreach (var t in picFrame.RectanglesList)
                   e.Graphics.DrawRectangle(pen, t);

            if (picFrame.DrawNewRect)
                return;

            using (var pen = new Pen(CURRENT_SQUARE_COLOR, 1))
                e.Graphics.DrawRectangle(pen, picFrame.RectanglesList[picFrame.RectanglesList.Count - 1]);
        }

    }
}
