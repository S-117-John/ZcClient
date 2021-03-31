using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hardware
{
    public class HardwareSdk
    {
        [DllImport(@"GGXmlTcp.dll")]
        public static extern int XmlTcp(StringBuilder xmlbuf, int timeout);
        public string readIdCard()
        {
            string param = "<invoke name=\"SHENFENZHENG\"><arguments></arguments></invoke>";
            StringBuilder xmlBuff = new StringBuilder(1000);
            xmlBuff.Append(param);
            int ret = XmlTcp(xmlBuff, 1000);
            return xmlBuff.ToString();
        }
    }
}
