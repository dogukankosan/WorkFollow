using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class CompanyCallDetails : DevExpress.XtraEditors.XtraForm
    {
        public CompanyCallDetails()
        {
            InitializeComponent();
        }
        private void CompanyCallDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F2)
                Save();
            if (e.KeyCode == Keys.F5)
                Update();
            if (e.KeyCode == Keys.F1)
                Txt_DetailsText.Text = null;
        }
        public short callid;
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        void List(short id)
        {
            gridControl1.DataSource = (from x in db.CallDetails.Where(x => x.CompanyCall == id)
                                       select new
                                       {
                                           x.ID,
                                           Aciklama = x.DescText,
                                           Tarih = x.C_Date,
                                       }).OrderByDescending(x => x.ID).ToList();
            gridView1.Columns[0].Visible = false;
        }
        void Update()
        {
            if (!(string.IsNullOrEmpty(Txt_DetailsText.Text)))
            {
                DialogResult cv = XtraMessageBox.Show("GÜNCELLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                    "GÜNCELLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Entitiy.CallDetails cld = db.CallDetails.Find(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
                    cld.CompanyCall = callid;
                    cld.DescText = Txt_DetailsText.Text;
                    cld.C_Date = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Tarih"));
                    db.SaveChanges();
                    XtraMessageBox.Show("ÇAĞRI DETAY GÜNCELLEME İŞLEMİ BAŞARILI !!", "BAŞARILI GÜNCELLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_DetailsText.Text = null;
                    List(callid);
                }
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN METİN KUTUSUNU BOŞ GEÇMEYİNİZ !!", "HATALI GÜNCELLEME İŞLEMİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Save()
        {
            if (!(string.IsNullOrEmpty(Txt_DetailsText.Text)))
            {
                DialogResult cv = XtraMessageBox.Show("EKLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                    "EKLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Entitiy.CallDetails cld = new();
                    cld.CompanyCall = callid;
                    cld.DescText = Txt_DetailsText.Text;
                    cld.C_Date = DateTime.Now;
                    db.CallDetails.Add(cld);
                    db.SaveChanges();
                    XtraMessageBox.Show("ÇAĞRI DETAY EKLEME İŞLEMİ BAŞARILI !!", "BAŞARILI EKLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_DetailsText.Text = null;
                    List(callid);
                }
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN METİN KUTUSUNU BOŞ GEÇMEYİNİZ !!", "HATALI EKLEME İŞLEMİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CompanyCallDetails_Load(object sender, EventArgs e)
        {
           
            if (!(Home.isadmincontrol))
            {
                groupControl1.Visible = false;
                gridControl1.Dock = DockStyle.Fill;
            }
            List(callid);
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            Update();
        }
 
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Txt_DetailsText.Text = null;
        }
        private void pDFAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\ÇağrıDetay.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\ÇağrıDetay.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCELE ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Txt_DetailsText.Text = gridView1.GetFocusedRowCellValue("Aciklama") as string;
        }
    }
}