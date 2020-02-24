using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net.Sockets;


//**********************************************
//文件名：TCPDatagramReceiveEventArgs
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/23 15:45:00
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
   public class TCPDatagramReceiveEventArgs<T>:EventArgs
    {
        /// <summary>
        /// 接收报文数据事件参数
        /// </summary>
        /// <param name="tcpClient">客户端</param>
        /// <param name="datagram">报文数据</param>
        public TCPDatagramReceiveEventArgs(TcpClient tcpClient, T datagram)
        {
            this.TcpClient = tcpClient;
            this.DataGram = datagram;
        }

        #region 属性

        /// <summary>
        /// 客户端
        /// </summary>
        public TcpClient TcpClient { get; private set; }

        /// <summary>
        /// 报文数据
        /// </summary>
        public T DataGram { get; private set; }
        #endregion
    }
}
