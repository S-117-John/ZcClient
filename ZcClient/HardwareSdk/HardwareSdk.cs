
using Newtonsoft.Json;
using SunRise.HardwareCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ZcClient
{
    public class HardwareSdk
    {
        [DllImport(@"GGXmlTcp.dll")]
        public static extern int XmlTcp(StringBuilder xmlbuf, int timeout);
        public static string readIdCard()
        {
            try
            {
                Hardware com = new Hardware();
                string empty = string.Empty;
                empty = com.CallHardware("<invoke name=\"SHENFENZHENG\"><arguments></arguments></invoke>");
                string param = "<invoke name=\"SHENFENZHENG\"><arguments></arguments></invoke>";
                StringBuilder xmlBuff = new StringBuilder(1000);
                xmlBuff.Append(param);
                //int ret = XmlTcp(xmlBuff, 1000);
                //string result = xmlBuff.ToString();
                string result = empty;
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
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                return e.Message;
            }
          
           
           
        }
    }
}
