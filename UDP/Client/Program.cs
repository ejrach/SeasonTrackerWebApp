using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Host
{
    class Program
    {
        private static UdpClient client;
        private static IPEndPoint receivePoint;
        private static int myport = 6060;         //port for the client to use
        private static int remote_port = 6767;  //port that server is using
        private static int myip = 127001;         //ip address 127.0.0.1
        private static string myhostname = "localhost";

        static void initialize()
        {
            //create the UDP client
            client = new UdpClient(myport);

            //define a receive point
            receivePoint = new IPEndPoint(new IPAddress(myip), myport);

            //declare a thread
            Thread startClient = new Thread(new ThreadStart(start_client));

            //start the thread
            startClient.Start();
        }

        static void start_client()
        {
            //loop flag
            bool continueLoop = true;

            while (continueLoop)
            {
                ASCIIEncoding encode = new ASCIIEncoding();

                //Create the datagram
                //Format: Hostname@Port@UniqueMessage
                string sendString = myhostname + "@" + myport.ToString() + "@Give me Date Time";
                //Encode it into byte array
                byte[] sendData = encode.GetBytes(sendString);
                Console.WriteLine();
                Console.WriteLine("Asking for Date Time...");

                //send to datagram to server, specified by it's port number
                client.Send(sendData, sendData.Length, myhostname, remote_port);

                //receive datagram from back from server
                byte[] recData = client.Receive(ref receivePoint);
                Console.WriteLine("Packet Received!!");
                Console.WriteLine("Date Time received: {0}", encode.GetString(recData));

                //close connection
                client.Close();
                Console.WriteLine("Connection Closed!!");

                //end loop
                continueLoop = false;
            }

            // wait for key input to close console
            Console.Read();
        }

        static void Main(string[] args)
        {
            initialize();
        }

        
    }
}
