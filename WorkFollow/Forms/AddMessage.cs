using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Message = WorkFollow.Entitiy.Message;

namespace WorkFollow.Forms
{
    public partial class AddMessage : DevExpress.XtraEditors.XtraForm
    {
        public AddMessage()
        {
            InitializeComponent();
        }

        public short id = default;
        private readonly Entitiy.DbWorkFollowEntities db = new();
        void Add()
        {
            if (!(string.IsNullOrEmpty(mstHtmlEditor1.BodyHTML)))
            {
                DialogResult cv = XtraMessageBox.Show("MESAJ GÖNDERMEK İSTEDİĞİNİZDEN EMİN MİSİNİZ ??",
                    "MESAJ GÖNDERME", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (cv == DialogResult.Yes)
                {
                    var replace = mstHtmlEditor1.BodyHTML;
                    if (mstHtmlEditor1.BodyHTML.Contains("ımg"))
                    {
                        replace = mstHtmlEditor1.BodyHTML.Replace("ımg", "img");
                    }

                    Message mns = new Message()
                    {
                        C_Date = DateTime.Now,
                        IsRead = false,
                        Status = true,
                        Sender = Entitiy.Trash.ID2,
                        Receiver = id,
                        MessageContent = replace
                    };
                    db.Message.Add(mns);
                    db.SaveChanges();
                    XtraMessageBox.Show("MESAJ GÖNDERME İŞLEMİ BAŞARILI !!", "MESAJ GÖNDERME", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    mstHtmlEditor1.Text = null;
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("MESAJ METİN KUTUSUNU BOŞ GEÇMEYİNİZ !!",
                     "MESAJ GÖNDERME HATALI", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
        }
        private void AddMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Btn_MessageAdd_Click(object sender, EventArgs e)
        {
            Add();
        }
    }
}