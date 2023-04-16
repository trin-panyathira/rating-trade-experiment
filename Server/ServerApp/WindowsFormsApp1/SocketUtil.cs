using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using static WindowsFormsApp1.Constant;

namespace WindowsFormsApp1
{
    internal class SocketUtil
    {
        private static int port = 10001;
        private static IPAddress ipAddr;
        private static Socket sender;

        public static MemoryModel memoryModel = new MemoryModel();

        #region Server
        public static void StartThreadServer()
        {
            Thread serverThread = new Thread(new ThreadStart(SocketUtil.ExecuteServer));
            serverThread.Start();
        }

        public static void ExecuteServer()
        {
            // Establish the local endpoint
            // for the socket. Dns.GetHostName
            // returns the name of the host
            // running the application.
            String localIPv4 = GetLocalIPAddress();
            IPAddress ipAddr = IPAddress.Parse(localIPv4);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            // Creation TCP/IP Socket using
            // Socket Class Constructor
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Server Address: {0} ", localIPv4);

            try
            {

                // Using Bind() method we associate a
                // network address to the Server Socket
                // All client that will connect to this
                // Server Socket must know this network
                // Address
                listener.Bind(localEndPoint);

                // Using Listen() method we create
                // the Client list that will want
                // to connect to Server
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    // Suspend while waiting for
                    // incoming connection Using
                    // Accept() method the server
                    // will accept connection of client
                    Socket clientSocket = listener.Accept();

                    // Data buffer
                    //byte[] bytes = new Byte[1024];
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes, 0, numByte);

                        if (data.IndexOf(";") > -1)
                            break;
                    }

                    // Remove last character symbol in message
                    data = data.Substring(0, data.Length - 1);
                    Console.WriteLine("Text received -> {0} ", data);

                    string responseMsg = DecidedResponseMessage(data);
                    Console.WriteLine("response message -> {0} ", responseMsg);
                    byte[] message = Encoding.ASCII.GetBytes(responseMsg);

                    // Send a message to Client
                    // using Send() method
                    clientSocket.Send(message);

                    // Close client Socket using the
                    // Close() method. After closing,
                    // we can use the closed Socket
                    // for a new Client Connection
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    Console.WriteLine("Sent Message Success.");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static string DecidedResponseMessage(string str)
        {
            string result = null;

            if (str == GET_QUALITY_LIST)
            {
                result = string.Join(",", memoryModel.getQualityList());
            }

            return result;
        }
        #endregion

        #region Client
        public static void ConnectServer(String hostIPv4)
        {
            try
            {
                // Establish the remote endpoint
                // for the socket. This example
                // uses port 11111 on the local
                // computer.
                ipAddr = IPAddress.Parse(hostIPv4);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

                // Creation TCP/IP Socket using
                // Socket Class Constructor
                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect Socket to the remote
                // endpoint using method Connect()
                sender.Connect(localEndPoint);

                // We print EndPoint information
                // that we are connected
                Console.WriteLine("Socket connected to -> {0} ", sender.RemoteEndPoint.ToString());

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }

        public static void SendMessageToHost(String message)
        {
            message = message + ";";

            try
            {
                Console.WriteLine("Send message '{0}' to {1}", message, sender.RemoteEndPoint.ToString());

                // Creation of message that
                // we will send to Server
                byte[] messageSent = Encoding.ASCII.GetBytes(message);
                int byteSent = sender.Send(messageSent);

                // Data buffer
                byte[] messageReceived = new byte[102400];

                // We receive the message using
                // the method Receive(). This
                // method returns number of bytes
                // received, that we'll use to
                // convert them to string
                int byteRecv = sender.Receive(messageReceived);
                Console.WriteLine("Message from Server -> {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));

                //// Close Socket using
                //// the method Close()
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            // Manage of Socket's Exceptions
            catch (ArgumentNullException ane)
            {

                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {

                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }

        }
        #endregion

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
