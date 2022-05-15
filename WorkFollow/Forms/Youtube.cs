using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class Youtube : DevExpress.XtraEditors.XtraForm
    {
        public Youtube()
        {
            InitializeComponent();
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string html = "<html><head>";
                html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
                html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='1900' height='800' frameborder='0' allowfullscreen></iframe>";
                html += "</head></html>";
                if (textEdit1.Text.Contains("="))
                {
                    this.webBrowser1.DocumentText = string.Format(html, textEdit1.Text.Split('=')[1]);
                }
                else
                {
                    this.webBrowser1.DocumentText = string.Format(html,
                        textEdit1.Text.Remove(0, 23));
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("HATALI URL TÜRÜ LİNKİ DOĞRULAYIN", "HATALI LİNK", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void Youtube_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Youtube_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}