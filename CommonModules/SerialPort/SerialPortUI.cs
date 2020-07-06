using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonModules.SerialPort
{
    public partial class SerialPortUI : UserControl
    {
        private CSerialPort _subject = null;

        public SerialPortUI()
        {
            InitializeComponent();
        }


        public CSerialPort Subject
        {
            get { return _subject; }
            set
            {
                if (value != null)
                {
                    _subject = value;
                    //
                    SubjectChanged();
                    _subject.OpenStateChanged -= PortOpenStateChanged;
                    _subject.OpenStateChanged+= PortOpenStateChanged;
                }
            }
        }

        private void SerialPortUI_Load(object sender, EventArgs e)
        {
            //获取系统串口列表
            string[] sysPorts = System.IO.Ports.SerialPort.GetPortNames();
            foreach (var item in sysPorts)
            {
                cb_SerialPortNames.Items.Add(item);
            }
            SetUICtrlEnable();
        }

        private void SetUICtrlEnable()
        {
            if (_subject != null)
            {
                gb_BaudRate.Enabled = true;
                gb_DataBit.Enabled = true;
                cmb_Parity.Enabled = true;
                cmb_StopBit.Enabled = true;
                if (_subject.IsOPened)
                {
                    btn_OpenPort.Enabled = false;
                    btn_ClosePort.Enabled = true;
                }
                else
                {
                    btn_OpenPort.Enabled = true;
                    btn_ClosePort.Enabled = false;
                }
            }
        }


        private void SubjectChanged()
        {
            SetUICtrlEnable();
            SetSubjectPortBaudRate();
            SetSubjectDataBit();
            SetSubjectParity();
            SetSubjectStopBit();
            cb_SerialPortNames.Invoke(new Action(()=> {
                cb_SerialPortNames.Text = _subject.PortName;
            }));
        }

        private void SetSubjectPortBaudRate()
        {
            switch (_subject.BaudRate)
            {
                case 2400:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        rb_baudRate2400, new Action(() =>
                        {
                            rb_baudRate2400.Checked = true;
                        }));
                    break;
                case 4800:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                      rb_baudRate4800, new Action(() =>
                      {
                          rb_baudRate4800.Checked = true;
                      }));
                    break;
                case 7200:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                      rb_baudRate7200, new Action(() =>
                      {
                          rb_baudRate7200.Checked = true;
                      }));
                    break;
                case 9600:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                     rb_baudRate9600, new Action(() =>
                     {
                         rb_baudRate9600.Checked = true;
                     }));
                    break;
                case 14400:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                     rb_baudRate14400, new Action(() =>
                     {
                         rb_baudRate14400.Checked = true;
                     }));
                    break;
                case 19600:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                     rb_baudRate19600, new Action(() =>
                     {
                         rb_baudRate19600.Checked = true;
                     }));
                    break;
                case 28800:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                    rb_baudRate28800, new Action(() =>
                    {
                        rb_baudRate28800.Checked = true;
                    }));
                    break;
                case 38400:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                   rb_baudRate38400, new Action(() =>
                   {
                       rb_baudRate38400.Checked = true;
                   }));
                    break;
                case 57600:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                  rb_baudRate57600, new Action(() =>
                  {
                      rb_baudRate57600.Checked = true;
                  }));
                    break;
                case 115200:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                rb_baudRate115200, new Action(() =>
                {
                    rb_baudRate115200.Checked = true;
                }));
                    break;
                case 128000:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                rb_baudRate128000, new Action(() =>
                {
                    rb_baudRate128000.Checked = true;
                }));
                    break;
                case 256000:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
               rb_baudRate256000, new Action(() =>
               {
                   rb_baudRate256000.Checked = true;
               }));
                    break;
                default:
                    break;
            }
        }

        private void SetSubjectDataBit()
        {
            switch (_subject.DataBit)
            {
                case 5:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        rb_DataBit5, new Action(() =>
                        {
                            rb_DataBit5.Checked = true;
                        }));
                    break;
                case 6:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        rb_DataBit6, new Action(() =>
                        {
                            rb_DataBit6.Checked = true;
                        }));
                    break;
                case 7:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                       rb_DataBit7, new Action(() =>
                       {
                           rb_DataBit7.Checked = true;
                       }));
                    break;
                case 8:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                       rb_DataBit8, new Action(() =>
                       {
                           rb_DataBit8.Checked = true;
                       }));
                    break;
                default:
                    break;
            }
        }

        private void SetSubjectParity()
        {
            switch (_subject.PortParity)
            {
                case System.IO.Ports.Parity.None:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_Parity, new Action(() =>
                        {
                            cmb_Parity.SelectedIndex = 0;
                        }));
                    break;
                case System.IO.Ports.Parity.Odd:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_Parity, new Action(() =>
                        {
                            cmb_Parity.SelectedIndex = 1;
                        }));
                    break;
                case System.IO.Ports.Parity.Even:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_Parity, new Action(() =>
                        {
                            cmb_Parity.SelectedIndex = 2;
                        }));
                    break;
                case System.IO.Ports.Parity.Mark:
                    break;
                case System.IO.Ports.Parity.Space:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                cmb_Parity, new Action(() =>
                {
                    cmb_Parity.SelectedIndex = 3;
                }));
                    break;
                default:
                    break;
            }
        }

        private void SetSubjectStopBit()
        {
            switch (_subject.PortStopBit)
            {
                case System.IO.Ports.StopBits.One:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_StopBit, new Action(() => {
                            cmb_StopBit.SelectedIndex = 0;
                        }));
                    break;
                case System.IO.Ports.StopBits.Two:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_StopBit, new Action(() => {
                            cmb_StopBit.SelectedIndex = 2;
                        }));
                    break;
                case System.IO.Ports.StopBits.OnePointFive:
                    CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                        cmb_StopBit, new Action(() => {
                            cmb_StopBit.SelectedIndex = 1;
                        }));
                    break;
                default:
                    break;
            }
        }

        //打开端口
        private void btn_OpenPort_Click(object sender, EventArgs e)
        {
            _subject.OpenSerialPort();
        }

        //关闭端口
        private void btn_ClosePort_Click(object sender, EventArgs e)
        {
            _subject.ClosePort();
        }

        private void PortOpenStateChanged(bool state)
        {
            if (state)
            {
                CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                    btn_OpenPort, new Action(() =>
                    {
                        btn_OpenPort.Enabled = false;
                    }));

                CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                    btn_ClosePort, new Action(() =>
                    {
                        btn_ClosePort.Enabled = true;
                    }));
            }
            else
            {
                CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                    btn_OpenPort, new Action(() =>
                    {
                        btn_OpenPort.Enabled = true;
                    }));

                CommonModules.ControlSafeOPeration.CtrlSafeOperation.InvokeSafeOperation(
                    btn_ClosePort, new Action(() =>
                    {
                        btn_ClosePort.Enabled = false;
                    }));
            }
        }

        #region 设置波特率

        private void rb_baudRate2400_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate2400.Checked)
                {
                    _subject.BaudRate = 2400;
                }
            }
        }

        private void rb_baudRate4800_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate4800.Checked)
                {
                    _subject.BaudRate = 4800;
                }
            }
        }

        private void rb_baudRate7200_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate7200.Checked)
                {
                    _subject.BaudRate = 7200;
                }
            }
        }

        private void rb_baudRate9600_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate9600.Checked)
                {
                    _subject.BaudRate = 9600;
                }
            }
        }

        private void rb_baudRate14400_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate14400.Checked)
                {
                    _subject.BaudRate = 14400;
                }
            }
        }

        private void rb_baudRate19600_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate19600.Checked)
                {
                    _subject.BaudRate = 19600;
                }
            }
        }

        private void rb_baudRate28800_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate28800.Checked)
                {
                    _subject.BaudRate = 28800;
                }
            }
        }

        private void rb_baudRate38400_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate38400.Checked)
                {
                    _subject.BaudRate = 38400;
                }
            }
        }

        private void rb_baudRate57600_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate57600.Checked)
                {
                    _subject.BaudRate = 57600;
                }
            }
        }

        private void rb_baudRate115200_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate115200.Checked)
                {
                    _subject.BaudRate = 115200;
                }
            }
        }

        private void rb_baudRate128000_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate128000.Checked)
                {
                    _subject.BaudRate = 128000;
                }
            }
        }

        private void rb_baudRate256000_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_baudRate256000.Checked)
                {
                    _subject.BaudRate = 256000;
                }
            }
        }



        #endregion

        #region 设置数据位

        private void rb_DataBit5_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_DataBit5.Checked)
                    _subject.DataBit = 5;
            }
        }

        private void rb_DataBit6_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_DataBit6.Checked)
                    _subject.DataBit = 6;
            }
        }

        private void rb_DataBit7_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_DataBit7.Checked)
                    _subject.DataBit = 7;
            }
        }

        private void rb_DataBit8_CheckedChanged(object sender, EventArgs e)
        {
            if (_subject != null)
            {
                if (rb_DataBit8.Checked)
                    _subject.DataBit = 8;
            }
        }


        #endregion

        #region 设置校验方式

        private void cmb_Parity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_subject == null) return;
            if (cmb_Parity.SelectedIndex != -1)
            {
                switch (cmb_Parity.SelectedIndex)
                {
                    case 0:
                        _subject.PortParity = System.IO.Ports.Parity.None;
                        break;
                    case 1:
                        _subject.PortParity = System.IO.Ports.Parity.Odd;
                        break;
                    case 2:
                        _subject.PortParity = System.IO.Ports.Parity.Even;
                        break;
                    case 3:
                        _subject.PortParity = System.IO.Ports.Parity.Space;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region 设置停止位

        private void cmb_StopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_subject == null) return;
            if (cmb_StopBit.SelectedIndex != -1)
            {
                switch (cmb_StopBit.SelectedIndex)
                {
                    case 0:
                        _subject.PortStopBit = System.IO.Ports.StopBits.One;
                        break;
                    case 1:
                        _subject.PortStopBit = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case 2:
                        _subject.PortStopBit = System.IO.Ports.StopBits.Two;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        private void cb_SerialPortNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_SerialPortNames.SelectedIndex != -1)
            {
                string portName = cb_SerialPortNames.Text;
                _subject.PortName = portName;
            }
        }
    }
}
