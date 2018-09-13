using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using gma.System.Windows;

namespace WindowsFormsApp1.program.valuesparser
{
    public partial class FloatingMouseWindow : Form
    {

        public FloatingMouseWindow()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void PopDialog()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(PopDialog), new object[] {});
                return;
            }

            try
            {
                ShowDialog();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        public void prepareParams()
        {
            if(actHook == null)
            actHook = new UserActivityHook(); // crate an instance
        }
    }
}
