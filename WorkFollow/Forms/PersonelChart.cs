using DevExpress.Data.Linq.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;
namespace WorkFollow.Forms
{
    public partial class PersonelChart : DevExpress.XtraEditors.XtraForm
    {
        public PersonelChart()
        {
            InitializeComponent();
        }
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private void PersonelChart_Load(object sender, EventArgs e)
        {
            Lbl_DepartCount.Text = db.Department.Count().ToString();
            Lbl_PersonelCount.Text = db.Personeles.Count().ToString();
            Lbl_CompanyCount.Text = db.Company.Count().ToString();
            Lbl_ActiveJobCount.Text = db.Taskes.Count(x => x.Status).ToString();
            Lbl_PassiveJobCount.Text = db.Taskes.Count(x => x.Status == false).ToString();
            Lbl_LastJob.Text = db.Taskes.OrderByDescending(x => x.ID).FirstOrDefault()?.TaskDesc.ToString();
            Lbl_TodayJobCount.Text = db.Taskes.Count(x => x.TaskDate.Day == DateTime.Now.Day && x.TaskDate.Month == DateTime.Now.Month && x.TaskDate.Year == DateTime.Now.Year).ToString();
            Lbl_CompanyCount.Text = db.Company.Count().ToString();
            Lbl_MaxPersonDepart.Text = db.Personeles.GroupBy(x => x.Department.DepartmentName).Select(x => new
            {
                DepartmentName = x.Key,
                DepartmentCount = x.Count()
            }).OrderByDescending(x => x.DepartmentCount).FirstOrDefault()
                ?.DepartmentName.ToString();
            Lbl_CityCount.Text = db.Company.Select(x => x.CompanyCity).Distinct().Count().ToString();
            Lbl_SectorCount.Text = db.Company.Select(x => x.CompanyActivity).Distinct().Count().ToString();
            Lbl_MonthPerson.Text = db.Taskes.Where(x => x.TaskDate.Month == DateTime.Now.Month && x.TaskDate.Year == DateTime.Now.Year).GroupBy(x => x.Personeles.PersonelName).Select(x => new
            {
                PersonelName = x.Key,
                PersonelCount = x.Count()
            }).OrderByDescending(x => x.PersonelCount).FirstOrDefault()
                ?.PersonelName.ToString();
            Lbl_MonthDepart.Text = db.Taskes.Where(x => x.TaskDate.Month == DateTime.Now.Month && x.TaskDate.Year == DateTime.Now.Year).GroupBy(x => x.Personeles.Department.DepartmentName).Select(x => new
            {
                PersonelAdi = x.Key,
                CountPerson = x.Count()
            }).OrderByDescending(x => x.CountPerson).FirstOrDefault()
                ?.PersonelAdi.ToString();
        }

        private void PersonelChart_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}