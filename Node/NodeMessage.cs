using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class NodeMessage
    {
        public string data { get; }
        public string ip { get; }
        public int destinationPort { get; } //port na ktory ma trafic wiadomosc
        public int waveLength { get; }
        public NodeMessage(string data, string ip, int destinationPort, int waveLength)
        {
            this.data = data;
            this.ip = ip;
            this.destinationPort = destinationPort;
            this.waveLength = waveLength;
        }

    }
}
