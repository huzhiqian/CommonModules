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
//文件名：TCPServerConnectedEventArgs
//命名空间：CommonModules.TCP
//CLR版本：4.0.30319.42000
//内容：与服务器的连接已建立连接事件参数
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/23 15:43:11
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.TCP
{
   public class TCPServerConnectedEventArgs:EventArgs
    {

        /// <summary>
        /// 与服务器的连接已断开事件参数
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        public TCPServerConnectedEventArgs(IPAddress[] ipAddress, int port)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("IPAddress");
            this.Address = ipAddress;
            this.Port = port;
        }

        #region MyRegion

        /// <summary>
        /// 服务器IP地址列表
        /// </summary>
        public IPAddress[] Address { get; private set; }

        /// <summary>
        /// 服务器端口
        /// </summary>
        public int Port { get; private set; }

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
