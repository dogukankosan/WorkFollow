using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WorkFollow.Entitiy;

namespace WorkFollow.Forms
{
    public partial class AddTask : DevExpress.XtraEditors.XtraForm
    {
        public AddTask()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        public short JobSender=default;
        private void PersonelLook()
        {
            lookUpEdit1.Properties.DisplayMember = "Personel";
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DataSource = (from x in db.Personeles
                                                 select new
                                                 {
                                                     x.ID,
                                                     Personel = x.PersonelName + " " + x.PersonelSurname,
                                                     Departman = x.Department.DepartmentName
                                                 }).OrderByDescending(x => x.Personel).ToList();
        }
        private void TaskAdd()
        {
            if (!(string.IsNullOrEmpty(Txt_Desc.Text)) && lookUpEdit1.EditValue is not null)
            {
                DialogResult vc = XtraMessageBox.Show("GÖREV KAYDETMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ ??", "GÖREV EKLEME",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vc == DialogResult.Yes)
                {
                    Taskes ts = new();
                    ts.TaskSender = Convert.ToInt16(Entitiy.Trash.ID2);
                    ts.TaskReceiver = Convert.ToInt16(lookUpEdit1.EditValue);
                    ts.TaskDate = Convert.ToDateTime(dateEdit1.DateTime);
                    ts.Status = Chk_Status.Checked;
                    ts.TaskDesc = Txt_Desc.Text;
                    db.Taskes.Add(ts);
                    db.SaveChanges();
                    XtraMessageBox.Show("GÖREV KAYDETME İŞLEMİ BAŞARILI !!", "GÖREV EKLEME", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("KIRMIZI ALANLARI LÜTFEN BOŞ GEÇMEYİNİZ !!", "GÖREV HATALI EKLEME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void AddTask_Load(object sender, System.EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
            PersonelLook();
        }
        private void Btn_Save_Click(object sender, System.EventArgs e)
        {
            TaskAdd();
        }
    }
}