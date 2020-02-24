using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Globalization;

//**********************************************
//文件名：AsyncTCPClient
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：
//功能：Socket通信中的异步通信客户端
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/22 22:12:38
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
    public class AsyncTCPClient : IDisposable
    {
        private TcpClient tcpClient;
        private int retries = 0;
        private bool closing = false;
        #region 构造函数

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteEP"></param>
        /// <param name="localEP"></param>
        public AsyncTCPClient(IPEndPoint remoteEP, IPEndPoint localEP)
        : this(new[] { remoteEP.Address},remoteEP.Port,localEP) { }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteEP">远程服务器终结点</param>
        public AsyncTCPClient(IPEndPoint remoteEP)
            : this(new[] { remoteEP.Address},remoteEP.Port) { }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteIPAddress">远程服务器IP地址</param>
        /// <param name="remotePort">远程服务器端口号</param>
        public AsyncTCPClient(IPAddress remoteIPAddress, int remotePort)
            : this(new[] { remoteIPAddress},remotePort) { }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteHostName">远程服务器主机名</param>
        /// <param name="remotePort">远程服务器端口号</param>
        public AsyncTCPClient(string remoteHostName, int remotePort)
            :this(Dns.GetHostAddresses(remoteHostName), remotePort)
        { }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteHostName"></param>
        /// <param name="remotePort"></param>
        /// <param name="localEP"></param>
        public AsyncTCPClient(string remoteHostName,int remotePort,IPEndPoint localEP)
            :this(Dns.GetHostAddresses(remoteHostName),remotePort,localEP)
        {

        }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteIPAddress">远端服务器IP地址列表</param>
        /// <param name="remotePort">远端服务器端口号</param>
        /// <param name="receiveBufferSize">接收缓冲区大小</param>
        public AsyncTCPClient(IPAddress[] remoteIPAddress, int remotePort, int receiveBufferSize=1024)
            : this(remoteIPAddress, remotePort,  null, receiveBufferSize)
        {

        }

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="remoteIPAddress">远端服务器IP地址列表</param>
        /// <param name="remotePort">远端服务器端口号</param>
        /// <param name="localEP">本地端口号终结点</param>
        /// <param name="receiveBufferSize">接收数据缓冲区大小(默认大小1024)</param>
        public AsyncTCPClient(IPAddress[] remoteIPAddress, int remotePort, IPEndPoint localEP,int receiveBufferSize=1024)
        {
            this.Address = remoteIPAddress;
            this.Port = remotePort;
            this.BufferSize = receiveBufferSize;
            this.LocalIPEndPoint = localEP;
            this.Encoding = Encoding.Default;
            if (this.LocalIPEndPoint != null)
            {
                this.tcpClient = new TcpClient(this.LocalIPEndPoint);
            }
            else
            {
                this.tcpClient = new TcpClient();
            }
            retries = 3;
            RetryInteravl = 3;
        }


        #endregion


        #region 属性

        /// <summary>
        /// 是否与服务器建立连接
        /// </summary>
        public bool Connected
        {
            get
            {
                return tcpClient.Client.Connected;
            }
        }

        /// <summary>
        /// 远程服务器IP地址列表
        /// </summary>
        public IPAddress[] Address { get; private set; }

        /// <summary>
        /// 远程服务器端口
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// 获取或设置通信缓冲区大小
        /// </summary>
        public int BufferSize
        {
            get { return tcpClient.ReceiveBufferSize; }
            set { tcpClient.ReceiveBufferSize = value; }
        }
        /// <summary>
        /// 获取或设置连接重试次数
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// 获取或设置连接重试间隔（单位：秒）
        /// </summary>
        public int RetryInteravl { get; set; }

        /// <summary>
        /// 远端服务器终结点
        /// </summary>
        public IPEndPoint RemoteIPEndPoint
        {
            get { return new IPEndPoint(Address[0], Port); }
        }

        /// <summary>
        /// 本地客户端总结点
        /// </summary>
        public IPEndPoint LocalIPEndPoint { get; private set; }

        /// <summary>
        /// 获取或设置通信所使用的编码
        /// </summary>
        public Encoding Encoding { get; set; }

        #endregion

        #region 公共方法

        #region Connect

        public AsyncTCPClient Connect()
        {
            if (!Connected) {

            }
            return this;
        }

        private void TcpServerConnectedCallBack(IAsyncResult ar)
        {
            try
            {
                tcpClient.EndConnect(ar);
                OnServerConnected(Address,Port);
                retries = 0;
            }
            catch (Exception ex)
            {
                if (retries > 0)
                {
                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.INFO,string.Format(
                        "Connect to server with retry {0} failed.",retries));
                }
                retries++;
                if (retries > Retries)
                {
                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.WARNING,
                        "Waiting {0} seconds before retrying to connect to server.",ex);
                    Thread.Sleep(TimeSpan.FromSeconds(this.RetryInteravl));
                    return;
                }
                //Connected Successfually and start async Reveive Datagream
                byte[] buffer = new byte[this.tcpClient.ReceiveBufferSize];
                tcpClient.GetStream().BeginRead(buffer,0, buffer.Length,BeginReadCallBack,buffer);
            }
        }
        #endregion

        #region Close

        /// <summary>
        /// 关闭与服务器的连接
        /// </summary>
        /// <returns></returns>
        public AsyncTCPClient Close()
        {
            if (Connected)
            {
                closing = true;
                retries = 0;
                this.tcpClient.Close();
                OnServerDisconnected(Address,this.Port);
            }
            return this;
        }
        #endregion


        #region Send

        /// <summary>
        /// 发送报文
        /// </summary>
        /// <param name="datagram">报文数据</param>
        public void Send(string datagram)
        {
            
        }

        /// <summary>
        /// 发送报文
        /// </summary>
        /// <param name="datagram">报文数据</param>
        public void Send(byte[] datagram)
        {
            if (datagram == null)
                throw new ArgumentNullException("Datagram");
            if (!Connected)
            {
                throw new InvalidOperationException("发送失败，未连接到服务器。");
            }
            tcpClient.GetStream().BeginWrite(datagram,0,datagram.Length, SendCallBack,this.tcpClient);
        }


        #endregion

        #endregion

        #region 私有方法

        private void SendCallBack(IAsyncResult ar)
        {
            ((TcpClient)ar.AsyncState).GetStream().EndWrite(ar);
        }

        private void BeginReadCallBack(IAsyncResult ar)
        {
            try
            {
                NetworkStream ntStream;
                if (!closing)
                {
                    ntStream = tcpClient.GetStream();
                }
                else
                    return;

                int numReadBytes = 0;
                try
                {
                    numReadBytes = ntStream.EndRead(ar);
                }
                catch (Exception ex)
                {

                    Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                        "EndRead Server Data Error",ex);
                }
                if (numReadBytes == 0)
                {
                    //Close
                    Close();
                    return;
                }
                //Receive Bytes 
                byte[] buffer = (byte[])ar.AsyncState;
                byte[] receiveBytes = new byte[numReadBytes];
                Buffer.BlockCopy(buffer,0,receiveBytes,0,numReadBytes);
                OnDatagramReceived(this.tcpClient,receiveBytes);
                OnPlaintextReceived(this.tcpClient,receiveBytes);

                //Read Datagram from network again
                ntStream.BeginRead(buffer,0,buffer.Length, BeginReadCallBack,buffer);

            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                      "Read Server Data Error", ex);
            }
        }

        /// <summary>
        /// Trigger ServerConnected Event
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        protected virtual  void OnServerConnected(IPAddress[] ipAddress,int port)
        {
            ServerConnected?.Invoke(this, new TCPServerConnectedEventArgs(ipAddress,port));
        }

        /// <summary>
        /// Trigger ServerDisconnected Event
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        protected virtual void OnServerDisconnected(IPAddress[] ipAddress,int port)
        {
            ServerDisconnected?.Invoke(this,new TCPServerDisconnectedEventArgs(ipAddress,port));
        }

        /// <summary>
        /// 发生内部异常事件
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="innerException"></param>
        protected virtual void OnServerExceptionOccurred(IPAddress[] ipAddress,int port,Exception innerException)
        {
            ServerExceptionOccurred?.Invoke(this,
                new TCPServerExceptionOccurredEventArgs(ipAddress,port, innerException));
        }

        /// <summary>
        /// 接收数据报文事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="datagram"></param>
        private void OnDatagramReceived(TcpClient sender,byte[] datagram)
        {
            DatagramReceived?.Invoke(this,new TCPDatagramReceiveEventArgs<byte[]>(sender,datagram));
        }

        /// <summary>
        /// 接收数据报文明文事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="datagram"></param>
        private void OnPlaintextReceived(TcpClient sender,byte[] datagram)
        {
            PlaintextReceived?.Invoke(this,new TCPDatagramReceiveEventArgs<string>(
                sender,this.Encoding.GetString(datagram)));
        }
        #endregion

        #region 委托



        #endregion

        #region 事件

        /// <summary>
        /// 与服务器已建立连接事件
        /// </summary>
        public event EventHandler<TCPServerConnectedEventArgs> ServerConnected;

        /// <summary>
        /// 与服务器断开连接事件
        /// </summary>
        public event EventHandler<TCPServerDisconnectedEventArgs> ServerDisconnected;

        /// <summary>
        /// 与服务器连接发生异常事件
        /// </summary>
        public event EventHandler<TCPServerExceptionOccurredEventArgs> ServerExceptionOccurred;


        /// <summary>
        /// 数据报文接收事件
        /// </summary>
        public event EventHandler<TCPDatagramReceiveEventArgs<byte[]>> DatagramReceived;

        /// <summary>
        /// 数据报文明文接收事件
        /// </summary>
        public event EventHandler<TCPDatagramReceiveEventArgs<string>> PlaintextReceived;
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AsyncTCPClient() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion

    }

}
