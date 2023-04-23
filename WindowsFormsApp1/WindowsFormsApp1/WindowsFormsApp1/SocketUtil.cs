using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static WindowsFormsApp1.Constant;
using Microsoft.Office.Interop.Excel;
using System.Security.Claims;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    internal class SocketUtil
    {
        private static int port_server = 10001;
        private static int port_client = 10002;
        private static IPAddress ipAddr;
        private static bool isStartServer = false;
        private static Socket sender;

        public static MemoryModel memoryModel = new MemoryModel();

        public static string hostIpAddress;
        public static bool isServer = false;

        // ==========================================================================================================================
        // Server
        // ==========================================================================================================================
        #region Server
        public static void StartThreadServer()
        {
            if (!isStartServer)
            {
                isStartServer = true;
                Thread serverThread = new Thread(new ThreadStart(SocketUtil.ExecuteServer));
                serverThread.Start();
            }
        }

        public static void ExecuteServer()
        {
            // Establish the local endpoint
            // for the socket. Dns.GetHostName
            // returns the name of the host
            // running the application.
            String localIPv4 = GetLocalIPAddress();
            IPAddress ipAddr = IPAddress.Parse(localIPv4);
            int port = isServer ? port_server : port_client;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            // Creation TCP/IP Socket using
            // Socket Class Constructor
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Server Address: {0}, Port: {1}", localIPv4, port);

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

                    string[] dataSplit = data.Split(':');
                    string clientAddress = dataSplit[0];
                    string instruction = dataSplit.Length > 1 ? dataSplit[1] : "";
                    string value = dataSplit.Length > 2 ? dataSplit[2] : "";

                    string responseMsg = DecidedResponseMessage(clientAddress, instruction, value);
                    Console.WriteLine("response message -> {0} ", responseMsg);
                    byte[] message = Encoding.ASCII.GetBytes(responseMsg);

                    // Send a message to Client
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

        public static string DecidedResponseMessage(string clientAddress, string instruction, string value)
        {
            string result = "";

            if (instruction == CONNECT)
            {
                // for server
                memoryModel.serverMainPage.addListBoxActivity(memoryModel.serverMainPage, clientAddress + " is connected.");

                memoryModel.serverMainPage.addListBoxUser(memoryModel.serverMainPage, clientAddress);
                result = "connect success.";
            }
            else if (instruction == DISCONNECT)
            {
                // for server
                memoryModel.serverMainPage.addListBoxActivity(memoryModel.serverMainPage, clientAddress + " is disconnected.");

                memoryModel.serverMainPage.removeListBoxUser(memoryModel.serverMainPage, clientAddress);
                result = "disconnect success.";
            }
            else if (instruction == SET_START)
            {
                // for user
                Console.WriteLine("Start!!");
                memoryModel.clientMainPage.startExpirement(memoryModel.clientMainPage, value);

                result = "success";
            }
            else if (instruction == SET_STOP)
            {
                // for user
                Console.WriteLine("Stop!!");

                result = "success";
            }
            else if (instruction == SET_QUALITY_LIST)
            {
                // for user
                string[] values = value.Split(',');
                int roundTest = int.Parse(values[0]);
                int roundExperiment = int.Parse(values[1]);

                // set testQuality
                List<int> qualityTest = new List<int>();
                for (int i = 2; i < 2 + roundTest; i++)
                {
                    qualityTest.Add(int.Parse(values[i]));
                }

                // set experimentQuality
                List<int> qualityExperiment = new List<int>();
                for (int i = 2 + roundTest; i < values.Length; i++)
                {
                    qualityExperiment.Add(int.Parse(values[i]));
                }

                // save quality to memory
                memoryModel.qualityTestList = qualityTest;
                memoryModel.qualityExperimentList = qualityExperiment;

                result = "success";
            }
            else if (instruction == SET_Rebate)
            {
                // for user
                Console.WriteLine("Rebate: {0}", value);
                memoryModel.rebate = int.Parse(value);

                result = "success";
            }
            else if (instruction == SEND_RESULT)
            {
                // for server
                Console.WriteLine("Result : {0}", value);
                memoryModel.serverMainPage.addListBoxActivity(memoryModel.serverMainPage, clientAddress + " has already sent result.");
                List<string> messageList = value.Split('|').ToList();
                List<BuyingModel> resultList = messageList.Select(message => 
                {
                    string[] items = message.Split(',');

                    return new BuyingModel
                    {
                        round = int.Parse(items[0]),
                        quality = int.Parse(items[1]),
                        rating = decimal.Parse(items[2]),
                        buy = int.Parse(items[3]),
                        claim = int.Parse(items[4]),
                        feedback = int.Parse(items[5]),
                        payoff = int.Parse(items[6]),
                        rebate = int.Parse(items[7]),
                        epp = int.Parse(items[8])
                    };
                }).ToList();

                // Save excel by thread
                Thread serverThread = new Thread(() => ExcelUtil.ExportExcel(resultList, clientAddress));
                serverThread.Start();

                result = "success";
            }

            return result;
        }
        #endregion

        // ==========================================================================================================================
        // Client
        // ==========================================================================================================================
        #region Client
        public static bool SendMessageToHost(string hostIPv4, string instruction, string value)
        {
            bool result = false;
            string message = GetLocalIPAddress() + ":" + instruction.Trim() + ":" + value.Trim() + ";";

            try
            {
                // Establish the remote endpoint
                // for the socket. This example
                // uses port 11111 on the local
                // computer.
                ipAddr = IPAddress.Parse(hostIPv4);
                int port = isServer ? port_client : port_server;
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
                try
                {
                    Console.WriteLine("Send message '{0}' to {1}", message, sender.RemoteEndPoint.ToString());

                    // Creation of message that
                    // we will send to Server
                    byte[] messageSent = Encoding.ASCII.GetBytes(message);
                    int byteSent = sender.Send(messageSent);

                    // Data buffer
                    byte[] messageReceived = new byte[10240];

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

                    result = true;
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
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            return result;
        }
        #endregion

        // ==========================================================================================================================
        // Other
        // ==========================================================================================================================

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
