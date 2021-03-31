using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZcClient
{
    public class CSObj
    {
        //private System.Threading.SynchronizationContext context;
        //public CSObj(System.Threading.SynchronizationContext context)
        //{
        //    this.context = context;
        //}
        public void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }


        public string GetResult()
        {
            return "htllo";
        }

    }
}
