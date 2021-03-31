using CefSharp;
using CefSharp.WinForms;
using Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            string url = "http://localhost:8000";
            ChromiumWebBrowser webview = new ChromiumWebBrowser("http://127.0.0.1:9090/page/index.html")
            {
                Dock = DockStyle.Fill,
            };
            //webview.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;

            JavascriptObjectTest test = new JavascriptObjectTest();

            webview.JavascriptObjectRepository.Register("googleBrower", test, isAsync: true, options: BindingOptions.DefaultBinder);

            //webview.JavascriptObjectRepository.Register("googleBrower", new CSObj(), false, CefSharp.BindingOptions.DefaultBinder);
            this.Controls.Add(webview);
        }
    }
}
