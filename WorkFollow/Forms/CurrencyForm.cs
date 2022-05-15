using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace WorkFollow.Forms
{
    public partial class CurrencyForm : DevExpress.XtraEditors.XtraForm
    {
        public CurrencyForm()
        {
            InitializeComponent();
        }
        private readonly string[] curr = new String[] { "USD", "EUR", "GBP", "SAR", "AZN", "BGN", "RUB", "QAR", "CNY", "JPY" };
        private string gun = String.Empty, ay = String.Empty;
        private readonly XmlDocument xml = new();
        private void CurrencyForm_Load(object sender, EventArgs e)
        {
        }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CurrecyGet();
        }
        private void excelAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && dateEdit1.EditValue is not null)
                {
                    gridView1.ExportToXlsx(folderBrowserDialog1.SelectedPath + "\\" + dateEdit1.DateTime.ToShortDateString() + " TarihliKur.xlsx");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("EXCELE ALMA İŞLEMİ HATALI EXCEL PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pDFAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && dateEdit1.EditValue is not null)
                {
                    gridView1.ExportToPdf(folderBrowserDialog1.SelectedPath + "\\" + dateEdit1.DateTime.ToShortDateString() + " TarihliKur.pdf");
                }
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("PDF ALMA İŞLEMİ HATALI PDF PROGRAMI ALTTA AÇIK !!",
                    exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CurrencyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void CurrecyGet()
        {
            DataTable dt = new ();
            DataRow drs;
            dt.Columns.Add("Doviz Turu", typeof(string));
            dt.Columns.Add("Doviz Alis", typeof(string));
            dt.Columns.Add("Doviz Satis", typeof(string));
            dt.Columns.Add("Efektif Alis", typeof(string));
            dt.Columns.Add("Efektif Satis", typeof(string));
            try
            {
                DateTime day = dateEdit1.DateTime;
                if (day.Day.ToString().Length < 2)
                    gun = "0" + day.Day.ToString();
                else
                    gun = day.Day.ToString();
                if (day.Month.ToString().Length < 2)
                    ay = "0" + day.Month.ToString();
                else
                    ay = day.Month.ToString();
                xml.Load("https://www.tcmb.gov.tr/kurlar/" + day.Year.ToString() + "" + ay + "/" + gun + "" + ay +
                         "" + day.Year.ToString() + ".xml");
                for (byte i = 0; i < curr.Length; i++)
                {
                    drs = dt.NewRow();
                    drs["Doviz Turu"] =
                        xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + curr[i] + "']/CurrencyName").InnerXml
                            .ToString();
                    drs["Doviz Alis"] = xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + curr[i] + "']/ForexBuying").InnerXml.ToString();
                    drs["Doviz Satis"] =
                        xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + curr[i] + "']/ForexSelling").InnerXml.ToString();
                    drs["Efektif Alis"] =
                        xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + curr[i] + "']/BanknoteBuying").InnerXml.ToString();
                    drs["Efektif Satis"] =
                        xml.SelectSingleNode("Tarih_Date/Currency [@Kod='" + curr[i] + "']/BanknoteSelling").InnerXml.ToString();
                    dt.Rows.Add(drs);
                }
                gridControl1.DataSource = dt;
            }
            catch (Exception a)
            {
                XtraMessageBox.Show(
                    "ÇEKMEK İSTEDİĞİNİZ TARİHTE KUR BİLGİSİ BULUNAMAMIŞTIR. LÜTFEN TARİHİ KONTROL EDİNİZ !!",
                    a.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}