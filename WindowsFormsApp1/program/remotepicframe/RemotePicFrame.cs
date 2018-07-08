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
using WindowsFormsApp1.program.remotepicframe.painter;

namespace WindowsFormsApp1.program.example
{
    public partial class RemotePicFrame : Form, IUserActionCallback
    {
        //insatances
        public IRemotePicFrameCallback remotePicFrameCallback;
        private HookEventsManager HookEventsManager;
        private SquaresPainter squaresPainter;


        //params
        private int xStart, yStart, xEnd, yEnd, height, width;


        public RemotePicFrame(IRemotePicFrameCallback remotePicFrameCallback)
        {
            this.remotePicFrameCallback = remotePicFrameCallback;
            this.HookEventsManager = new HookEventsManager();
            this.squaresPainter = new SquaresPainter(this);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.RectanglesList = new List<Rectangle>();
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Rectangle mRect;

        public List<Rectangle> RectanglesList { get; }

        public bool DrawNewRect { get; private set; } = false;


        private void Remote_Pic_MouseDown(object sender, MouseEventArgs e)
        {
            //will remove the last drawn rectangle if didn't get any indication that it approved
            if (!DrawNewRect && RectanglesList.Count != 0)
                ClearLastRect();

            DrawNewRect = false;
            RectanglesList.Add(new Rectangle(e.X, e.Y, 0, 0));
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
                var lastRect = RectanglesList[RectanglesList.Count - 1];
                RectanglesList[RectanglesList.Count - 1] = new Rectangle(lastRect.Left, lastRect.Top, e.X - lastRect.Left, e.Y - lastRect.Top);
                this.Invalidate();
                remotePic.Invalidate();
            }

            Text = e.Location.X + ":" + e.Location.Y;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            squaresPainter.PaintSquare(null, e);
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

            //if the rectangle is legal, mouse has the permission to make a new rectangle

            DrawNewRect = true;
            Invalidate();
            remotePic.Invalidate();

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

        public void ClearLastRect()
        {
            if (RectanglesList.Count == 0) return;
            RectanglesList.RemoveAt(RectanglesList.Count - 1);
            remotePic.Invalidate();
            this.Invalidate();
        }

        public void OnDone()
        {
            this.remotePic.MouseUp -= Remote_Pic_MouseUp;
            HookEventsManager.OnDone();
        }
    }
}