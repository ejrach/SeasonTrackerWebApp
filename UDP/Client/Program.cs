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
                string val;
                string sendString;
                ASCIIEncoding encode = new ASCIIEncoding();

                //Ask for 1) Date or 2) Time
                Console.Write("Retrieve date (1) or time (2): ");
                val = Console.ReadLine();

                //Create the datagram based on the input:
                if (val == "1")
                {
                    //Format: Hostname@Port@UniqueMessage
                    sendString = myhostname + "@" + myport.ToString() + "@Give me Date";
                    Console.WriteLine();
                    Console.WriteLine("Asking for Date...");
                }
                else //anything else
                {
                    //Format: Hostname@Port@UniqueMessage
                    sendString = myhostname + "@" + myport.ToString() + "@Give me Time";
                    Console.WriteLine();
                    Console.WriteLine("Asking for Time...");
                }
             
                //Create the datagram
                //Format: Hostname@Port@UniqueMessage
                //Encode it into byte array
                byte[] sendData = encode.GetBytes(sendString);
                //Console.WriteLine();
                //Console.WriteLine("Asking for Date Time...");

                //send to datagram to server, specified by it's port number
                client.Send(sendData, sendData.Length, myhostname, remote_port);

                //receive datagram from back from server
                byte[] recData = client.Receive(ref receivePoint);
                Console.WriteLine("Packet Received!!");
                Console.WriteLine("Data received: {0}", encode.GetString(recData));
                Console.WriteLine();

                string resp;
                Console.Write("Do you want to continue? y or n: ");
                resp = Console.ReadLine();
                if (resp == "n")
                {
                    //close connection
                    client.Close();
                    Console.WriteLine("Connection Closed!!");

                    //end loop
                    continueLoop = false;
                }
                else
                {
                    // any other character, keep going
                }
            }

            // wait for key input to close console. Not the most elegant way to close, but who cares...just a demo
            Console.Read();
        }

        static void Main(string[] args)
        {
            initialize();
        }

        
    }
}
