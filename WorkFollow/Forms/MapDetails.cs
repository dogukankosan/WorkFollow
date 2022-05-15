using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class MapDetails : DevExpress.XtraEditors.XtraForm
    {
        public MapDetails()
        {
            InitializeComponent();
        }
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        private readonly Entitiy.DbWorkFollowEntities db = new DbWorkFollowEntities();
        public string id = string.Empty;
        private void MapDetails_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.Company.Where(x => x.Iller.Il == id)
                                       select new
                                       {
                                           x.ID,
                                           x.Password,
                                           x.IsAdmin,
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
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Visible = false;
        }

        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Map.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Map.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MapDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}