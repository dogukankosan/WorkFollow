using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class DepartmenList : DevExpress.XtraEditors.XtraForm
    {
        public DepartmenList()
        {
            InitializeComponent();
        }
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private void Txt_Departmen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void DepartmanList()
        {
            gridControl1.DataSource = (from x in db.Department
                                       select new
                                       {
                                           x.ID,
                                           DepartmanAdi = x.DepartmentName
                                       }).ToList().OrderBy(x => x.DepartmanAdi);
            gridView1.Columns[0].Visible = false;
        }
        private void DepartmanAdd()
        {
            if (!(string.IsNullOrEmpty(Txt_Departmen.Text)))
            {
                DialogResult cv = XtraMessageBox.Show("DEPARTMAN EKLEMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ ? ", "DEPARTMAN EKLEME",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Department dp = new();
                    dp.DepartmentName = Txt_Departmen.Text;
                    db.Department.Add(dp);
                    db.SaveChanges();
                    DepartmanList();
                    XtraMessageBox.Show("DEPARTMAN EKLEME İŞLEMİ BAŞARILI..", "DEPARTMAN EKLEME",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Departmen.Text = null;
                }
            }
            else
            {
                XtraMessageBox.Show("DEPARTMAN ADI BOŞ GEÇİLEMEZ !!", "HATALI DEĞER", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Txt_Departmen.Focus();
            }
        }
        private void DepartmanRemove()
        {

            DialogResult cv = XtraMessageBox.Show("DİKKAT TABLODA SEÇİLİ OLAN DEPARTMAN SİLİNECEKTİR VE DEPARTMANIN BAĞLI OLDUĞU PERSONELLERDE SİLİNECEKTİR İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                "DEPARTMAN SİLME",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cv == DialogResult.Yes)
            {
                new Department();
                Department removDepartment = db.Department.Find(gridView1.GetFocusedRowCellValue("ID"));
                db.Department.Remove(removDepartment);
                db.SaveChanges();
                DepartmanList();
                Txt_Departmen.Text = null;
                XtraMessageBox.Show("DEPARTMAN SİLME İŞLEMİ BAŞARILI..", "DEPARTMAN SİLME",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DepartmanUpdate()
        {
            if (!(string.IsNullOrEmpty(Txt_Departmen.Text)))
            {
                DialogResult cv = XtraMessageBox.Show("DİKKAT TABLODAKİ SEÇİLİ DEPARTMAN GÜNCELLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ??", "GÜNCELLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Department deger = db.Department.Find(gridView1.GetFocusedRowCellValue("ID"));
                    deger.DepartmentName = Txt_Departmen.Text;
                    db.SaveChanges();
                    DepartmanList();
                    Txt_Departmen.Text = null;
                    XtraMessageBox.Show("DEPARTMAN GÜNCELLEME İŞLEMİ BAŞARILI !!", "GÜNCELLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("DEPARTMAN ADI BOŞ GEÇİLEMEZ !!", "HATALI DEĞER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DepartmenList_Load(object sender, System.EventArgs e)
        {
            DepartmanList();
        }
        private void Btn_DepaAdd_Click(object sender, System.EventArgs e)
        {
            DepartmanAdd();
        }
        private void DepartmenList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                DepartmanAdd();
            if (e.KeyCode == Keys.F3)
                DepartmanRemove();
            if (e.KeyCode == Keys.F5)
                DepartmanUpdate();
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void excelAlToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Departman.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Departman.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_DepaDelete_Click(object sender, EventArgs e)
        {
            DepartmanRemove();
        }
        private void Btn_DepaUpdate_Click(object sender, EventArgs e)
        {
            DepartmanUpdate();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Txt_Departmen.Text = gridView1.GetFocusedRowCellValue("DepartmanAdi").ToString();
        }
    }
}