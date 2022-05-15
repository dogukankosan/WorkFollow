using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class PassiveTask : DevExpress.XtraEditors.XtraForm
    {
        public PassiveTask()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        void List()
        {
            gridControl1.DataSource = (from x in db.Taskes.Where(x => x.Status == false && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2))
                                       select new
                                       {
                                           x.ID,
                                           GorevVeren = x.Company.CompanyName + " " + x.Company.CompanyOfficial,
                                           GorevAlan = x.Personeles.PersonelName + " " + x.Personeles.PersonelSurname,
                                           Aciklama = x.TaskDesc,
                                           Tarih = x.TaskDate,
                                           Durum = x.Status
                                       }).ToList().OrderByDescending(x => x.ID);
            if (gridView1.RowCount > 0)
            {
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[4].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
        }
        private void PassiveTask_Load(object sender, EventArgs e)
        {
            List();
            if (!(Home.isadmincontrol))
                göreviGeriGetirToolStripMenuItem.Visible = false;
        }

        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\PassiveTask.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCELE ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pDFAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\PassiveTask.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PassiveTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Forms.TaskDetails dt = new() { id = Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")) };
            dt.ShowDialog();
        }

        private void göreviGeriGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskes deger = db.Taskes.Find(gridView1.GetFocusedRowCellValue("ID"));
            if (deger is null)
            {
                XtraMessageBox.Show("LÜTFEN DURUMU DEĞİŞTİRELECEK DEĞERİ LİSTEDEN SEÇİNİZ !!",
                    "LÜTFEN SEÇİM YAPINIZ !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            deger.Status = true;
            db.SaveChanges();
            List();
        }
    }
}