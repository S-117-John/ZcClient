using CefSharp;
using System.Windows.Forms;

namespace ZcClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CefSharp.CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            //CefSharpSettings.WcfEnabled = true;
            //var obj = new CSObj(System.Threading.SynchronizationContext.Current);

            //string url = "http://127.0.0.1:8812/page/index.html";
            string url = "http://172.16.78.28:8812/page/index.html";
            string rootPath = Application.StartupPath.ToString();
            string filePath = rootPath+"\\web\\page\\index.html";
            this.chromiumWebBrowser1.Load(url);
            //ChromiumWebBrowser webview = new ChromiumWebBrowser(url)
            //{
            //    Dock = DockStyle.Fill,
            //};
            //webview.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;

            JavascriptObjectTest test = new JavascriptObjectTest();

            JavascriptObject javascriptObject = new JavascriptObject();

            chromiumWebBrowser1.JavascriptObjectRepository.Register("googleBrower", javascriptObject, isAsync: true, options: BindingOptions.DefaultBinder);

            //webview.JavascriptObjectRepository.Register("googleBrower", new CSObj(), false, CefSharp.BindingOptions.DefaultBinder);
            this.Controls.Add(chromiumWebBrowser1);
        }

    }
}
