using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Tip117
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region server

        //用于保存非对称加密（数字证书）的公钥
        string publicKey = string.Empty;
        //用于保存非对称加密（数字证书）的私钥
        string pfxKey = string.Empty;

        ///======================
        ///服务器端代码
        ///======================

        ///用于跟客户端通信的socket
        Socket serverCommunicateSocket;
        ///定义接受缓存块的大小
        static int serverBufferSize = 1024;
        ///缓存块
        byte[] bytesReceivedFromClient = new byte[serverBufferSize];
        ///密钥K
        string key = string.Empty;
        StringBuilder messageFromClient = new StringBuilder();

        ///开启服务器
        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            //先生成数字证书（模拟，即非对称密钥对）
            RSAKeyInit();
            //负责侦听
            StartListen();
        }

        private void RSAKeyInit()
        {
            RSAProcessor.CreateRSAKey(ref publicKey, ref pfxKey);
        }

        private void StartListen()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 8009);
            //负责侦听的socket
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(iep);
            listenSocket.Listen(50);
            listenSocket.BeginAccept(new AsyncCallback(this.Accepted), listenSocket);
            ListBoxServerShow("开始侦听。。。");
            buttonStartServer.Enabled = false;
        }

        ///负责客户端的连接，并开始将自己置于接收状态
        void Accepted(IAsyncResult result)
        {
            Socket listenSocket = result.AsyncState as Socket;
            //初始化和客户端进行通信的socket
            serverCommunicateSocket = listenSocket.EndAccept(result);
            ListBoxServerShow("有客户端连接到。。。");
            serverCommunicateSocket.BeginReceive(bytesReceivedFromClient, 0, serverBufferSize, SocketFlags.None, new AsyncCallback(this.ReceivedFromClient), null);
        }

        ///负责处理接受自客户端的数据
        void ReceivedFromClient(IAsyncResult result)
        {
            int read = serverCommunicateSocket.EndReceive(result);
            if (read > 0)
            {
                messageFromClient.Append(UTF32Encoding.Default.GetString(bytesReceivedFromClient, 0, read));
                //处理并显示数据
                ProcessAndShowInServer();
                serverCommunicateSocket.BeginReceive(bytesReceivedFromClient, 0, serverBufferSize, 0, new AsyncCallback(ReceivedFromClient), null);
            }
        }

        private void ProcessAndShowInServer()
        {
            string msg = messageFromClient.ToString();
            //如果接收到<EOF>则表示完成完成一次，否则继续将自己置于接收状态
            if (msg.IndexOf("<EOF>") > -1)
            {
                //如果客户端发送key，则负责初始化key
                if (msg.IndexOf("<KEY>") > -1)
                {
                    //用私钥解密发送过来的Key信息
                    key = RSAProcessor.RSADecrypt(pfxKey, msg.Substring(0, msg.Length - 10));
                    ListBoxServerShow(string.Format("接收到客户端密钥：{0}", key));
                }
                else
                {
                    //解密SSL通道中发送过来的密文并显式
                    ListBoxServerShow(string.Format("接收到客户端消息：{0}", RijndaelProcessor.DencryptString(msg.Substring(0, msg.Length - 5), key)));
                }
                messageFromClient.Clear();
            }
        }

        ///负责向客户端发送数据
        private void buttonStartSendToClient_Click(object sender, EventArgs e)
        {
            //加密消息体
            string msg = string.Format("{0}{1}", RijndaelProcessor.EncryptString(DateTime.Now.ToString(), key), "<EOF>");
            RijndaelProcessor.DencryptString(msg.Substring(0, msg.Length - 5), key);
            byte[] msgBytes = UTF32Encoding.Default.GetBytes(msg);
            serverCommunicateSocket.BeginSend(msgBytes, 0, msgBytes.Length, SocketFlags.None, null, null);
            ListBoxServerShow(string.Format("发送：{0}", msg));
        }

        private void ListBoxServerShow(string msg)
        {
            listBoxServer.BeginInvoke(new Action(() =>
            {
                listBoxServer.Items.Add(msg);
            }));
        }
        #endregion server

        #region client
        ///======================
        ///客户端代码
        ///======================

        ///用于跟服务器通信的socket
        Socket clientCommunicateSocket;
        ///用于暂存接收到的字符串
        StringBuilder messageFromServer = new StringBuilder();
        ///定义接受缓存块的大小
        static int clientBufferSize = 1024;
        ///缓存块
        byte[] bytesReceivedFromServer = new byte[clientBufferSize];
        //随机生成的key，在这里硬编码为key123
        string keyCreateRandom = "key123";

        private void buttonConnectAndReceiveMsg_Click(object sender, EventArgs e)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 8009);
            Socket connectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connectSocket.BeginConnect(iep, new AsyncCallback(this.Connected), connectSocket);
            buttonConnectAndReceiveMsg.Enabled = false;
        }

        void Connected(IAsyncResult result)
        {
            clientCommunicateSocket = result.AsyncState as Socket;
            clientCommunicateSocket.EndConnect(result);
            clientCommunicateSocket.BeginReceive(bytesReceivedFromServer, 0, clientBufferSize, SocketFlags.None, new AsyncCallback(this.ReceivedFromServer), null);
            ListBoxClientShow("客户端连接上服务器。。。");
            //连接成功便发送密钥K给服务器
            SendKey();
        }

        void ReceivedFromServer(IAsyncResult result)
        {
            int read = clientCommunicateSocket.EndReceive(result);
            if (read > 0)
            {
                messageFromServer.Append(UTF32Encoding.Default.GetString(bytesReceivedFromServer, 0, read));
                //处理并显示客户端数据
                ProcessAndShowInClient();
                clientCommunicateSocket.BeginReceive(bytesReceivedFromServer, 0, clientBufferSize, 0, new AsyncCallback(ReceivedFromServer), null);
            }
        }

        private void ProcessAndShowInClient()
        {
            //如果接收到<EOF>则表示完成一次接收，否则继续将自己置于接收状态
            if (messageFromServer.ToString().IndexOf("<EOF>") > -1)
            {
                //解密消息体并呈现出来
                ListBoxClientShow(string.Format("接收到服务器消息：{0}", RijndaelProcessor.DencryptString(messageFromServer.ToString().Substring(0, messageFromServer.ToString().Length - 5), keyCreateRandom)));
                messageFromServer.Clear();
            }
        }

        private void buttonStartSendToServer_Click(object sender, EventArgs e)
        {
            //加密消息体
            string msg = string.Format("{0}{1}", RijndaelProcessor.EncryptString(DateTime.Now.ToString(), keyCreateRandom), "<EOF>");
            byte[] msgBytes = UTF32Encoding.Default.GetBytes(msg);
            clientCommunicateSocket.BeginSend(msgBytes, 0, msgBytes.Length, SocketFlags.None, null, null);
            ListBoxClientShow(string.Format("发送：{0}", msg));
        }

        private void SendKey()
        {
            string msg = RSAProcessor.RSAEncrypt(publicKey, keyCreateRandom) + "<KEY><EOF>";
            byte[] msgBytes = UTF32Encoding.Default.GetBytes(msg);
            clientCommunicateSocket.BeginSend(msgBytes, 0, msgBytes.Length, SocketFlags.None, null, null);
            ListBoxClientShow(string.Format("发送：{0}", keyCreateRandom));
        }

        private void ListBoxClientShow(string msg)
        {
            listBoxClient.BeginInvoke(new Action(() =>
            {
                listBoxClient.Items.Add(msg);
            }));
        }
        #endregion client




    }
}
