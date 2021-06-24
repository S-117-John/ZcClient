using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZcClient
{
    public class JavascriptObject
    {
        /// <summary>
        /// 读取身份证
        /// </summary>
        /// <returns></returns>
        public string readIdCard()
        {
            HardwareSdk hardware = new HardwareSdk();

            return hardware.readIdCard(); ;
        }

        /// <summary>
        /// 语音
        /// </summary>
        /// <param name="message"></param>
        public void voice(string message)
        {

        }

        /// <summary>
        /// 金属键盘输入
        /// </summary>
        /// <returns></returns>
        public string input()
        {

            return "";
        }


        /// <summary>
        /// 读取射频卡
        /// </summary>
        /// <returns></returns>
        public string readRefCard()
        {
            return "";
        }
    }
}
