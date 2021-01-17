using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapTapFarmer.AndroidLib
{
    public class Touchscreen
    {
        ADB manager = new ADB();
        public void Swipe(int x1, int y1, int x2, int y2, int delay = 300)
        {
            string arg = $"shell input touchscreen swipe {x1} {y1} {x2} {y2} {delay}";
            manager.SendCommand(arg);
        }

        public void Click(int x1, int y1, int delay = 300)
        {
            string arg = $"shell input touchscreen swipe {x1} {y1} {x1} {y1} {delay}";
            Console.WriteLine(arg);
            
            manager.SendCommand(arg);
        }

        public void ShowDevices()
        {
            manager.SendCommand("devices -l");
        }
    }
}
