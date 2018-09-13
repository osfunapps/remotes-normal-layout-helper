using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.tools;
using WindowsFormsApp1.program.valuesparser;

namespace LayoutProject.program.values
{
    class MouseCoordinator
    {
        //instances
        private FloatingMouseWindow floatingMouseWindowForm;
        private Task t;

        public MouseCoordinator()
        {
            floatingMouseWindowForm = new FloatingMouseWindow();
            floatingMouseWindowForm.TopMost = true;
        }

        public void DetachFloatingMouseForm()
        {
            ShowMouseNotification("");
            //floatingMouseWindowForm.Detach();
        }


        public void AttachFloatingMouseForm()
        {
            floatingMouseWindowForm.Attach();
        }


        internal void ShowMouseNotification(string nodeName)
        {
            floatingMouseWindowForm.AppendMouseTxtLabel(nodeName);
        }

        public void ShowDialog()
        {
            if (t != null) return;
            t = Task.Run(() => {
                floatingMouseWindowForm.prepareParams();
                AttachFloatingMouseForm();
                floatingMouseWindowForm.ShowDialog();
            });

        }

        public FloatingMouseWindow GetFloatingMouseWindowForm()
        {
            return floatingMouseWindowForm;
        }

    }
}
