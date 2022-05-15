using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using MVCFirmaCagri.Encription;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class DepartmanChart : DevExpress.XtraEditors.XtraForm
    {
        public DepartmanChart()
        {
            InitializeComponent();
        }

        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly SqlConnection myConnection = new(Enc.Description(File.ReadAllText("sql.txt")));
        private readonly FolderBrowserDialog folderBrowserDialog1 = new();
        void Command(string text)
        {
            try
            {
                myConnection.Open();
                SqlCommand cmd = new(text, myConnection);
                SqlDataReader rd = cmd.ExecuteReader();
                chartControl1.Series.Add("DEPARTMANLAR", ViewType.Pie3D);
                while (rd.Read())
                {
                    chartControl1.Series[0].Points.AddPoint(rd[0].ToString(), Convert.ToByte(rd[1]));
                }
                myConnection.Close();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("HATALI OKUMA BAĞLANTIYI KONTROL ET", "OKUMA HATALI", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                myConnection.Close();
            }
        }
        private void DepartmanChart_Load(object sender, EventArgs e)
        {
            Command("select Department.DepartmentName as 'DepartmanAdi',Count(*) as 'Sayisi' from Taskes inner join Personeles on Personeles.ID=\r\nTaskReceiver\r\ninner join Department on Department.ID=DepartmentID group by Department.DepartmentName\r\norder by count(*) desc");
        }
        private void DepartmanChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\DepartmanTaskChart.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCEL ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    chartControl1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\DepartmanTaskChart.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}