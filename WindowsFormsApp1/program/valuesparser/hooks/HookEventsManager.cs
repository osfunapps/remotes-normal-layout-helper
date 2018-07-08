using EventHook;
using LayoutProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.program.valuesparser.hooks
{
    class HookEventsManager
    {
        private bool validated = false;
        private bool undoed = false;
        private string UNDO = "Oem3";

        public void WaitForUserAction(IUserActionCallback userAcitonCallback)
        {
            KeyboardWatcher.Start();
            MouseWatcher.Start();
            validated = false;
            undoed = false;
            MouseWatcher.OnMouseInput += (s, e) =>
            {
                if (e.Message.ToString().Equals(PathForm.GetValidationBtnName()) && !validated) 
                    Validated(userAcitonCallback);
            };

            KeyboardWatcher.OnKeyInput += (s, e) =>
            {
                Console.WriteLine("btn name: "+ e.KeyData.Keyname);
                if (e.KeyData.Keyname.Equals(UNDO) && !undoed) 
                    Undo(userAcitonCallback);
                

                if (e.KeyData.Keyname.Equals(PathForm.GetValidationBtnName()) && !validated)
                    Validated(userAcitonCallback);
            };
        }

        private void Undo(IUserActionCallback userAcitonCallback)
        {
            undoed = true;
            KeyboardWatcher.Stop();
            MouseWatcher.Stop();
            userAcitonCallback.OnBtnUndo();
            Console.WriteLine("undo!");
            //UnblockUndo(5000);
        }

        private void UnblockUndo(int i)
        {
            Thread.Sleep(i);
            undoed = !undoed;
        }

        private void Validated(IUserActionCallback validationCallback)
        {
            validated = true;
            Console.WriteLine("validated!");
            //KeyboardWatcher.Stop();
            //MouseWatcher.Stop();
            validationCallback.OnBtnValidated();
        }

        public interface IUserActionCallback { 
            void OnBtnValidated();
            void OnBtnUndo();
        }

        public void OnDone()
        {
            validated = true;
        }
    }


}
