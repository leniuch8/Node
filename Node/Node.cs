using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Node
{
    class Node
    {
        public static Queue<NodeMessage> MessageQueue;
        public Dictionary<int, NodeElement> NodeList;
        private int id { get; }
        public Node() { }
        public Node(int id)
        {
            this.id = id;
            MessageQueue = new Queue<NodeMessage>();
            NodeList = new Dictionary<int, NodeElement>();
            XmlParse();;
        }

        public void XmlParse()
        {
            /* TODO: parsowanie z XML i dodawanie nowych wezlow, pozniej AddNodeElement */
            NodeElement n1 = AddNodeElement(1025, 1024, "127.0.0.1");
            n1.Start();
            NodeElement n2 = AddNodeElement(1027, 1026, "127.0.0.1");
            n2.Start();
            NodeElement n3 = AddNodeElement(1029, 1028, "127.0.0.1");
            n3.Start();
            NodeElement n4 = AddNodeElement(1031, 1030, "127.0.0.1");
            n4.Start();
            Connect(n1, 1026);
            Connect(n2,1028);
            Connect(n3, 1030);
            Connect(n4,1024);
        }
        public NodeElement AddNodeElement(int outputPort, int inputPort, string ipAddress)
        {
            var node = new NodeElement(outputPort, inputPort, ipAddress);
            NodeList[outputPort] = node;
            return node;
        }
        public void NodeAction()
        {
            while (true)
            {
                var message = MessageQueue.Dequeue();
                //TODO: Interpretacja.
            }
        }
        /* Laczy wezel klienta do wysylania z portem na ktory ma wysylac */
        private async void Connect(NodeElement nodeElement, int port)
        {
            await nodeElement.ConnectClient("127.0.0.1", port);
        }
        /* Wysyla Request z Node do klienta na dany port */
        public async void SendMessage(NodeElement node, int port)
        {
            await node.SendRequest("127.0.0.1", port, "xd");
        }
        /** Rozlacza element **/
        private void DisconnectNodeElement(int nodeElementPort)
        {
            NodeList[nodeElementPort].DisconnectClient();
        }
    }
}
