using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：ReceiveMsgEventArgs
//命名空间：SerialPortTest.SerialPort
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/5/27 19:56:34
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SerialPort
{
   public class ReceiveMsgEventArgs:EventArgs
    {
        private string message = string.Empty;
        public ReceiveMsgEventArgs(string msg)
        {
            message = msg;
        }

        public string Message
        {
            get { return message; }
        }

    }
}
