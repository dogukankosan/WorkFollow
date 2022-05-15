using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class AddDepartman : DevExpress.XtraEditors.XtraForm
    {
        public AddDepartman()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
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
                    XtraMessageBox.Show("DEPARTMAN EKLEME İŞLEMİ BAŞARILI..", "DEPARTMAN EKLEME",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Departmen.Text = null;
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("DEPARTMAN ADI BOŞ GEÇİLEMEZ !!", "HATALI DEĞER", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Txt_Departmen.Focus();
            }
        }
        private void Btn_DepaAdd_Click(object sender, EventArgs e)
        {
            DepartmanAdd();
        }
        private void AddDepartman_Load(object sender, EventArgs e)
        {

        }
        private void AddDepartman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                DepartmanAdd();
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Txt_Departmen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                                                  && !char.IsSeparator(e.KeyChar);
        }
    }
}