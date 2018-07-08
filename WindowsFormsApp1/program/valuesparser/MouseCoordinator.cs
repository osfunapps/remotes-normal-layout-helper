using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.valuesparser;

namespace LayoutProject.program.values
{
    class MouseCoordinator
    {
        //instances
        private FloatingMouseWindow floatingMouseWindowForm;

        public MouseCoordinator()
        {
            floatingMouseWindowForm = new FloatingMouseWindow();
            floatingMouseWindowForm.TopMost = true;
        }


        internal void ShowMouseNotification(string nodeName)
        {
            floatingMouseWindowForm.AppendMouseTxtLabel(nodeName);
        }

        public void ShowDialog()
        {
            Task t = Task.Run(() => {
                floatingMouseWindowForm.ShowDialog();
            });
            
        }

        public FloatingMouseWindow GetFloatingMouseWindowForm()
        {
            return floatingMouseWindowForm;
        }

    }
}
