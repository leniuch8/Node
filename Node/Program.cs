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
    class Program
    {
        static void Main(string[] args)
        {
            /** TODO: Wczytanie konfiguracji portow **/

            // TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1024); // nasz serwer
            new Node(1, 1024,0);
          //  TcpClient newClient = listener.AcceptTcpClient(); // akceptacja
        //    BinaryReader reader = new BinaryReader(newClient.GetStream()); // a reader jest po stronie serwera
         //   writer.Write(12345.15);

            Console.Read();
        }
    }
}
