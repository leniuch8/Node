using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Node
    {
        public int Id
        {
            get; set;
        }
        public int listeningPort
        {
            get;
        }
        public int sendingPort
        {
            get;
        }
        private DataListener listener;
        private DataSender sender;
        public Node() { }
        public Node(int Id, int listeningPort, int sendingPort)
        {
            this.Id = Id;
            this.listeningPort = listeningPort;
            this.sendingPort = sendingPort;
            configuration();
        }
        private void configuration()
        {
            this.listener = new DataListener(this.listeningPort);
            this.sender = new DataSender();
        }
        public static void onDataReceived(string data)
        {
            Console.WriteLine(data);
        }
    }
}
