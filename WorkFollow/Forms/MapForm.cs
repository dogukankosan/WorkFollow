using DevExpress.XtraEditors;
using LiveCharts.WinForms;
using MVCFirmaCagri.Encription;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace WorkFollow.Forms
{
    public partial class MapForm : DevExpress.XtraEditors.XtraForm
    {
        public MapForm()
        {
            InitializeComponent();
        }
        private string[] city;
        private string[] cityvalue;
        private Int16 i = 0;
        private bool control = false;
        private readonly Entitiy.DbWorkFollowEntities db = new();
        private readonly SqlConnection myConnection = new(Enc.Description(File.ReadAllText("sql.txt")));
        void List(string text)
        {
            try
            {
                myConnection.Open();
                SqlCommand command2 = new SqlCommand(text, myConnection);
                SqlDataReader read1 = command2.ExecuteReader();
                while (read1.Read())
                {
                    i++;
                }
                myConnection.Close();
                city = new string[i];
                cityvalue = new string[i];
                i = 0;
            }
            catch (Exception a)
            {
                XtraMessageBox.Show(a.Message, "HATALI OKUMA İŞLEMİ1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(text, myConnection);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    city[i] = rd[0].ToString();
                    cityvalue[i] = rd[1].ToString();
                    i++;
                }
                myConnection.Close();
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message, "HATALI OKUMA İŞLEMİ2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GeoMap_LandClick(object arg1, LiveCharts.Maps.MapData arg2)
        {
            control = false;
            for (int i = 0; i < city.Length; i++)
            {
                if (arg2.Name.ToString() == city[i].ToString())
                {
                    XtraMessageBox.Show(arg2.Name + " ŞEHİRİNE AİT (" + cityvalue[i].ToString() + ") FİRMA BULUNMAKTADIR.", "ŞEHİRE AİT FİRMA SAYISI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MapDetails mpd = new MapDetails();
                    mpd.id = arg2.Name;
                    control = true;
                    mpd.ShowDialog();
                    break;
                }
            }
            if (control == false)
            {
                XtraMessageBox.Show(arg2.Name + " ŞEHİRİNE AİT (0) FİRMA BULUNMAKTADIR.", "ŞEHİRE AİT FİRMA SAYISI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MapForm_Load(object sender, EventArgs e)
        {
            GeoMap geo = new GeoMap { Source = $"{Application.StartupPath}\\LiveChart.xml" };
            this.Controls.Add(geo);
            geo.Dock = DockStyle.Fill;
            geo.LandClick += GeoMap_LandClick;
            geo.Hoverable = true;
            List("select Iller.Il as 'Il',count(*) as 'Sayisi' from Company inner join Iller on Iller.IlID=Company.CompanyCity\r\ngroup by Iller.Il\r\norder by count(*) desc");
        }
        private void MapForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}