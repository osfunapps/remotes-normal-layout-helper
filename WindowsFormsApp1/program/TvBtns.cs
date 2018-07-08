using LayoutProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.program
{
    class TvBtns
    {

        //btns
        private static Dictionary<string, bool> tvBtnsDict;
        public string VOL_UP_BTN = "+vol";
        public string VOL_DOWN_BTN = "-vol";
        public string MUTE_BTN = "tv_mute";
        public string TV_BTN = "tv_power";
        public string AV_BTN = "tv_source";

        public static Dictionary<string, bool> TvBtnsDict { get => tvBtnsDict; set => tvBtnsDict = value; }

        public void SetTvBtnsDict(PathForm pathForm) => tvBtnsDict = new Dictionary<string, bool>
        {
            [VOL_UP_BTN] = pathForm.GetVolUpCB().Checked,
            [VOL_DOWN_BTN] = pathForm.GetVolDownCB().Checked,
            [TV_BTN] = pathForm.GetTvBtnCB().Checked,
            [AV_BTN] = pathForm.GetAvBtnCB().Checked,
            [MUTE_BTN] = pathForm.GetMuteBtnCB().Checked
        };

        public void showParams(PathForm pathForm)
        {
            Console.WriteLine(pathForm.GetTvBtnCB().Checked);
            Console.WriteLine(pathForm.GetMuteBtnCB().Checked);
        }
    }
   
}
