using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TapTapFarmer.AndroidLib
{
    public class Device
    {
        ADB manager = new ADB();
        public bool Connect(string ipAddr = "127.0.0.1", string port = "62001")
        {
            manager.SendCommand($"connect {ipAddr}:{port}");

            return true;
        }
    }
}
