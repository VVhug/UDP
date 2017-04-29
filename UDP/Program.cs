using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 7788);
            byte[] buf = Encoding.Default.GetBytes("Hello from UDP broadcast");
            Thread t = new Thread(new ThreadStart(RecvThread));
            t.IsBackground = true;
            t.Start();
            while (true)
            {
                client.Send(buf, buf.Length, endpoint);
                Thread.Sleep(1000);
            }
        }

        static void RecvThread()
        {
            UdpClient client = new UdpClient(new IPEndPoint(IPAddress.Any, 7788));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] buf = client.Receive(ref endpoint);
                string msg = Encoding.Default.GetString(buf);
                Console.WriteLine(msg);
            }
        }
    }
}


