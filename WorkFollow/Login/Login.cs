using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;
using WorkFollow.Forms;

namespace WorkFollow.Login
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly Home hm = new();
        private AddTask tsk = new();
        private void Login_Load(object sender, EventArgs e)
        {
            Btn_UnVisible.Visible = false;
        }
        void LoginUser()
        {
            if ((string.IsNullOrEmpty(Txt_Username.Text)) || (string.IsNullOrEmpty(Txt_Password.Text)))
            {
                XtraMessageBox.Show("LÜTFEN GİRİŞ BİLGİLERİNİZİ BOŞ GEÇMEYİNİZ !!", "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_Username.Text = null;
                Txt_Password.Text = null;
            }
            else
            {
                Txt_Password.Text = MVCFirmaCagri.Encription.Enc.Log(Txt_Password.Text);
                Company valuesCompany = db.Company.FirstOrDefault(x => x.CompanyMail == Txt_Username.Text && x.Password == Txt_Password.Text);
                Personeles personeles = db.Personeles.FirstOrDefault(x => x.PersonelMail == Txt_Username.Text && x.PersonelPassword == Txt_Password.Text);
                if (valuesCompany is null && personeles is null)
                {
                    XtraMessageBox.Show("HATALI GİRİŞ YAPILDI LÜTFEN GİRİŞ BİLGİLERİNİZİ KONTROL EDİNİZ !!",
                        "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_Username.Text = null;
                    Txt_Password.Text = null;
                    return;
                }
                else if (valuesCompany is not null && valuesCompany.IsAdmin == true)
                {
                    //ADMİN GİRİŞ YAPTI
                    Home.isadmincontrol = true;
                    Entitiy.Trash.ID2 = valuesCompany.ID;
                    this.Hide();
                    hm.ShowDialog();
                    return;
                }
                else if (valuesCompany is not null && valuesCompany.IsAdmin == false)
                {
                    XtraMessageBox.Show("HATALI GİRİŞ YAPILDI LÜTFEN GİRİŞ BİLGİLERİNİZİ KONTROL EDİNİZ !!",
                        "HATALI GİRİŞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_Username.Text = null;
                    Txt_Password.Text = null;
                    return;
                }
                Entitiy.Trash.ID2 = personeles.ID;
                this.Hide();
                hm.ShowDialog();
            }
        }
        private void Btn_UnVisible_Click(object sender, EventArgs e)
        {
            Btn_UnVisible.Visible = false;
            Btn_EyeVisible.Visible = true;
            Txt_Password.Properties.PasswordChar = '*';
        }
        private void Btn_EyeVisible_Click(object sender, EventArgs e)
        {
            char? valuenull = null;
            Btn_EyeVisible.Visible = false;
            Btn_UnVisible.Visible = true;
            Txt_Password.Properties.PasswordChar = Convert.ToChar(valuenull);
        }
        private void Btn_Admin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }
    }
}