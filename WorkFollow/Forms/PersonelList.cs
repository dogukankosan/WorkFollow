using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class PersonelList : DevExpress.XtraEditors.XtraForm
    {
        public PersonelList()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        private void PersonDepartmenList()
        {
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "DepartmanAdi";
            lookUpEdit1.Properties.DataSource = (from x in db.Department
                                                 select new
                                                 {
                                                     x.ID,
                                                     DepartmanAdi = x.DepartmentName
                                                 }).ToList().OrderByDescending(x => x.DepartmanAdi);
        }
        private void PersonUpdate()
        {
            if (!(string.IsNullOrEmpty(Txt_PersonelName.Text)) && !(string.IsNullOrEmpty(Txt_PersonelSurname.Text)) &&
                !(string.IsNullOrEmpty(Txt_PersonelMail.Text)) && !(string.IsNullOrEmpty(Txt_Password.Text)) && lookUpEdit1.EditValue is not null)
            {
                DialogResult cv =
                    XtraMessageBox.Show("DİKKAT TABLODAKİ SEÇİLİ PERSONEL GÜNCELLENECEKTİR EMİN MİSİNİZ ??",
                        "GÜNCELLEME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Personeles prs = db.Personeles.Find(gridView1.GetFocusedRowCellValue("ID"));
                    prs.PersonelName = Txt_PersonelName.Text;
                    prs.PersonelSurname = Txt_PersonelSurname.Text;
                    prs.PersonelMail = Txt_PersonelMail.Text;
                    prs.PersonelTel = Txt_PersonTel.Text;
                    prs.PersonelPassword = MVCFirmaCagri.Encription.Enc.Log(Txt_Password.Text);
                    if (pictureEdit1.Image is not null)
                    {
                        byte[] b = ImageBinary.BinaryImage.ImageToByteArray((pictureEdit1.Image));
                        prs.PersonelPicture = b;
                    }
                    else
                        prs.PersonelPicture = null;

                    prs.DepartmentID = (byte)lookUpEdit1.EditValue;
                    db.SaveChanges();
                    XtraMessageBox.Show("PERSONEL GÜNCELLEME İŞLEMİ BAŞARILI !!", "GÜNCELLEME İŞLEMİ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PersonList();
                    PersonClear();
                }
            }
            else
            {
                XtraMessageBox.Show("PERSONEL GÜNCELLEME HATALI KIRMIZI İFADELERİ BOŞ GEÇMEYİNİZ !!",
                    "GÜNCELLEME HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PersonelRemove()
        {
            DialogResult cv = XtraMessageBox.Show("DİKKAT TABLODAKİ SEÇİLİ PERSONEL SİLİNECEKTİR EMİN MİSİNİZ ??", "SİLME İŞLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cv == DialogResult.Yes)
            {
                Personeles prs = db.Personeles.Find(gridView1.GetFocusedRowCellValue("ID"));
                db.Personeles.Remove(prs);
                db.SaveChanges();
                XtraMessageBox.Show("PERSONEL SİLME İŞLEMİ BAŞARILI !!", "SİLME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonList();
                PersonClear();
            }
        }
        private void PersonClear()
        {
            Txt_PersonelName.Text = null;
            Txt_PersonelSurname.Text = null;
            Txt_PersonelMail.Text = null;
            Txt_PersonTel.Text = null;
            pictureEdit1.Image = null;
            lookUpEdit1.EditValue = null;
            Txt_Password.Text = null;
        }
        private void PersonAdd()
        {
            if (!(string.IsNullOrEmpty(Txt_PersonelName.Text)) && !(string.IsNullOrEmpty(Txt_Password.Text)) && !(string.IsNullOrEmpty(Txt_PersonelSurname.Text)) && !(string.IsNullOrEmpty(Txt_PersonelMail.Text)) && lookUpEdit1.EditValue is not null)
            {
                DialogResult cv = XtraMessageBox.Show("PERSONEL EKLEME İŞLEMİ YAPMAK İSTEDİĞİNİZDEN EMİN MİSİNİZ ??", "PERSONEL EKLEME", MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    Personeles prs = new Personeles
                    {
                        PersonelName = Txt_PersonelName.Text,
                        PersonelSurname = Txt_PersonelSurname.Text,
                        PersonelMail = Txt_PersonelMail.Text,
                        PersonelTel = Txt_PersonTel.Text,
                        PersonelPassword = MVCFirmaCagri.Encription.Enc.Log(Txt_Password.Text)
                    };
                    prs.PersonelPicture = pictureEdit1.Image is not null ? ImageBinary.BinaryImage.ImageToByteArray((pictureEdit1.Image)) : null;
                    prs.DepartmentID = (byte)lookUpEdit1.EditValue;
                    db.Personeles.Add(prs);
                    db.SaveChanges();
                    XtraMessageBox.Show("PERSONEL EKLEME İŞLEMİ BAŞARILI !!", "PERSONEL EKLEME", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    PersonClear();
                    PersonList();
                }
            }
            else
            {
                XtraMessageBox.Show("PERSONEL EKLEME İŞLEMİ HATALI LÜTFEN KIRMIZI İLE YAZILI ALANLARI BOŞ GEÇMEYİNİZ !!", "PERSONEL EKLEME", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void PersonList()
        {
            gridControl1.DataSource = (from x in db.Personeles
                                       select new
                                       {
                                           x.ID,
                                           x.PersonelPassword,
                                           PersonelAdi = x.PersonelName,
                                           PersonelSoyadi = x.PersonelSurname,
                                           x.PersonelMail,
                                           PersonelTelefon = x.PersonelTel,
                                           PersonelResim = x.PersonelPicture,
                                           Departmani = x.Department.DepartmentName
                                       }).ToList().OrderByDescending(x => x.PersonelAdi);
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
        }
        private void Txt_PersonelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Txt_PersonelSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void PersonelList_Load(object sender, EventArgs e)
        {
            PersonList();
            PersonDepartmenList();
        }
        private void PersonelList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                PersonAdd();
            if (e.KeyCode == Keys.F3)
                PersonelRemove();
            if (e.KeyCode == Keys.F5)
                PersonUpdate();
            if (e.KeyCode == Keys.F1)
                PersonClear();
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Btn_PersonelAdd_Click(object sender, EventArgs e)
        {
            PersonAdd();
        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\Personeller.xlsx");
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
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\Personeller.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_PersonelRemove_Click(object sender, EventArgs e)
        {
            PersonelRemove();
        }
        private void Btn_PersonelUpdate_Click(object sender, EventArgs e)
        {
            PersonUpdate();
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            PersonClear();
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
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Txt_PersonelName.Text = gridView1.GetFocusedRowCellValue("PersonelAdi").ToString();
            Txt_PersonelSurname.Text = gridView1.GetFocusedRowCellValue("PersonelSoyadi").ToString();
            Txt_PersonelMail.Text = gridView1.GetFocusedRowCellValue("PersonelMail").ToString();
            Txt_PersonTel.Text = gridView1.GetFocusedRowCellValue("PersonelTelefon").ToString();
            Txt_Password.Text = MVCFirmaCagri.Encription.Enc.Description(gridView1.GetFocusedRowCellValue("PersonelPassword").ToString());
            pictureEdit1.Image = gridView1.GetFocusedRowCellValue("PersonelResim") is not null ? ImageBinary.BinaryImage.ByteArrayToImage((byte[])gridView1.GetFocusedRowCellValue("PersonelResim")) : null;
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departmani").ToString();
        }
    }
}