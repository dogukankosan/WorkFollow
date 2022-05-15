using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class ActiveCall : DevExpress.XtraEditors.XtraForm
    {
        public ActiveCall()
        {
            InitializeComponent();
        }

        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        private readonly Entitiy.DbWorkFollowEntities db = new();
        void List()
        {
            gridControl1.DataSource = (from x in db.CompanyCall.Where(x => x.Status)
                                       select new
                                       {
                                           x.ID,
                                           Sirket = x.Company.CompanyName,
                                           Konu = x.Subject,
                                           Aciklama = x.Description,
                                           Tarih = x.C_Date
                                       }).OrderByDescending(x => x.ID).ToList();
            if (gridView1.RowCount > 0)
            {
                gridView1.Columns[4].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                gridView1.Columns[0].Visible = false;
            }
        }
        private void ActiveCall_Load(object sender, EventArgs e)
        {
            if (!(Home.isadmincontrol))
                çağrıTamamlandıToolStripMenuItem.Visible = false;
            short ActiveCallCount = Int16.Parse(db.CompanyCall.Count(x => x.Status).ToString());
            XtraMessageBox.Show(ActiveCallCount > 0 ? string.Concat(ActiveCallCount.ToString(), " ADET AKTİF ÇAĞRINIZ BULUNMAKTADIR !!") : "AKTİF ÇAĞRINIZ BULUNMAMAKTADIR !!", "MESAJ BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
        }

        private void ActiveCall_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\AktifÇağrılar.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\AktifÇağrılar.pdf");
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
            CompanyCallDetails tsk = new();
            tsk.callid = Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID"));
            tsk.ShowDialog();
        }

        private void çağrıTamamlandıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyCall values = db.CompanyCall.Find(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
            if (values is null)
            {
                XtraMessageBox.Show("LÜTFEN DEĞERİ LİSTEDEN SEÇİNİZ !!", "SEÇİM YAPINIZ", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            values.Status = false;
            db.SaveChanges();
            List();
        }
    }
}