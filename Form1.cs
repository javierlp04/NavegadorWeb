using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace NavegadorWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = this.ClientSize.Width - goButton.Width;
            addressBar.Width = goButton.Left - addressBar.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
            if (webView != null && webView.CoreWebView2 != null)
            {
                if (!addressBar.Text.StartsWith("https://"))
                {
                    addressBar.Text = "https://" + addressBar.Text;
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }
                if(!addressBar.Text.EndsWith(".com"))
                {
                    addressBar.Text = "https://www.google.com/search?q=" + addressBar.Text;
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }
                else
                {
                    webView.CoreWebView2.Navigate(addressBar.Text);
                }
                
            }
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoHome();
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addressBar.SelectedIndex = 0;
            //webBrowser1.GoHome();
        }
    }
}
