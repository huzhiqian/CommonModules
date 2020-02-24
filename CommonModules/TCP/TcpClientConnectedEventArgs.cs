using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net.Sockets;


//**********************************************
//文件名：TcpClientConnectedEventArgs
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：与客户端的连接已建立事件参数
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/23 17:07:03
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
   public class TcpClientConnectedEventArgs:EventArgs
    {

        public TcpClientConnectedEventArgs(TcpClient client)
        {
            if (client == null)
                throw new ArgumentNullException("TcpClient");
            this.TcpClient = client;
        }


        /// <summary>
        /// 客户端
        /// </summary>
        public TcpClient TcpClient { get; private set; }
    }
}
