using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZcClient
{
    public partial class FormPrint : Form
    {

        public string printContent { get; set; }
        public FormPrint()
        {
            InitializeComponent();
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            try
            {
                //ResponseData response = JsonConvert.DeserializeObject<ResponseData>(printContent);
                //printContent = "医院自助机挂号凭条\n\n";
                //printContent += "挂号号:" + response.responseData.registerId + "\n\n";
                //printContent += "挂号类型:" + response.responseData.registerType + "\n\n";
                //printContent += "挂号科室:" + response.responseData.officeName+ "\n\n";
                //printContent += "患者姓名:" + response.responseData.patientname + "\n";
                //printContent += "患者年龄:" + response.responseData.age + "\n";
                //printContent += "患者性别:" + response.responseData.sex + "\n";
                printDocument1.Print();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.Margins.Top = 0;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            //下面这个也设成高质量
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.HasMorePages = false;

            string str = "";
            //下面这个也设成高质量
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.HasMorePages = false;
            Font titleFont = new Font("黑体", 16, System.Drawing.FontStyle.Bold);//标题字体           
            Font titleFont2 = new Font("黑体", 14, System.Drawing.FontStyle.Bold);//标题字体           
            Font fntTxt = new Font("黑体", 12, System.Drawing.FontStyle.Regular);//正文文字         
            Font fntTxt1 = new Font("黑体", 10, System.Drawing.FontStyle.Regular);//正文文字           
            System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.Black);//画刷           
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black);//线条颜色         

            try
            {

                //printDocument5.DefaultPageSettings.PaperSize.Width = 299;//请注意，这里是单位：（百分之一英寸）
                //printDocument5.DefaultPageSettings.PaperSize.Height = 100;//请注意，这里是单位：（百分之一英寸）
                //e.PageSettings.PaperSize.Width = 299;//请注意，这里是单位：（百分之一英寸）
                //e.PageSettings.PaperSize.Height = 30;//请注意，这里是单位：（百分之一英寸）
                e.Graphics.DrawString($"{printContent}", fntTxt, brush, new System.Drawing.Point(26, 58));

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
