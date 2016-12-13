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
            NodeElement n1 = node.AddNodeElement(1025, 1024, "127.0.0.1");
            n1.Start();
            NodeElement n2 = node.AddNodeElement(1027, 1026, "127.0.0.1");
            n2.Start();
            NodeElement n3 = node.AddNodeElement(1029, 1028, "127.0.0.1");
            n3.Start();
            NodeElement n4 = node.AddNodeElement(1031, 1030, "127.0.0.1");
            n4.Start();
            connect(n1,n2,n3,n4);
            System.Threading.Thread.Sleep(100);
            send(n1,1026);
            // System.Threading.Thread.Sleep(100);


            send(n2, 1024);
           // System.Threading.Thread.Sleep(100);

            send(n3, 1030);
           // System.Threading.Thread.Sleep(100);

            send(n4, 1028);
           // System.Threading.Thread.Sleep(100);

            send(n2, 1028);
            System.Threading.Thread.Sleep(100);

            send(n1, 1026);
            System.Threading.Thread.Sleep(100);

            send(n1, 1026);
            System.Threading.Thread.Sleep(100);

            send(n1, 1026);
            System.Threading.Thread.Sleep(100);

            send(n1, 1026);



            n1.DisconnectClient();
            n4.DisconnectClient();
            System.Threading.Thread.Sleep(100);

            n4.ConnectClient("127.0.0.1", 1026);
            send(n4, 1026);


            Console.Read();
        }

        static async void send(NodeElement node,int port)
        {

            await node.SendRequest("127.0.0.1", port, "xd");
        }

        static async void connect(NodeElement n1, NodeElement n2,NodeElement n3,NodeElement n4)
        {
            await n1.ConnectClient("127.0.0.1", 1026);
            await n2.ConnectClient("127.0.0.1", 1028);
            await n3.ConnectClient("127.0.0.1", 1030);
            await n4.ConnectClient("127.0.0.1", 1024);
        }
    }
}
