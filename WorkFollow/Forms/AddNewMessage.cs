using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WorkFollow.Forms
{
    public partial class AddNewMessage : DevExpress.XtraEditors.XtraForm
    {
        public AddNewMessage()
        {
            InitializeComponent();
        }

        private readonly Entitiy.DbWorkFollowEntities db = new();

        void List()
        {
            gridControl1.DataSource = (from x in db.Company
                select new
                {
                    x.ID,
                    Sirket = x.CompanyName,
                    Yetkili = x.CompanyOfficial,
                    Tel = x.CompanyTel,
                    Mail = x.CompanyMail,
                    Faaliyet = x.CompanyActivity,
                    x.Iller.Il,
                    x.Ilceler.Ilce,
                    Adres = x.CompanyAdress,
                    Resim = x.CompanyImage
                }).OrderByDescending(x => x.Sirket).ToList();
            gridView1.Columns[0].Visible = false;
        }
        private void AddNewMessage_Load(object sender, EventArgs e)
        {
           List();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (!(gridView1.GetFocusedRowCellValue("ID") is null))
            {
                AddMessage msg = new();
                msg.id = (short)gridView1.GetFocusedRowCellValue("ID");
                msg.ShowDialog();
             return;
            }
            XtraMessageBox.Show("LÜTFEN LİSTEDEN BİR DEĞER SEÇİNİZ !!", "HATALI SEÇİM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddNewMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}