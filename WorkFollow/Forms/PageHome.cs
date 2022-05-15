using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class PageHome : DevExpress.XtraEditors.XtraForm
    {
        public PageHome()
        {
            InitializeComponent();
        }

        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new ();
        private void ContinuingJob()
        {
            gridControl1.DataSource = (from x in db.Taskes.Where(x => x.Status)
                                       select new
                                       {
                                           GorevVeren = x.Personeles.PersonelName + " " + x.Personeles.PersonelSurname,
                                           GorevAlan = x.Company.CompanyName + " " + x.Company.CompanyOfficial,
                                           Aciklama = x.TaskDesc,
                                           Tarih = x.TaskDate,
                                       }).ToList().OrderByDescending(x => x.Tarih);
        }
        private void TodayList()
        {
            gridControl2.DataSource = (from x in db.TaskDetails.Where(x =>
                    x.TaskDate.Value.Month == DateTime.Now.Month && x.TaskDate.Value.Day == DateTime.Now.Day &&
                    x.TaskDate.Value.Year == DateTime.Now.Year)
                                       select new
                                       {
                                           Aciklama = x.Taskes.TaskDesc,
                                           Detay = x.TaskDetailDesc,
                                           Tarih = x.Taskes.TaskDate
                                       }).ToList().OrderByDescending(x => x.Tarih);
        }
        private void CallList()
        {
            gridControl3.DataSource = (from x in db.CompanyCall.Where(x => x.Status)
                                       select new
                                       {
                                           SirketAdi = x.Company.CompanyName,
                                           Konu = x.Subject,
                                           Aciklama = x.Description,
                                           Tarih = x.C_Date
                                       }).ToList().OrderByDescending(x => x.Tarih);
        }
        private void Fihrist()
        {
            gridControl4.DataSource = (from x in db.Company
                                       select new
                                       {
                                           Sirket = x.CompanyName,
                                           Telefonu = x.CompanyTel,
                                           Adresi = x.CompanyAdress,
                                           x.Iller.Il,
                                           x.Ilceler.Ilce
                                       }).ToList().OrderBy(x => x.Sirket);
        }
        private void ChartList()
        {
            chartControl1.Series[0].Points.AddPoint("AKTIF CAGRI", db.CompanyCall.Count(x => x.Status));
            chartControl1.Series[0].Points.AddPoint("PASIF CAGRI", db.CompanyCall.Count(x => x.Status == false));
        }
        private void PageHome_Load(object sender, EventArgs e)
        {
            ContinuingJob();
            TodayList();
            CallList();
            Fihrist();
            ChartList();
        }
        private void PageHome_KeyDown(object sender, KeyEventArgs e)
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
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Gorevler.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
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
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView2.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\GorevlerBugun.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView2.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\GorevlerBugun.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView3.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\CagriFirma.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView3.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\CagriFirma.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView4.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Fihrist.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView4.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Fihrist.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\CagriChart.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\CagriChart.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}