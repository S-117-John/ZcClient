

using System;

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
            try
            {
                return HardwareSdk.readIdCard();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public void print(string param)
        {
            FormPrint form = new FormPrint();
            form.printContent = param;
            form.ShowDialog();

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
