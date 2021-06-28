using Newtonsoft.Json;
using SunRise.HardwareCom;
using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ZcClient
{
    public class HardwareSdk
    {
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
				string result = empty;
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(result);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='IDNAME']");
				Patient patient = new Patient();
				string name = (patient.name = xmlNode.InnerText);
				xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='IDCARDNO']");
				string id = (patient.id = xmlNode.InnerText);
				xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='BORN']");
				patient.brith = xmlNode.InnerText;
				xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='ADDRESS']");
				patient.address = xmlNode.InnerText;
				xmlNode = xmlDocument.SelectSingleNode("/return/arguments/string[@id='SEX']");
				patient.sex = xmlNode.InnerText;
				return JsonConvert.SerializeObject(patient);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return e.Message;
			}

		}
    }
}
