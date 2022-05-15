using System;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class NewsForm : DevExpress.XtraEditors.XtraForm
    {
        public NewsForm()
        {
            InitializeComponent();
        }

        private void NewsForm_Load(object sender, EventArgs e)
        {

        }

        private void NewsForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}