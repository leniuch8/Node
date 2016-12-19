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
    class NodeElement
    {
        private int OutputPort { get; }
        private int InputPort { get; }
        private string IpAddress { get; }
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        public NodeElement() { }
        public NodeElement(int outputPort, int inputPort, string ipAddress)
        {
            this.OutputPort = outputPort;
            this.InputPort = inputPort;
            this.IpAddress = ipAddress;
        }
        public void Start()
        {
            this._tcpListener = new TcpListener(IPAddress.Parse(this.IpAddress), this.InputPort);
            this._tcpListener.Start();
            Listen();
        }

        public async Task ConnectClient(string ip, int port)
        {
            IPAddress myIpAddress = IPAddress.Parse(this.IpAddress);
            IPEndPoint ipLocalEndPoint = new IPEndPoint(myIpAddress, this.OutputPort);
            this._tcpClient = new TcpClient(ipLocalEndPoint);
            IPAddress ipAddress = IPAddress.Parse(ip);
            await this._tcpClient.ConnectAsync(ipAddress, port); // Connect
        }

        public void DisconnectClient()
        {
            this._tcpClient.Close();
        }

        public void ClearListeningPort()
        {
        }
        private async void Listen()
        {
            while (true)
            {
                try
                {
                    TcpClient tcpClient = await _tcpListener.AcceptTcpClientAsync();
                    Task t = Process(tcpClient);
                    await t;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private async Task Process(TcpClient tcpClient)
        {
            string clientEndPoint =
              tcpClient.Client.RemoteEndPoint.ToString();
            Console.WriteLine("Received connection request from "
              + clientEndPoint);
            try
            {
                NetworkStream networkStream = tcpClient.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                StreamWriter writer = new StreamWriter(networkStream);
                writer.AutoFlush = true;
                while (true)
                {
                    string request = await reader.ReadLineAsync();
                    if (request != null)
                    {
                        Console.WriteLine("Received service request: " + request);
                        string response = this.InputPort+": ACK";
                        await writer.WriteLineAsync(response);
                    }
                    else
                        break;
                }
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (tcpClient.Connected)
                    tcpClient.Close();
            }
        }

        public async Task SendRequest(string local, int port, string data)
        {
            try
            {
                NetworkStream networkStream = _tcpClient.GetStream();
                StreamWriter writer = new StreamWriter(networkStream);
                StreamReader reader = new StreamReader(networkStream);
                writer.AutoFlush = true;
                string requestData = this.OutputPort + ": wiadomosc" +
                  data + "&eor"; // TODO: wyswietlania w logach, zmiana formatu wiadomosci
                Node.MessageQueue.Enqueue(new NodeMessage(data, local, this.OutputPort)); // Dodaje do kolejki w NODE, tam sprawdza gdzie wyslac i moze obslugiwac FIFO.
                await writer.WriteLineAsync(requestData);
                string response = await reader.ReadLineAsync();
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
            }
        }
    }
}

