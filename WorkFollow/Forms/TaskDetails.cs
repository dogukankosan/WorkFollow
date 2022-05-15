using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class TaskDetails : DevExpress.XtraEditors.XtraForm
    {
        public TaskDetails()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        public Int16 id = default;
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        void Update()
        {
            if (!(string.IsNullOrEmpty(Txt_DetailsText.Text)) && id != 0)
            {
                DialogResult cv = XtraMessageBox.Show("GÜNCELLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                    "GÜNCELLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Entitiy.TaskDetails cld = db.TaskDetails.Find(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
                    cld.TaskID = id;
                    cld.TaskDetailDesc = Txt_DetailsText.Text;
                    cld.TaskDate = Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Tarih"));
                    db.SaveChanges();
                    XtraMessageBox.Show("GÖREV DETAY GÜNCELLEME İŞLEMİ BAŞARILI !!", "BAŞARILI GÜNCELLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_DetailsText.Text = null;
                    AllList(id);
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
            if (!(string.IsNullOrEmpty(Txt_DetailsText.Text)) && id != 0)
            {
                DialogResult cv = XtraMessageBox.Show("EKLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                    "EKLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Entitiy.TaskDetails cld = new();
                    cld.TaskID = id;
                    cld.TaskDetailDesc = Txt_DetailsText.Text;
                    cld.TaskDate = DateTime.Now;
                    db.TaskDetails.Add(cld);
                    db.SaveChanges();
                    XtraMessageBox.Show("GÖREV DETAY EKLEME İŞLEMİ BAŞARILI !!", "BAŞARILI EKLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_DetailsText.Text = null;
                    AllList(id);
                }
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN METİN KUTUSUNU BOŞ GEÇMEYİNİZ  !!", "HATALI EKLEME İŞLEMİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void AllList(Int16? Isid)
        {
            if (Isid != 0)
            {
                gridControl1.DataSource = (from x in db.TaskDetails.Where(x => x.TaskID == id)
                                           select new
                                           {
                                               x.ID,
                                               Aciklama = x.TaskDetailDesc,
                                               Tarih = x.TaskDate

                                           }).OrderByDescending(x => x.ID).ToList();
                gridView1.Columns[0].Visible = false;
            }
            else
            {
                gridControl1.DataSource = (from x in db.TaskDetails.Where(x => x.Taskes.Personeles.ID == Entitiy.Trash.ID2 || x.Taskes.Company.ID == Entitiy.Trash.ID2)
                                           select new
                                           {
                                               x.ID,
                                               Aciklama = x.TaskDetailDesc,
                                               Tarih = x.TaskDate

                                           }).OrderByDescending(x => x.ID).ToList();
                gridView1.Columns[0].Visible = false;
                groupControl1.Visible = false;
                gridControl1.Dock = DockStyle.Fill;
            }

            if (gridView1.RowCount>0)
            {
                gridView1.Columns[2].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            }
        }
        private void TaskDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
                Update();
            if (e.KeyCode == Keys.F2)
                Save();
            if (e.KeyCode == Keys.F1)
                Txt_DetailsText.Text = null;
        }
        private void TaskDetails_Load(object sender, EventArgs e)
        {
            AllList(id);
        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\GörevDetay.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\GörevDetay.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_Save_Click_1(object sender, EventArgs e)
        {
            Save();
        }
        private void Btn_Update_Click_1(object sender, EventArgs e)
        {
            Update();
        }
        private void Btn_Clear_Click_1(object sender, EventArgs e)
        {
            Txt_DetailsText.Text = null;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Txt_DetailsText.Text = gridView1.GetFocusedRowCellValue("Aciklama") as string;
        }
    }
}