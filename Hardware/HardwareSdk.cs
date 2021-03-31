using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            string result = xmlBuff.ToString();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            XmlNode xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='IDNAME']");
            Patient patient = new Patient();
            string name = xmlNode.InnerText;
            patient.name = name;
            xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='IDCARDNO']");
            string id = xmlNode.InnerText;
            patient.id = id;

            xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='BORN']");
            patient.brith = xmlNode.InnerText;

            xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='ADDRESS']");
            patient.address = xmlNode.InnerText;

            xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='SEX']");
            patient.sex = xmlNode.InnerText;

            string json = JsonConvert.SerializeObject(patient);

            return json;
           
        }
    }
}
