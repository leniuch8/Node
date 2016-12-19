using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(1);
            node.SendMessage(node.NodeList[1025],1026, "siema kurwa|127.0.0.1|1028|21322");
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1027], 1024, "co tam|127.0.0.1|1023|123213");
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1029], 1030, "a chuj XD|127.0.0.1|1025|1024");
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1031], 1028, "klool |127.0.0.1|1025|1025");
            Console.Read();
        }
    }
}
