using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class TCP
    {
        public string readStr;
        private TcpClient client;
        private Thread thread;

        public bool IsConnected
        {
            get
            {
                if (client.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        // Client disconnected
                        return false;
                    }
                }

                return true;
            }
        }

        public void Begin(string ipAddress, int port)
        {

            thread = new Thread(() =>
            {
                client = new TcpClient(ipAddress, port);
                List<byte> buffer = new List<byte>();

                byte[] bytes = new byte[1024];

                while (true)
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        int length;

                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            byte[] incomingData = new byte[length];
                            Array.Copy(bytes, 0, incomingData, 0, length);
                            readStr = Encoding.ASCII.GetString(incomingData);
                        }

                        
                    }
                }
            });

            thread.IsBackground = true;
            thread.Start();
        }

        public void StopTcpActivity()
        {
            thread.Abort();
            client.Close();
        }
    }
}
            

