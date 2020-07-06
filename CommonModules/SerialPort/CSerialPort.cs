using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO.Ports;

//**********************************************
//文件名：CSerialPort
//命名空间：SerialPortTest.SerialPort
//CLR版本：4.0.30319.42000
//内容：收发数据
//功能：串口通信功能类
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/5/27 16:22:44
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SerialPort
{
   public class CSerialPort:IDisposable
    {
        private System.IO.Ports.SerialPort serialPort = null;
        #region 构造函数

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="portName">端口名</param>
        /// <param name="baudRate">波特率</param>
        public CSerialPort(string portName, int baudRate) :
            this(portName, baudRate,1024, 3,8, Parity.Even, StopBits.One)
        { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="portName">端口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="bufferSize">接收缓冲区大小</param>
        public CSerialPort(string portName, int baudRate,int bufferSize):
        this(portName, baudRate, bufferSize,3, 8, Parity.Even, StopBits.One)
        { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="portName">端口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="bufferSize">接收缓冲区大小</param>
        /// <param name="readTimeOut">超时时间</param>
        public CSerialPort(string portName, int baudRate, int bufferSize,int readTimeOut):
            this(portName, baudRate, bufferSize, readTimeOut, 8, Parity.Even, StopBits.One)
        { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="portName">端口名</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="bufferSize">接收缓冲区大小</param>
        /// <param name="readTimeOut">接收超时时间</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="parity">检验方式</param>
        /// <param name="stopBits">停止位</param>
        public CSerialPort(string portName, int baudRate, int bufferSize=1024,int readTimeOut=3,int dataBits=8, 
            Parity parity= Parity.Even, StopBits stopBits= StopBits.One)
        {
            serialPort = new System.IO.Ports.SerialPort(portName,baudRate,parity,dataBits,stopBits);
            serialPort.ReadBufferSize = bufferSize;
            serialPort.ReadTimeout = readTimeOut;
            //绑定接收事件
            serialPort.DataReceived += PortReceiveData;
            serialPort.ErrorReceived += ReceivedError;
        }
        #endregion


        #region 属性

        /// <summary>
        /// 获取串口端口号
        /// </summary>
        public string PortName
        {
            get { return serialPort?.PortName; }
            set {
                if (value != null)
                {
                    if (!value.Equals(serialPort.PortName))
                    {
                        serialPort.Close();
                        serialPort.PortName = value;
                        OpenSerialPort();
                    }
                }
            }
        }

        /// <summary>
        /// 获取或设置串口波特率
        /// </summary>
        public int BaudRate
        {
            get { return serialPort!=null?serialPort.BaudRate:-1; }
            set {
                if (value != serialPort.BaudRate)
                {
                    //关闭端口
                    //ClosePort();
                    serialPort.BaudRate = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置串口数据位
        /// </summary>
        public int DataBit
        {
            get { return serialPort.DataBits; }
            set {
                if (value != serialPort.DataBits)
                {
                    //ClosePort();
                    serialPort.DataBits=value;
                }
            }
        }

        /// <summary>
        /// 获取或设置串口校验方式
        /// </summary>
        public Parity PortParity
        {
            get { return serialPort.Parity; }
            set {
                if (value != serialPort.Parity)
                {
                    //ClosePort();
                    serialPort.Parity = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置串口停止位
        /// </summary>
        public StopBits PortStopBit
        {
            get { return serialPort.StopBits; }
            set {
                if (value != serialPort.StopBits)
                {
                    //ClosePort();
                    serialPort.StopBits = value;
                }
            }
        }

        /// <summary>
        /// 获取串口打开状态
        /// </summary>
        public bool IsOPened
        {
            get { return serialPort.IsOpen; }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 打开串口，发开成功返回True,打开失败返回False
        /// </summary>
        /// <returns></returns>
        public bool OpenSerialPort()
        {
            try
            {
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    OpenStateChanged?.Invoke(true);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                CommonModules.Notifier.NotifyHelper.Notify( CommonModules.Notifier.NotifyLevel.FATAL,
                    $"串口{PortName}打开失败，错误信息：{ex.Message}。");
                return false;
            }
        }

        public void ClosePort()
        {
            try
            {
                serialPort.Close();
                //if (serialPort != null)
                //{
                //    serialPort.Dispose();
                //    serialPort = null;
                //}
                OpenStateChanged?.Invoke(false);
            }
            catch (Exception ex)
            {
                CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.FATAL,
                      $"串口{PortName}关闭失败，错误信息：{ex.Message}。");
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public bool SendData(string data)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(data);
                    return true;
                }
                catch (Exception ex)
                {
                    CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.ERROR,
                         $"串口{serialPort.PortName}发送数据失败,错误信息：{ex.Message}。");
                    return false;
                }
            }
            else
            {
                CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.ERROR,
                    $"串口{serialPort.PortName}未打开，发送数据失败！");
                return false;
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Write(data,0,data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.ERROR,
                         $"串口{serialPort.PortName}发送数据失败,错误信息：{ex.Message}。");
                    return false;
                }
            }
            else
            {
                CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.ERROR,
                    $"串口{serialPort.PortName}未打开，发送数据失败！");
                return false;
            }
        }
        #endregion

        #region 私有方法

        private void PortReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] receiveData = new byte[serialPort.BytesToRead];
            try
            {
                int len = serialPort.Read(receiveData, 0, receiveData.Length);
                if (len > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append(Encoding.Default.GetString(receiveData, 0, len));
                    string str = sb.ToString().Trim();
                    str = str.Trim("\n\r".ToCharArray());
                    ReceiveMsgEventArgs msg = new ReceiveMsgEventArgs(str);
                    ReceiveDataEvent?.Invoke(this, msg);
                }
            }
            catch (Exception ex)
            {
                CommonModules.Notifier.NotifyHelper.Notify(CommonModules.Notifier.NotifyLevel.ERROR,
                    $"串口{serialPort.PortName}接收数据出错，错误信息：{ex.Message}。");
            }
            finally
            {
                serialPort.DiscardInBuffer();
            }
          
        }


        private void ReceivedError(object sender, SerialErrorReceivedEventArgs e)
        {
            
        }
        #endregion

        #region 委托



        #endregion

        #region 事件

        public event EventHandler<ReceiveMsgEventArgs> ReceiveDataEvent;

        public event Action<bool> OpenStateChanged;//打开状态改变事件

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
                    if (serialPort != null)
                    {
                        serialPort.Dispose();
                        serialPort = null;
                    }
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~CSerialPort() {
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
