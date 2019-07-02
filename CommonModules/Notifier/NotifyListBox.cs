using System;
using System.Windows.Forms;

namespace CommonModules.Notifier
{
    public class NotifyListBox : INotifyBoard
    {
        public ListBox infoListCtrl;

        public NotifyListBox(ListBox listCtrl)
        {
            infoListCtrl = listCtrl;
        }
        public void CleraBoard()
        {
            infoListCtrl.Items.Clear();
        }


        #region 属性

        public int MaxDisplayCount { get; set; } = 50;

        #endregion

        #region 公共方法

        public void DisplayNitifyItemInfo(NotifyItem info)
        {           
            DisplayListInfo(info.message);
        }

        #endregion


        #region 私有方法

        private void DisplayListInfo(string msg)
        {
            if (infoListCtrl.InvokeRequired)
            {
                if (infoListCtrl.Items.Count >= MaxDisplayCount)
                    infoListCtrl.Items.RemoveAt(0);
                string _msg=string.Format("{0}  {1}",DateTime.Now.ToString("HH:mm:dd.fff"),msg);
                infoListCtrl.Items.Add(_msg);
                infoListCtrl.SelectedItem = _msg;
            }
            else
            {
                infoListCtrl.Invoke(new Action(()=>
                {
                    if (infoListCtrl.Items.Count >= MaxDisplayCount)
                        infoListCtrl.Items.RemoveAt(0);
                    string _msg = string.Format("{0}  {1}", DateTime.Now.ToString("HH:mm:dd.fff"), msg);
                    infoListCtrl.Items.Add(_msg);
                    infoListCtrl.SelectedItem = _msg;
                }));     
            }
        }

        #endregion


    }
}
