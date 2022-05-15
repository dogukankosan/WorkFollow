using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class AddCompany : DevExpress.XtraEditors.XtraForm
    {
        public AddCompany()
        {
            InitializeComponent();
        }
        private readonly DbWorkFollowEntities db = new();
        private void Btn_CompanyAdd_Click(object sender, EventArgs e)
        {
            Add();
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
                        c.CompanyImage = pictureEdit1.Image is not null ? ImageBinary.BinaryImage.ImageToByteArray((pictureEdit1.Image)) : null;
                        c.IsAdmin = Chk_IsAdmin.Checked;
                        db.Company.Add(c);
                        db.SaveChanges();
                        XtraMessageBox.Show("FİRMA EKLEME İŞLEMİ BAŞARILI !!", "EKLEME İŞLEMİ BAŞARILI",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        this.Close();
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
        private void AddCompany_Load(object sender, EventArgs e)
        {
            CityList();
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void lookUpEdit2_EditValueChanged_1(object sender, EventArgs e)
        {
            TownCascedingList(Convert.ToInt16(lookUpEdit2.EditValue));
        }
        private void Txt_CompanyOffical_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
        private void Txt_CompanyActivity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
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
        private void AddCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                Add();
            if (e.KeyCode == Keys.F1)
                Clear();
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}