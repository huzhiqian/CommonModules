using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：TCPClientState
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：Internal Class to join the TCP client and buffer
//     together for easy management in the server
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/26 9:51:58
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
   internal class TCPClientState
    {

        #region 构造函数

        public TCPClientState(AsyncTCPClient client,byte[] buffer)
        {
            TcpClient = client;
            Buffer = buffer;
        }

        #endregion


        #region 属性

        /// <summary>
        /// Get the TCP Clientt
        /// </summary>
        public AsyncTCPClient TcpClient { get; private set; }

        /// <summary>
        /// Get the Buffer
        /// </summary>
        public byte[] Buffer { get; private set; }
        #endregion

       
    }
}
