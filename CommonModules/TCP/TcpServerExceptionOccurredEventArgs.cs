using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Net;
using System.Globalization;


//**********************************************
//文件名：TcpServerExceptionOccurredEventArgs
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：与服务器连接发生异常事件参数
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/23 15:56:58
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
   public class TCPServerExceptionOccurredEventArgs:EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="innerException"></param>
        public TCPServerExceptionOccurredEventArgs(
            IPAddress[] ipAddress,int port,Exception innerException)
        {
            if (ipAddress != null)
                throw new ArgumentNullException("IpAddress");
            this.Address = ipAddress;
            this.Port = port;
        }

        #region 属性

        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public IPAddress[] Address { get; private set; }

        /// <summary>
        /// 服务器端口
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// 内部异常
        /// </summary>
        public Exception Exception { get; private set; }


        #endregion

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var item in Address)
            {
                s = s + item.ToString() + ',';
            }
            s = s.TrimEnd(',');
            s = s + ":" + Port.ToString(CultureInfo.InstalledUICulture);
            return s;

        }
    }
}
