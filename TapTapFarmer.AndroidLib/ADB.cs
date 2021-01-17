using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace TapTapFarmer.AndroidLib
{
    public class ADB
    {

        public string SendCommand(string args)
        {
            Process p = new Process();
            ProcessStartInfo pInfo = new ProcessStartInfo();
            //pInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //pInfo.CreateNoWindow = true;
            //pInfo.UseShellExecute = false;
            //pInfo.RedirectStandardOutput = true;
            //pInfo.FileName = "adb.exe";
            //p.StartInfo = pInfo;

            //p.Start();
            //p.

            p.StartInfo.FileName = "adb.exe";
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            
            p.Start();
            p.WaitForExit();


            var response = p.StandardOutput.ReadToEnd();

            Console.WriteLine(response);

            if (!String.IsNullOrEmpty(response)) return response;
            else return String.Empty;


        }

        public void RUn2()
        {
            AdbServer server = new AdbServer();
            StartServerResult res = server.StartServer("adb.exe", restartServerIfNewer: false);
            //DeviceData dev = AdbClient.Instance
        }
    }
}
