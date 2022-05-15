using DevExpress.XtraEditors;
using MVCFirmaCagri.Encription;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class SQLCommand : DevExpress.XtraEditors.XtraForm
    {
        public SQLCommand()
        {
            InitializeComponent();
        }
        private readonly SqlConnection myConnection = new(Enc.Description(File.ReadAllText("sql.txt")));
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly FolderBrowserDialog folderBrowserDialog1 = new ();
        void Command()
        {
            try
            {
                if (richTextBox1.Text.ToUpper().Contains("SELECT"))
                {
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    SqlDataAdapter da = new(richTextBox1.Text, myConnection);
                    DataSet ds = new();
                    da.Fill(ds);
                    gridControl1.DataSource = ds.Tables[0];
                }
                else
                {
                    db.Database.ExecuteSqlCommand(richTextBox1.Text);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "HATA MESAJI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SQLCommand_Load(object sender, EventArgs e)
        {

        }
        private void SQLCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
                Command();
        }
        private void Chk_Connetion_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Connetion.Checked)
                richTextBox1.Text = Enc.Description(File.ReadAllText("sql.txt").ToString().ToString());
            else
                richTextBox1.Text = null;
        }
        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(richTextBox1.Text)))
            {
                FileStream fs = new ("sql.txt", FileMode.Truncate, FileAccess.Write);
                StreamWriter sw = new (fs);
                sw.Write(Enc.Log(richTextBox1.Text.ToString()).ToString());
                sw.Close();
                fs.Close();
                XtraMessageBox.Show("BAĞLANTI KOPYALAMA İŞLEMİ BAŞARILI !!", "BAŞARILI BAĞLANTI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Chk_Connetion.Checked = false;
            }
            else
            {
                XtraMessageBox.Show("LÜTFEN METİN KUTUSUNU BOŞ GEÇMEYİNİZ !!", "HATALI BAĞLANTI", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\SQL.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}