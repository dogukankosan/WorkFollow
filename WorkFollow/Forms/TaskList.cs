using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class TaskList : DevExpress.XtraEditors.XtraForm
    {
        public TaskList()
        {
            InitializeComponent();
        }

        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        private void tasklist()
        {
            gridControl1.DataSource = (from x in db.Taskes.Where(x => x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2)
                                       select new
                                       {
                                           x.ID,
                                           GorevAlan = string.Concat(x.Personeles.PersonelName, " ", x.Personeles.PersonelSurname),
                                           GorevVeren = string.Concat(x.Company.CompanyName, " ", x.Company.CompanyOfficial),
                                           GorevAciklama = x.TaskDesc,
                                           Tarih = x.TaskDate,
                                           Durum = x.Status
                                       }).ToList().OrderByDescending(x => x.Tarih);
            if (gridView1.RowCount > 0)
            {
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[4].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
        }
        void GridList()
        {
            Lbl_ActiveJobCount.Text = db.Taskes.Count(x => x.Status == true && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2)).ToString();
            Lbl_PassiveJobCount.Text = db.Taskes.Count(x => x.Status == false && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2)).ToString();
            chartControl1.Series[0].Points.AddPoint("AKTIF GOREV", Convert.ToInt16(Lbl_ActiveJobCount.Text));
            chartControl1.Series[0].Points.AddPoint("PASIF GOREV", Convert.ToInt16(Lbl_PassiveJobCount.Text));
            Lbl_DepartCount.Text = db.Department.Count().ToString();
        }
        private void TaskList_Load(object sender, EventArgs e)
        {
            GridList();
            tasklist();
            if (!(Home.isadmincontrol))
                görevTamamlandıToolStripMenuItem.Visible = false;
        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Gorevler.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Gorevler.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\GorevlerChart.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void excelAlToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\GorevlerChart.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaskList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Forms.TaskDetails dt = new() { id = Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")) };
            dt.ShowDialog();
        }

        private void görevTamamlandıToolStripMenuItem_Click(object sender, EventArgs e)
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
            tasklist();
            GridList();
        }
    }
}