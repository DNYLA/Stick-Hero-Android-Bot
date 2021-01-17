using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TapTapFarmer.AndroidLib;

namespace TapTapFarmer
{
    public partial class Form1 : Form
    {
        WindowHandler wh = new WindowHandler();
        Touchscreen ts = new Touchscreen();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Device d = new Device();

            //d.Connect();
            //wh.CaptureScreenshot();

            StickHeroBot();

            ///Console.WriteLine(img);

            //ts.Click(500, 500, 300);
            
        }

        private void StickHeroBot()
        {
            Bitmap bmp = CheckPixelValue();
            bool ignore = true;
            bool searching = true;
            int Distance = 0;
            int gapDistance = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y) != Color.FromArgb(0, 0, 0) && ignore)
                    {
                        ignore = false;
                    }

                    if (bmp.GetPixel(x, y) == Color.FromArgb(247, 27, 27))
                    {
                        break;
                    }

                    if (!ignore && bmp.GetPixel(x, y) == Color.FromArgb(0, 0, 0) && searching)
                    {
                        gapDistance = x;
                        searching = false;
                    }

                    if (!ignore)
                    {
                        Distance++;
                    }
                }
            }


            int f = Distance - gapDistance;

            Distance -= (f / 2);

            Distance = (int)(Distance * 0.98);

            

            Console.WriteLine(Distance);
            //Distance = (int)(Distance * 1.05);

            ts.Click(5, 500, Distance);



        }

        public Bitmap CheckPixelValue()
        {


            using (Bitmap ScreenCap = wh.CaptureScreenshot())
            {
                Rectangle section = new Rectangle(new Point(0, 1132), new Size(ScreenCap.Width, 1));


                Bitmap ExtractedPart = new Bitmap(section.Width, section.Height);

                Graphics G = Graphics.FromImage(ExtractedPart);

                G.DrawImage(ScreenCap, 0, 0, section, GraphicsUnit.Pixel);

                ScreenCap.Save("screencap1.png");
                ExtractedPart.Save("screencap2.png");

                return ExtractedPart;
            };


        }
    }
}
