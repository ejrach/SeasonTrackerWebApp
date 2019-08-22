using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private static UdpClient server;
        private static IPEndPoint receivePoint;
        private static int myport = 6767;            //port for the server to use
        private static int ip = 127001;            //ip address 127.0.0.1

        static void initalize()
        {
            Console.WriteLine("Server Initializing...");
            //Create the UDP client
            server = new UdpClient(myport);

            //Define a receive point
            receivePoint = new IPEndPoint(new IPAddress(ip), myport);

            //declare a thread
            Thread startServer = new Thread(new ThreadStart(start_server));

            //start the thread
            startServer.Start();
        }

        static void start_server()
        {
            Console.WriteLine("Server Started and waiting...");

            //infinite Loop
            //The server thread loops while waiting for a 
            while (true)
            {
                //receive datagram
                byte[] recData = server.Receive(ref receivePoint);
                Console.WriteLine("Packet received from host!!");
                ASCIIEncoding encode = new ASCIIEncoding();

                //split it up
                string[] temp = encode.GetString(recData).Split(new char[] { '@' });
                Console.WriteLine();
                Console.WriteLine("Received From: {0}", temp[0]);
                Console.WriteLine("Port sent from: {0}", temp[1]);
                Console.WriteLine("Content received: {0}", temp[2]);

                //Send the response in a datagram
                byte[] sendData = encode.GetBytes(DateTime.Now.ToString());
                Console.WriteLine();
                Console.WriteLine("Sending current Date Time to {0}...", temp[0]);

                //We use the IP and port sent by the user to send the datagram back
                //UDP (User Datagram Protocol) header format:
                // 0            15 16           31
                // -------------------------------
                // | source port  |  dest port   |
                // -------------------------------
                // | UDP length   |  checksum    |
                // -------------------------------
                // UDP (array of bytes), length (num bytes), hostname, port
                server.Send(sendData, sendData.Length, temp[0], Int32.Parse(temp[1]));
            }
        }

        static void Main(string[] args)
        {
            initalize();
        }
    }
}
