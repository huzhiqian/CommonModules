using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;


//**********************************************
//文件名：SaveImageType
//命名空间：CommonModules.SaveImage
//CLR版本：4.0.30319.42000
//内容：
//功能：
//文件关系：
//作者：胡志乾
//小组：
//生成日期：2020/6/19 13:35:26
//版本号：V1.0.0.0
//修改日志：
//版权说明：
//联系电话：18352567214
//**********************************************

namespace CommonModules.SaveImage
{
    public enum SaveImageType
    {
        /// <summary>
        /// 不保存图像
        /// </summary>
        PNG = 1,
        /// <summary>
        /// 将图像保存的bmp格式
        /// </summary>
        BMP = 2,
        /// <summary>
        /// 将图像保存成jpg格式
        /// </summary>
        JPG = 3,
    }
}
