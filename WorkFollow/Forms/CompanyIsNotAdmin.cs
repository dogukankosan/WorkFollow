using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class CompanyIsNotAdmin : DevExpress.XtraEditors.XtraForm
    {
        public CompanyIsNotAdmin()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new ();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new ();
        private void CompanyListGrid()
        {
            gridControl1.DataSource = (from x in db.Company.Where(x => x.IsAdmin == false)
                                       select new
                                       {
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

        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Company.xlsx");
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
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Company.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCELE ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CompanyIsNotAdmin_Load(object sender, EventArgs e)
        {
            CompanyListGrid();
        }

        private void CompanyIsNotAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}