
using Newtonsoft.Json;
using System.Threading;
using System.Xml;

namespace ZcClient
{
    public class JavascriptObjectTest
    {

        /// <summary>
        /// 读取身份证
        /// </summary>
        /// <returns></returns>
        public string readIdCard()
        {
            Thread.Sleep(5000);

            string result = "<return name=\"SHENFENZHENG\"><arguments><string id=\"ERROR\">SUCCESS</string><string id=\"IDNAME\">黄孟伟</string><string id=\"SEX\">男</string><string id=\"BORN\">19930320</string><string id=\"ADDRESS\">陕西省西咸新区秦汉新城窑店街道黄家沟515号</string><string id=\"IDCARDNO\">610404199312312113050</string><string id=\"NATION\">汉</string><string id=\"NATIONCODE\">01</string></arguments></return>";
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
