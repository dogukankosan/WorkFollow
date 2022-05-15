using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraBars;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkFollow.Entitiy;
using WorkFollow.Forms;

namespace WorkFollow
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private readonly Entitiy.DbWorkFollowEntities db = new();
        private Forms.NewsForm nwForm;
        private Forms.CurrencyForm currencyForm;
        private Forms.MapForm mapForm;
        private Forms.DepartmenList _departmenList;
        private Forms.PersonelList PersonelList;
        private Forms.PersonelChart PersonelChart;
        private Forms.TaskList TaskList;
        private Forms.AddTask AddTask;
        private Forms.TaskDetails TaskDetails;
        private Forms.PageHome PageHome;
        private Forms.CompanyList CompanyList;
        private Forms.AddCompany AddCompany;
        private Forms.AddPersonel AddPersonel;
        private Forms.AddDepartman AddDepartman;
        private Forms.ActiveCall ActiveCall;
        private Forms.InComingMessage Message;
        private Forms.Youtube yt;
        private Forms.IsRead isRead;
        private Forms.DeleteMessage DeleteMessage;
        private Forms.SenderMessage SenderMessage;
        private Forms.DeleteSender DeleteSender;
        private Forms.AddNewMessage AddNewMessage;
        private Forms.DepartmanChart Chart;
        private Forms.CompanyChart ComChart;
        private Forms.ActiveTask ActiveTask;
        private Forms.PassiveTask PassiveTask;
        private Forms.TaskChart TaskChart;
        private Forms.PassiveCall tsk;
        private Forms.CompanyIsNotAdmin NotAdmin;
        public static bool isadmincontrol;

        void Countlist()
        {
            ribbonPageGroup17.Text = db.Message.Count(x => x.Receiver == Entitiy.Trash.ID2).ToString();
            ribbonPageGroup18.Text = db.Message.Count(x => x.Receiver == Entitiy.Trash.ID2 && x.IsRead == false && x.Status == true).ToString();
            ribbonPageGroup19.Text = db.Message.Count(x => x.Receiver == Entitiy.Trash.ID2 && x.Status == false).ToString();
            ribbonPageGroup20.Text = db.Message.Count(x => x.Sender == Entitiy.Trash.ID2 && x.Status == true).ToString();
            ribbonPageGroup21.Text = db.Message.Count(x => x.Sender == Entitiy.Trash.ID2 && x.Status == false).ToString();
            ribbonPageGroup22.Text = db.Taskes.Count(x => x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2).ToString();
            ribbonPageGroup23.Text = db.Taskes.Count(x => x.Status == true && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2)).ToString();
            ribbonPageGroup24.Text = db.Taskes.Count(x => x.Status == false && (x.TaskReceiver == Entitiy.Trash.ID2 || x.TaskSender == Entitiy.Trash.ID2)).ToString();
            ribbonPageGroup14.Text = db.CompanyCall.Count(x => x.Status).ToString();
            ribbonPageGroup15.Text = db.CompanyCall.Count(x => x.Status == false).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Countlist();
            if (!(isadmincontrol))
            {
                ribbonPage1.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
                ribbonPageGroup25.Visible = false;
                Btn_SQL.Visibility = BarItemVisibility.Never;
                ribbonPage7.Visible = false;
                ribbonPageGroup12.Visible = false;
                Btn_Messa.Visible = false;
                Btn_Web.Visibility = BarItemVisibility.Never;
                Btn_Map.Visibility = BarItemVisibility.Never;
                ribbonPage9.Visible = true;
            }
        }
        private void Btn_Calculator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }
        private void Btn_Youtube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (yt is null || yt.IsDisposed)
            {
                yt = new() { MdiParent = this };
                yt.Show();
            }
        }
        private void Btn_News_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nwForm is null || nwForm.IsDisposed)
            {
                nwForm = new NewsForm { MdiParent = this };
                nwForm.Show();
            }
        }
        private void Btn_Currency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (currencyForm is null || currencyForm.IsDisposed)
            {
                currencyForm = new CurrencyForm { MdiParent = this };
                currencyForm.Show();
            }
        }
        private void Btn_Map_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mapForm is null || mapForm.IsDisposed)
            {
                mapForm = new MapForm { MdiParent = this };
                mapForm.Show();
            }
        }
        private void Btn_DepartmenList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_departmenList is null || _departmenList.IsDisposed)
            {
                _departmenList = new DepartmenList { MdiParent = this };
                _departmenList.Show();
            }
        }
        private void Btn_PersonelList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PersonelList is null || PersonelList.IsDisposed)
            {
                PersonelList = new PersonelList { MdiParent = this };
                PersonelList.Show();
            }
        }
        private void Btn_PersonelChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PersonelChart is null || PersonelChart.IsDisposed)
            {
                PersonelChart = new PersonelChart { MdiParent = this };
                PersonelChart.Show();
            }
        }
        private void Btn_TaskList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TaskList is null || TaskList.IsDisposed)
            {
                TaskList = new TaskList { MdiParent = this };
                TaskList.Show();
            }
        }
        private void Btn_AddTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddTask = new();
            AddTask.ShowDialog();
        }
        private void Home_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Btn_TaskDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TaskDetails is null || TaskDetails.IsDisposed)
            {
                TaskDetails = new();
                TaskDetails.ShowDialog();
                TaskDetails = null;
            }
        }
        private void Btn_Home_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PageHome is null || PageHome.IsDisposed)
            {
                PageHome = new PageHome() { MdiParent = this };
                PageHome.Show();
            }
        }
        private void Btn_CompanyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CompanyList is null || CompanyList.IsDisposed)
            {
                CompanyList = new CompanyList() { MdiParent = this };
                CompanyList.Show();
            }
        }
        private void Btn_AddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddCompany = new();
            AddCompany.ShowDialog();
        }
        private void Btn_AddDepartmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddDepartman = new();
            AddDepartman.ShowDialog();
        }
        private void Btn_AddPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddPersonel = new();
            AddPersonel.ShowDialog();
        }
        private void Btn_ActiveCall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ActiveCall is null || ActiveCall.IsDisposed)
            {
                ActiveCall = new ActiveCall { MdiParent = this };
                ActiveCall.Show();
            }
        }
        private void Btn_SQL_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.SQLCommand sql = new();
            sql.ShowDialog();
        }
        private void Btn_Message_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (Message is null || Message.IsDisposed)
            {
                Message = new() { MdiParent = this };
                Message.Show();
            }
        }
        private void Btn_Web_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://192.168.1.102/Login/Log?ReturnUrl=%2fHome%2fList");
        }
        private void Btn_IsRead_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (isRead is null || isRead.IsDisposed)
            {
                isRead = new() { MdiParent = this };
                isRead.Show();
            }
        }
        private void Btn_MessageSender_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SenderMessage is null || SenderMessage.IsDisposed)
            {
                SenderMessage = new() { MdiParent = this };
                SenderMessage.Show();
            }
        }
        private void Btn_MessageSend_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (AddNewMessage is null || AddNewMessage.IsDisposed)
            {
                AddNewMessage = new() { MdiParent = this };
                AddNewMessage.Show();
            }
        }
        private void Btn_DeleteMessage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DeleteMessage is null || DeleteMessage.IsDisposed)
            {
                DeleteMessage = new() { MdiParent = this };
                DeleteMessage.Show();
            }
        }
        private void Btn_DeleteSender_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DeleteSender is null || DeleteSender.IsDisposed)
            {
                DeleteSender = new() { MdiParent = this };
                DeleteSender.Show();

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Countlist();
        }
        private void Btn_DepartmanChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Chart is null || Chart.IsDisposed)
            {
                Chart = new() { MdiParent = this };
                Chart.Show();
            }
        }
        private void Btn_CompanyChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ComChart is null || ComChart.IsDisposed)
            {
                ComChart = new() { MdiParent = this };
                ComChart.Show();
            }
        }

        private void Btn_ActiveTask_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ActiveTask is null || ActiveTask.IsDisposed)
            {
                ActiveTask = new() { MdiParent = this };
                ActiveTask.Show();
            }
        }
        private void Btn_CompleteTask_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (PassiveTask is null || PassiveTask.IsDisposed)
            {
                PassiveTask = new() { MdiParent = this };
                PassiveTask.Show();
            }
        }

        private void Btn_TaskChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TaskChart is null || TaskChart.IsDisposed)
            {
                TaskChart = new() { MdiParent = this };
                TaskChart.Show();
            }
        }

        private void Btn_PassiveCall_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tsk is null || tsk.IsDisposed)
            {
                tsk = new() { MdiParent = this };
                tsk.Show();
            }
        }

        private void Btn_CompanyPersonels_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NotAdmin is null || NotAdmin.IsDisposed)
            {
                NotAdmin = new() { MdiParent = this };
                NotAdmin.Show();
            }
        }
    }
}