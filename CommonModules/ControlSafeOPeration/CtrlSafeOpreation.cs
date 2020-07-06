using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Windows.Forms;


//**********************************************
//文件名：CtrlSafeOpreation
//命名空间：CommonModules.ControlSafeOPeration
//CLR版本：4.0.30319.42000
//内容：控件安全操作
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/2/26 13:06:09
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.ControlSafeOPeration
{
  
   public static class CtrlSafeOperation
    {

        /// <summary>
        /// 控件同步安全操作
        /// </summary>
        /// <param name="ctrl">控件对象</param>
        /// <param name="act">控件操作方法</param>
        public static void InvokeSafeOperation(Control ctrl,Action act)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(() => {
                    act.Invoke();
                }));
            }
            else
            {
                act.Invoke();
            }
          
        }
    }
}
