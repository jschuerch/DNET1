using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P08_NextChange_Forms
{
    public partial class Form1 : Form
    {
        private string emailClientUrl = "https://outlook.office365.com/owa/?realm=zhaw.ch&exsvurl=1&llcc=1033&modurl=0&path=/mail/inboxch";
        private string LogoutUrl = "https://login.microsoftonline.com/common/oauth2/logout?ui_locales=en-US&mkt=en-US";

        private static Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            webBrowser1.Navigate(emailClientUrl);

            buttonEmail.Click += new EventHandler(buttonEmail_Click);
            buttonLogout.Click += new EventHandler(buttonLogout_Click);

            timer.Tick += new EventHandler(setTime);
            timer.Interval = 30000; // every 30 seconds.
            timer.Start();
        }
        private void setTime(object sender, EventArgs e)
        {
            NISTTime.SetTime(NISTTime.GetUniversalTime());
        }

        private void webBrowser1_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = webBrowser1.Document;
            if (e.Url.ToString().StartsWith("https://sts.zhaw.ch/adfs/ls/"))
            {
                HtmlElement userNameElement = doc.GetElementById("userNameInput");
                userNameElement.SetAttribute("value", "<StudentenName>");
                HtmlElement passwordElement = doc.GetElementById("passwordInput");
                passwordElement.SetAttribute("value", "<Passwort>");

                doc.GetElementById("submitButton")?.InvokeMember("click");
            }
            else if (e.Url.ToString().StartsWith("https://login.microsoftonline.com/login.srf"))
            {
                doc.GetElementById("idSIButton9")?.InvokeMember("click");
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(emailClientUrl);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(LogoutUrl);
        }
    }
}
