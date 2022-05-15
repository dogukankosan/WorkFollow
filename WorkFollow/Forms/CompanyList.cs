using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class CompanyList : DevExpress.XtraEditors.XtraForm
    {
        private readonly DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        public CompanyList()
        {
            InitializeComponent();
        }
        private void Delete()
        {
            if (gridView1.GetFocusedRowCellValue("ID") is not null)
            {
                DialogResult cv = XtraMessageBox.Show("DİKKAT TABLODAKİ SEÇİLİ FİRMA SİLME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?", "FİRMA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Company id = db.Company.Find(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
                    db.Company.Remove(id);
                    db.SaveChanges();
                    XtraMessageBox.Show("FİRMA SİLME İŞLEMİ BAŞARILI !!", "SİLME İŞLEMİ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Clear();
                    CompanyListGrid();
                }
            }
            else
            {
                XtraMessageBox.Show("SİLMEK İSTEDİĞİNİZ FİRMAYI LÜTFEN TABLODAN SEÇİNİZ !!", "SİLME İŞLEMİ HATALI", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void Add()
        {
            byte countdb = Convert.ToByte(db.Company.Count(x => x.CompanyMail == Txt_CompanyMail.Text));

            if (!(string.IsNullOrEmpty(Txt_CompanyName.Text)) && !(string.IsNullOrEmpty(Txt_CompanyTel.Text)) && Txt_CompanyTel.Text != "   -" && !(string.IsNullOrEmpty(Txt_CompanyMail.Text)) && !(string.IsNullOrEmpty(Txt_Password.Text)) && lookUpEdit2.EditValue is not null && lookUpEdit3.EditValue is not null)
            {
                if (countdb == 0)
                {
                    DialogResult cv = XtraMessageBox.Show("FİRMA EKLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?", "FİRMA EKLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cv == DialogResult.Yes)
                    {
                        Company c = new();
                        c.CompanyName = Txt_CompanyName.Text;
                        c.CompanyTel = Txt_CompanyTel.Text;
                        c.CompanyOfficial = Txt_CompanyOffical.Text;
                        c.CompanyMail = Txt_CompanyMail.Text;
                        c.Password = MVCFirmaCagri.Encription.Enc.Log(Txt_Password.Text);
                        c.CompanyActivity = Txt_CompanyActivity.Text;
                        c.CompanyCity = Convert.ToByte(lookUpEdit2.EditValue);
                        c.CompanyTown = Convert.ToInt16(lookUpEdit3.EditValue);
                        c.CompanyAdress = Txt_CompanyAdress.Text;
                        c.IsAdmin = Chk_IsAdmin.Checked;
                        c.CompanyImage = pictureEdit1.Image is not null ? ImageBinary.BinaryImage.ImageToByteArray((pictureEdit1.Image)) : null;
                        db.Company.Add(c);
                        db.SaveChanges();
                        XtraMessageBox.Show("FİRMA EKLEME İŞLEMİ BAŞARILI !!", "EKLEME İŞLEMİ BAŞARILI",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CompanyListGrid();
                        Clear();
                    }
                }
                else
                {
                    XtraMessageBox.Show("GİRMEK İSTEDİĞİZ MAİL DAHA ÖNCEDEN TANIMLANMIŞ!!", "HATALI EKLEME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_CompanyMail.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN KIRMIZI ALANLARI BOŞ GEÇMEYİNİZ !!", "HATALI EKLEME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update(short id)
        {
            byte countdb = Convert.ToByte(db.Company.Count(x => x.ID != id && x.CompanyMail == Txt_CompanyMail.Text));

            if (!(string.IsNullOrEmpty(Txt_CompanyName.Text)) && !(string.IsNullOrEmpty(Txt_CompanyTel.Text)) &&
                Txt_CompanyTel.Text != "   -" && !(string.IsNullOrEmpty(Txt_CompanyMail.Text)) &&
                !(string.IsNullOrEmpty(Txt_Password.Text)) && lookUpEdit2.EditValue is not null &&
                lookUpEdit3.EditValue is not null)
            {
                if (countdb == 0)
                {
                    DialogResult cv = XtraMessageBox.Show(
                        "DİKKAT TABLODA SEÇİLEN FİRMA GÜNCELLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ?",
                        "FİRMA GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cv == DialogResult.Yes)
                    {
                        Company c = db.Company.Find(id);
                        c.CompanyName = Txt_CompanyName.Text;
                        c.CompanyTel = Txt_CompanyTel.Text;
                        c.CompanyOfficial = Txt_CompanyOffical.Text;
                        c.CompanyMail = Txt_CompanyMail.Text;
                        c.Password = MVCFirmaCagri.Encription.Enc.Log(Txt_Password.Text);
                        c.CompanyActivity = Txt_CompanyActivity.Text;
                        c.CompanyCity = Convert.ToByte(lookUpEdit2.EditValue);
                        c.CompanyTown = Convert.ToInt16(lookUpEdit3.EditValue);
                        c.CompanyAdress = Txt_CompanyAdress.Text;
                        c.IsAdmin = Chk_IsAdmin.Checked;
                        c.CompanyImage = pictureEdit1.Image is not null
                            ? ImageBinary.BinaryImage.ImageToByteArray((pictureEdit1.Image))
                            : null;
                        db.SaveChanges();
                        XtraMessageBox.Show("FİRMA GÜNCELLEME İŞLEMİ BAŞARILI !!", "GÜNCELLEME İŞLEMİ BAŞARILI",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CompanyListGrid();
                        Clear();
                    }
                }
                else
                {
                    XtraMessageBox.Show("GİRMEK İSTEDİĞİZ MAİL DAHA ÖNCEDEN TANIMLANMIŞ!!", "HATALI EKLEME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_CompanyMail.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN KIRMIZI ALANLARI BOŞ GEÇMEYİNİZ !!", "HATALI EKLEME İŞLEMİ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Btn_EyeVisible_Click(object sender, EventArgs e)
        {
            char? valuenull = null;
            Btn_EyeVisible.Visible = false;
            Btn_UnVisible.Visible = true;
            Txt_Password.Properties.PasswordChar = Convert.ToChar(valuenull);
        }
        private void Btn_UnVisible_Click(object sender, EventArgs e)
        {
            Btn_UnVisible.Visible = false;
            Btn_EyeVisible.Visible = true;
            Txt_Password.Properties.PasswordChar = '*';
        }
        private void CityList()
        {
            lookUpEdit2.Properties.ValueMember = "IlID";
            lookUpEdit2.Properties.DisplayMember = "Il";
            lookUpEdit2.Properties.DataSource = (from x in db.Iller
                                                 select new
                                                 {
                                                     x.Il,
                                                     x.IlID
                                                 }).OrderBy(x => x.Il).ToList();
            lookUpEdit3.EditValue = null;
            lookUpEdit3.Text = null;
        }
        private void Clear()
        {
            Txt_CompanyName.Text = null;
            Txt_CompanyActivity.Text = null;
            Txt_CompanyAdress.Text = null;
            Txt_CompanyTel.Text = null;
            Txt_CompanyMail.Text = null;
            Txt_CompanyOffical.Text = null;
            Txt_Password.Text = null;
            lookUpEdit2.EditValue = null;
            lookUpEdit3.EditValue = null;
            pictureEdit1.Image = null;
            Chk_IsAdmin.Checked = false;
        }
        private void CompanyList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F1)
                Clear();
            if (e.KeyCode == Keys.F2)
                Add();
            if (e.KeyCode == Keys.F3)
                Delete();
            if (e.KeyCode == Keys.F5)
                Update(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
        }
        private void CompanyList_Load(object sender, EventArgs e)
        {
            Btn_UnVisible.Visible = false;
            CompanyListGrid();
            CityList();
        }
        private void CompanyListGrid()
        {
            gridControl1.DataSource = (from x in db.Company
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
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            TownCascedingList(Convert.ToInt16(lookUpEdit2.EditValue));
        }
        private void TownCascedingList(short id)
        {
            lookUpEdit3.EditValue = null;
            lookUpEdit3.Text = null;
            lookUpEdit3.Properties.ValueMember = "IlceID";
            lookUpEdit3.Properties.DisplayMember = "Ilce";
            lookUpEdit3.Properties.DataSource = (from x in db.Ilceler.Where(x => x.IlID == id)
                                                 select new
                                                 {
                                                     x.Ilce,
                                                     x.IlceID
                                                 }).OrderBy(x => x.Ilce).ToList();
        }
        private void Txt_CompanyActivity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Txt_CompanyOffical_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Btn_CompanyAdd_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void Btn_CompanyUpdate_Click(object sender, EventArgs e)
        {
            Update(Convert.ToInt16(gridView1.GetFocusedRowCellValue("ID")));
        }
        private void Btn_CompanyRemove_Click(object sender, EventArgs e)
        {
            Delete();
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Company.pdf");
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
            try
            {
                Txt_CompanyName.Text = gridView1.GetFocusedRowCellValue("Sirket") as string;
                Txt_CompanyOffical.Text = gridView1.GetFocusedRowCellValue("Yetkili") as string;
                Txt_CompanyTel.Text = gridView1.GetFocusedRowCellValue("Tel") as string;
                Txt_CompanyMail.Text = gridView1.GetFocusedRowCellValue("Mail") as string;
                Txt_CompanyActivity.Text = gridView1.GetFocusedRowCellValue("Faaliyet") as string;
                Txt_Password.Text = MVCFirmaCagri.Encription.Enc.Description(gridView1.GetFocusedRowCellValue("Password") as string);
                lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("Il") as string;
                lookUpEdit3.Text = gridView1.GetFocusedRowCellValue("Ilce") as string;
                Txt_CompanyAdress.Text = gridView1.GetFocusedRowCellValue("Adres") as string;
                pictureEdit1.Image = gridView1.GetFocusedRowCellValue("Resim") is not null ? ImageBinary.BinaryImage.ByteArrayToImage((byte[])gridView1.GetFocusedRowCellValue("Resim")) : null;
                Chk_IsAdmin.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("IsAdmin"));
            }
            catch (Exception)
            {

            }
        }
    }
}