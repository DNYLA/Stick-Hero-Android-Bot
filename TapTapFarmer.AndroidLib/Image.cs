using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TapTapFarmer.AndroidLib
{
    public class WindowHandler
    {
        ADB adb = new ADB();

        ADB manager = new ADB();


        public void Click(int x1, int y1, int delay = 300)
        {
            string arg = $"shell input touchscreen swipe {x1} {y1} {x1} {y1} {delay}";
            Console.WriteLine(arg);

            manager.SendCommand(arg);
        }


        private Bitmap StringToImage(string input)
        {
            byte[] imageBytes = Encoding.ASCII.GetBytes(input);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return new Bitmap(ms);
            }
        }

        public Bitmap CaptureScreenshot()
        {

            if (File.Exists("capture.png")) File.Delete("capture.png");

            adb.SendCommand("shell screencap -p /sdcard/capture.png");
            adb.SendCommand("pull /sdcard/capture.png");

            Thread.Sleep(500);


            Bitmap bmp = new Bitmap("capture.png");

            return bmp;


            //turn bmp;

            //using (Bitmap bmp = new Bitmap("capture.png"))
            //{
            //    //File.Delete("capture.png");
            //    return bmp;
            //};

            //Console.WriteLine(bmp.Width + bmp.Height);
            //Bitmap b = bmp;
           // Console.WriteLine(b.Width + b.Height);

           // bmp.Dispose();
           // File.Delete("capture.png");


            //Bitmap x = StringToImage(stream);
            //x.Save("screencap.png");
            //Console.WriteLine(x);

            //adb.SendCommand("adb devices -l");

            //if (!File.Exists("screen.png")) { return new Image(); }

            //Image img = Image.FromFile("screen.png");

            //File.Delete("screen.png");

            //return new Image();
        }
    }
}
