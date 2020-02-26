using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;
using System.Net.Sockets;


//**********************************************
//文件名：TCPServer
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：Socket通信中的服务器
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/24 21:16:57
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
    public class AsyncTCPServer:IDisposable
    {
        private TcpListener tcplistener;
        private int port;
        private int maxConnectCount;
        private bool isLintening = false;
        private List<AsyncTCPClient> connections;

        private Encoding m_Encoding;
        #region 构造函数

        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="port"></param>
        public AsyncTCPServer(int port) :
            this(IPAddress.Any, port)
        { }


        /// <summary>
        /// 异步TCP客户端
        /// </summary>
        /// <param name="serverLocalEP"></param>
        /// <param name="bufferSize"></param>
        /// <param name="_maxConnectionCount"></param>
        public AsyncTCPServer(IPEndPoint serverLocalEP, int bufferSize, int _maxConnectionCount) :
            this(serverLocalEP.Address, serverLocalEP.Port, bufferSize, _maxConnectionCount)
        { }


        /// <summary>
        /// 异步TCP服务器
        /// </summary>
        /// <param name="localIPAddress">服务器制定IP</param>
        /// <param name="port">服务器端口号</param>
        /// <param name="bufferSize">服务器接收缓存区大小</param>
        /// <param name="_maxConnectCount">服务器最多连接客户端数量</param>
        public AsyncTCPServer(IPAddress localIPAddress,
            int port, int bufferSize = 1024, int _maxConnectCount = 99)
        {
            this.maxConnectCount = _maxConnectCount;
            this.port = port;
            m_Encoding = Encoding.Default;
            connections = new List<AsyncTCPClient>();
            if (localIPAddress == null)
                tcplistener = new TcpListener(IPAddress.Any, port);
            else
                tcplistener = new TcpListener(localIPAddress, port);

            tcplistener.Server.ReceiveBufferSize = bufferSize;
        }

        #endregion


        #region 属性

        /// <summary>
        /// 获取服务器EndPoint
        /// </summary>
        public IPEndPoint LocalEndPoint
        {
            get { return tcplistener.LocalEndpoint as IPEndPoint; }
        }

        /// <summary>
        /// 获取或设置服务器接收缓冲区大小
        /// </summary>
        public int BufferSize
        {
            get { return tcplistener.Server.ReceiveBufferSize; }
            set
            {
                tcplistener.Server.ReceiveBufferSize = value;
            }
        }

        /// <summary>
        /// 获取服务器端口号
        /// </summary>
        public int Port
        {
            get { return port; }
        }

        /// <summary>
        /// 获取服务器最多可连接客户端的数量
        /// </summary>
        public int MaxConnectCount
        {
            get { return maxConnectCount; }
        }

        /// <summary>
        /// 获取链接在服务器你上的所有客户端
        /// </summary>
        public List<AsyncTCPClient> Connections
        {
            get { return connections; }
        }

        /// <summary>
        /// 获取或设置服务器通信时所用的编码
        /// </summary>
        public Encoding Encoding
        {
            get { return m_Encoding; }
            set
            {
                foreach (var item in connections)
                {
                    item.Encoding = value;
                    m_Encoding = value;
                }
            }
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 服务器开始侦听客户端
        /// </summary>
        public void BeginListen()
        {
            if (isLintening)
                return;
            //开始侦听客户端
            try
            {
                tcplistener.Start(maxConnectCount);
                isLintening = true;
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                    "服务器侦听出错！", ex);
                throw ex;
            }

            //开始接受客户端的接入
            try
            {
                tcplistener.BeginAcceptTcpClient(AsyncAcceptCallBack, tcplistener);
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                   "接受客户端连接出错！", ex);
                throw;
            }
        }

        /// <summary>
        /// 关闭服务器
        /// </summary>
        public void Close()
        {
            if (!isLintening) return;

            isLintening = false;
            tcplistener.Stop();
            lock (connections)
            {
                foreach (var item in connections)
                {
                    item.Close();
                }
                connections.Clear();
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        public void Send(AsyncTCPClient client, string data)
        {
            try
            {
                Send(client, this.m_Encoding.GetBytes(data));
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify( Notifier.NotifyLevel.ERROR,
                    "服务器发送数据出错.",ex);
            }
          
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        public void Send(AsyncTCPClient client, byte[] data)
        {
            try
            {
                client.Send(data);
            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.ERROR,
                                    "服务器发送数据出错.", ex);
            }
        }


        #endregion

        #region 私有方法

        /// <summary>
        /// 客户端接入服务器的回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void AsyncAcceptCallBack(IAsyncResult ar)
        {
            TcpListener listener;
            AsyncTCPClient asyncClient;
            try
            {
                listener = ar.AsyncState as TcpListener;
                TcpClient client = listener.EndAcceptTcpClient(ar);
                asyncClient = new AsyncTCPClient(client, this.Encoding);

                lock (connections)
                {
                    connections.Add(asyncClient);
                }
                OnClienConnect(asyncClient);          
            }
            catch (Exception ex)
            {
                CommonModules.Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.FATAL,"接受客户端接入时发生致命性错误",ex);
                throw ex;
            }

            //开始异步接受数据
            byte[] buffer = new byte[tcplistener.Server.ReceiveBufferSize];
            asyncClient.Client.GetStream().BeginRead(buffer, 0, buffer.Length, BeginReceiveCallBack,
                new TCPClientState(asyncClient, buffer));
            //继续等待客户端连接
            if (connections.Count < this.MaxConnectCount)
            {
                tcplistener.BeginAcceptTcpClient(AsyncAcceptCallBack, listener);
            }
        }

       /// <summary>
       /// 接受数据回调
       /// </summary>
       /// <param name="ar"></param>
        private void BeginReceiveCallBack(IAsyncResult ar)
        {
            TCPClientState clientState = ar.AsyncState as TCPClientState;
            int numReadBytesLength = 0;
            try
            {
                numReadBytesLength=clientState.TcpClient.Client.GetStream().EndRead(ar);

            }
            catch (Exception ex)
            {
                Notifier.NotifyHelper.Notify( Notifier.NotifyLevel.ERROR,
                    string.Format("接收客户端 {0}:{1} 数据出错",clientState.TcpClient.Address[0],
                    clientState.TcpClient.Port),ex);
                OnServerOccurredException(clientState.TcpClient.Address, clientState.TcpClient.Port,ex);
            }
            if (numReadBytesLength == 0)
            {
                clientState.TcpClient.Close();
                lock (connections)
                {
                    connections.Remove(clientState.TcpClient);
                }
                //Trigger Clinet Disconnect Event
                OnClientDisconnect(clientState.TcpClient.Address[0], clientState.TcpClient.Port);
                return;
            }
            else
            {
                byte[] buffer = clientState.Buffer;
                byte[] receiveBytes = new byte[buffer.Length];
                Buffer.BlockCopy(buffer,0,receiveBytes,0, buffer.Length);
                //on Server Reveive Data Event.
                OnServerReceiveDatagram(clientState.TcpClient,receiveBytes);

                //Read data from networkstream again.
                clientState.TcpClient.Client.GetStream().BeginRead(buffer,0,
                    buffer.Length, BeginReceiveCallBack,clientState);
            }
        }

        /// <summary>
        /// 引发客户端连接到服务器事件
        /// </summary>
        /// <param name="client">接入服务器的客户端</param>
        protected virtual void OnClienConnect(AsyncTCPClient client)
        {
            ClientConnected?.Invoke(this,
                new TcpClientConnectedEventArgs(client));
        }

        /// <summary>
        /// 引发客户端断开连接事件
        /// </summary>
        /// <param name="ipAddr">IP地址</param>
        /// <param name="port">端口号</param>
        protected virtual void OnClientDisconnect(IPAddress ipAddr, int port)
        {
            ClientDisconnect?.Invoke(this, 
                new TCPClientDisConnectedEventArgs(ipAddr, port));
        }

        /// <summary>
        /// 服务于客户端连接发生异常
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="innerException">内部异常</param>
        protected virtual void OnServerOccurredException(IPAddress[] ipAddress, int port, Exception innerException)
        {
            ServerOccurredException?.Invoke(this,
                new TCPServerExceptionOccurredEventArgs(ipAddress, port, innerException));
        }

        /// <summary>
        /// 服务器接受客户端报文数据事件
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="datagram">数据报文</param>
        protected virtual void OnServerReceiveDatagram(AsyncTCPClient client,byte[] datagram)
        {
            ServerReceiveDatagram?.Invoke(this,
                new TCPDatagramReceiveEventArgs<byte[]>(client,datagram));
        }
        #endregion

        #region 委托


        #endregion

        #region 事件

        /// <summary>
        /// 客户端连接到服务器事件
        /// </summary>
        public event EventHandler<TcpClientConnectedEventArgs> ClientConnected;

        /// <summary>
        /// 客户端与服务器断开连接事件
        /// </summary>
        public event EventHandler<TCPClientDisConnectedEventArgs> ClientDisconnect;
        /// <summary>
        /// 服务器接收到报文数据事件
        /// </summary>
        public event EventHandler<TCPDatagramReceiveEventArgs<byte[]>> ServerReceiveDatagram;

        /// <summary>
        /// 服务器与客户端连接发生异常事件
        /// </summary>
        public event EventHandler<TCPServerExceptionOccurredEventArgs> ServerOccurredException;

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
                    try
                    {
                        Close();
                        if (tcplistener != null)
                            tcplistener = null;
                    }
                    catch (Exception ex)
                    {
                        Notifier.NotifyHelper.Notify(Notifier.NotifyLevel.INFO,
                            string.Format("服务器 {0}:{1} 析构出错！",
                            this.LocalEndPoint.Address.ToString(), this.Port), ex);
                    }
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AsyncTCPServer() {
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
