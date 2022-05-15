using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Message = WorkFollow.Entitiy.Message;

namespace WorkFollow.Forms
{
    public partial class DeleteMessage : DevExpress.XtraEditors.XtraForm
    {
        public DeleteMessage()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private void DeleteMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        void List()
        {
            gridControl1.DataSource = (from x in db.Message.Where(x => x.Receiver == Entitiy.Trash.ID2 && x.Status == false)
                                       select new
                                       {
                                           x.ID,
                                           x.Sender,
                                           Gonderen = x.Company1.CompanyName,
                                           Yetkili = x.Company1.CompanyOfficial,
                                           Icerik = x.MessageContent,
                                           Tarih = x.C_Date,
                                           Durum = x.Status,
                                           Okudummu = x.IsRead,
                                       }).ToList().OrderByDescending(x => x.ID);
            if (gridView1.RowCount != 0)
            {
                gridView1.Columns[5].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[1].Visible = false;
                gridView1.Columns[4].Visible = false;
            }
        }
        private void DeleteMessage_Load(object sender, EventArgs e)
        {
            List();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            webBrowser1.DocumentText = (string)gridView1.GetFocusedRowCellValue("Icerik");
        }
        private void mesajSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(gridView1.GetFocusedRowCellValue("ID") is null))
            {
                Message values = db.Message.Find(gridView1.GetFocusedRowCellValue("ID"));
                values.Status = true;
                db.SaveChanges();
                List();
                return;
            }
            XtraMessageBox.Show("LÜTFEN LİSTEDEN BİR DEĞER SEÇİNİZ !!", "HATALI SEÇİM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}