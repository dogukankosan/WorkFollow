using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class AddPersonel : DevExpress.XtraEditors.XtraForm
    {
        public AddPersonel()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private void PersonClear()
        {
            Txt_PersonelName.Text = null;
            Txt_PersonelSurname.Text = null;
            Txt_PersonelMail.Text = null;
            Txt_PersonTel.Text = null;
            pictureEdit1.Image = null;
            lookUpEdit1.EditValue = null;
        }
        private void PersonAdd()
        {
            if (!(string.IsNullOrEmpty(Txt_PersonelName.Text)) && !(string.IsNullOrEmpty(Txt_PersonelSurname.Text)) &&!(string.IsNullOrEmpty(Txt_Password.Text)) && !(string.IsNullOrEmpty(Txt_PersonelMail.Text)) && lookUpEdit1.EditValue is not null)
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
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("PERSONEL EKLEME İŞLEMİ HATALI LÜTFEN KIRMIZI İLE YAZILI ALANLARI BOŞ GEÇMEYİNİZ !!", "PERSONEL EKLEME", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
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
        private void AddPersonel_Load(object sender, EventArgs e)
        {
            PersonDepartmenList();
        }
        private void Txt_PersonelSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Txt_PersonelName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Btn_PersonelAdd_Click(object sender, EventArgs e)
        {
            PersonAdd();
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            PersonClear();
        }
        private void AddPersonel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F2)
                PersonAdd();
            if (e.KeyCode == Keys.F1)
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
    }
}