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
            /** TODO: Wczytanie konfiguracji portow + NODE CONTROLLER zamiast tego**/
            Node node = new Node(1);
            node.SendMessage(node.NodeList[1025],1026);
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1027], 1024);
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1029], 1030);
            System.Threading.Thread.Sleep(100);
            node.SendMessage(node.NodeList[1031], 1038);
            Console.Read();
        }
    }
}
