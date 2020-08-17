using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CefSharp.WinForms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Process p;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

           

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        public ChromiumWebBrowser browser;
        private void InitBrowser()
        {
            try
            {
                if (!Cef.IsInitialized)
                {
                    CefSettings settings = new CefSettings();
                    settings.BrowserSubprocessPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "CefSharp.BrowserSubprocess.exe");

                    Cef.Initialize(settings);
                }
                string url = "http://ranpk-ph.com/auth/facebook_launcher/";

                browser = new ChromiumWebBrowser(url);
                this.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;

                browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            if (((ChromiumWebBrowser)sender).IsBrowserInitialized)
            {
                //if needed then use dev tool
                browser.ShowDevTools();
            }
        }
    }
}
