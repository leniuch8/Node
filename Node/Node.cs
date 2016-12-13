using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Node
    {
        private int id { get; }
        public Node() { }
        public Node(int id)
        {
            this.id = id;
        }
        public NodeElement AddNodeElement(int outputPort, int inputPort, string ipAddress)
        {
            return new NodeElement(outputPort, inputPort, ipAddress);
        }
    }
}
