using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class ActiveTask : DevExpress.XtraEditors.XtraForm
    {
        public ActiveTask()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        void List()
        {
            gridControl1.DataSource = (from x in db.Taskes.Where(x => x.Status == true && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2))
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
        private void ActiveTask_Load(object sender, EventArgs e)
        {
            List();
            if (!(Home.isadmincontrol))
                tamamlaGöreviToolStripMenuItem.Visible = false;
        }
        private void ActiveTask_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\ActiveTask.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\ActiveTask.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Forms.TaskDetails dt = new() { id = Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")) };
            dt.ShowDialog();
        }

        private void tamamlaGöreviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Taskes deger = db.Taskes.Find(gridView1.GetFocusedRowCellValue("ID"));
            if (deger is null)
            {
                XtraMessageBox.Show("LÜTFEN DURUMU DEĞİŞTİRELECEK DEĞERİ LİSTEDEN SEÇİNİZ !!",
                    "LÜTFEN SEÇİM YAPINIZ !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            deger.Status = false;
            db.SaveChanges();
            List();
        }
    }
}