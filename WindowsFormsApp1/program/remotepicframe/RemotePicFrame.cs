using LayoutProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.program.valuesparser;
using WindowsFormsApp1.program.valuesparser.hooks;
using static WindowsFormsApp1.program.valuesparser.hooks.HookEventsManager;
using System.Xml;

namespace WindowsFormsApp1.program.example
{
    public partial class RemotePicFrame : Form, IUserActionCallback
    {
        //insatances
        public IRemotePicFrameCallback remotePicFrameCallback;
        private HookEventsManager HookEventsManager;

         
        //params
        private int xStart, yStart, xEnd, yEnd, height, width;

        
        public RemotePicFrame(IRemotePicFrameCallback remotePicFrameCallback)
        {
            this.remotePicFrameCallback = remotePicFrameCallback;
            this.HookEventsManager = new HookEventsManager();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.rectanglesList = new List<Rectangle>();
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        Rectangle mRect;
        private List<Rectangle> rectanglesList;

        private Color SQUARE_COLOR = Color.HotPink;
        private void Remote_Pic_MouseDown(object sender, MouseEventArgs e)
        {
            mRect = new Rectangle(e.X, e.Y, 0, 0);
            xStart = e.Location.X;
            yStart = e.Location.Y;
            this.Invalidate();
            remotePic.Invalidate();
        }

        internal void SetRemotePicDimens(XmlDocument xmlDocument)
        {
            Console.WriteLine(this.remotePic.Image.Size.Width + " height: " + this.remotePic.Image.Size.Height);
        }

        private void Remote_Pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mRect = new Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - mRect.Top);
                this.Invalidate();
                remotePic.Invalidate();
            }

            Text = e.Location.X + ":" + e.Location.Y;
        }

       
        protected override void OnPaint(PaintEventArgs e)
        {
            Remote_Pic_Paint(null, e);
        }


        private void Remote_Pic_Paint(object sender, PaintEventArgs e)
        {

            //Draw a rectangle with 2pixel wide line
            using (Pen pen = new Pen(SQUARE_COLOR, 1))
            {
                e.Graphics.DrawRectangle(pen, mRect);
            }
        }


        private void Remote_Pic_MouseUp(object sender, MouseEventArgs e)
        {
            xEnd = e.Location.X;
            yEnd = e.Location.Y;

            width = xEnd - xStart;
            height = yEnd - yStart;
            Console.WriteLine("x: " + xStart + ", y: " + yStart + ", width: " + width + ", height: " + height);

             if (PathForm.GetValidationBtnName() != null)
             {
            HookEventsManager.WaitForUserAction(this);
            }
        
            else OnBtnValidated();
        }


        internal PictureBox GetRemotePic()
        {
            return remotePic;
        }

        public void OnBtnValidated()
        {
            remotePicFrameCallback.OnBtnMarked(new RectNodeObj(
               xStart.ToString(),
               yStart.ToString(),
               width.ToString(),
               height.ToString()));
        }

        public void OnBtnUndo()
        {
            remotePicFrameCallback.OnBtnUndo();

        }

        private void FormShown(object sender, EventArgs e)
        {
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        public interface IRemotePicFrameCallback
        { 
            void OnBtnMarked(RectNodeObj rectObj);
            void OnBtnUndo();
        }

    }
}
