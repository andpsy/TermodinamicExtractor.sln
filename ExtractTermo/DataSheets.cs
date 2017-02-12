using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;

namespace ExtractTermo
{
    public partial class DataSheets : Form
    {
        public Dictionary<string, DataTable> Tabele = new Dictionary<string, DataTable>();
        public int SelectedProductIndex = 0;
        public DataSheets()
        {
            InitializeComponent();
            this.FormClosing += DataSheets_FormClosing;
        }

        private void DataSheets_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteDataToDisk();
        }

        private void WriteDataToDisk()
        {
            Tabele["products"].WriteXml(Path.Combine("DATA", "products.xml"));
            Tabele["datasheets"].WriteXml(Path.Combine("DATA", "datasheets.xml"));
            Tabele["products_datasheets"].WriteXml(Path.Combine("DATA", "products_datasheets.xml"));
        }

        private void DataSheets_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Tabele.Clear();
            DataSet ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "products.xml"));
            try
            {
                DataColumn dc = new DataColumn("MODIFICAT", Type.GetType("System.Boolean"));
                ds.Tables[0].Columns.Add(dc);
                ds.AcceptChanges();
            }
            catch { }
            Tabele.Add("products", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "products_datasheets.xml"));
            Tabele.Add("products_datasheets", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "datasheets.xml"));
            Tabele.Add("datasheets", ds.Tables[0]);
            ds.Dispose();

            checkedListBox1.DataSource = Tabele["products"];
            checkedListBox1.DisplayMember = "NAME";
            checkedListBox1.ValueMember = "ID";
            int x = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                DataRowView drv = (DataRowView)checkedListBox1.Items[i];
                checkedListBox1.SetItemCheckState(i, drv["MODIFICAT"] != DBNull.Value && Convert.ToBoolean(drv["MODIFICAT"]) ? CheckState.Checked : CheckState.Unchecked);
                x += drv["MODIFICAT"] != DBNull.Value && Convert.ToBoolean(drv["MODIFICAT"]) ? 1 : 0;
            }
            label4.Text = String.Format("Actualizate {0} din {1}", x.ToString(), checkedListBox1.Items.Count.ToString());
            checkedListBox1.SelectedIndex = SelectedProductIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".pdf";
            openFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "actual");
            DialogResult ans =  openFileDialog1.ShowDialog();
            if (ans == DialogResult.OK)
            {
                webBrowser2.Navigate(openFileDialog1.FileName);
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                textBox2.Text = textBox3.Text = fi.Name;
                checkBox1.Enabled = button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            if(fi.Name != textBox2.Text)
                File.Copy(openFileDialog1.FileName, openFileDialog1.FileName.Replace(fi.Name, textBox2.Text), true);
            MySqlConnection con = new MySqlConnection("Server=89.42.223.64;Port=3306;Database=rtermo93_termodinamic;Uid=rtermo93;Pwd=4aaa75e6f23ad;default command timeout=10240;");
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select id from datasheets where `DATASHEET`='" + textBox1.Text + "'";
            con.Open();
            int datasheet_id = Convert.ToInt32(com.ExecuteScalar());
            if (datasheet_id <= 0)
            {
                try
                {
                    datasheet_id = Convert.ToInt32(Tabele["products_datasheets"].Select(String.Format("PRODUCT_ID='{0}'", ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString()))[0]["DATASHEET_ID"]);
                }
                catch { }
            }

            if (datasheet_id > 0)
            {
                con.Close();
                FtpUpload(new FileInfo(Path.Combine("actual", textBox2.Text)));
                com = new MySqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                con.Open();
                if (checkBox1.Checked)
                {
                    com.CommandText = "delete from products_datasheets where PRODUCT_ID=" + ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString();
                    com.ExecuteNonQuery();
                    DataRow[] rs = Tabele["products_datasheets"].Select(String.Format("PRODUCT_ID='{0}'", ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString()));
                    foreach (DataRow r in rs)
                        Tabele["products_datasheets"].Rows.Remove(r);

                    com.CommandText = "insert into datasheets set `DATASHEET`='" + textBox2.Text + "'";
                    com.ExecuteNonQuery();
                    com.CommandText = "select LAST_INSERT_ID()";
                    datasheet_id = Convert.ToInt32(com.ExecuteScalar());
                    DataRow nr = Tabele["datasheets"].NewRow();
                    nr["ID"] = datasheet_id; nr["DATASHEET"] = textBox2.Text;
                    Tabele["datasheets"].Rows.Add(nr);
                    Tabele["datasheets"].AcceptChanges();
                    com.CommandText = "insert into products_datasheets set DATASHEET_ID=" + datasheet_id.ToString() + ", PRODUCT_ID=" + ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString();
                    com.ExecuteNonQuery();
                    com.CommandText = "select LAST_INSERT_ID()";
                    int pds_id = Convert.ToInt32(com.ExecuteScalar());
                    nr = Tabele["products_datasheets"].NewRow();
                    nr["ID"] = pds_id; nr["PRODUCT_ID"] = Convert.ToInt32(((DataRowView)checkedListBox1.SelectedItem)["ID"]); nr["DATASHEET_ID"] = datasheet_id;
                    Tabele["products_datasheets"].Rows.Add(nr);

                    Tabele["products_datasheets"].AcceptChanges();
                }
                else
                {
                    com.CommandText = "update datasheets set `DATASHEET`='" + textBox2.Text + "' where `ID`=" + datasheet_id.ToString();
                    com.ExecuteNonQuery();
                }
                con.Close();

                try
                {
                    openFileDialog1.FileName = "";
                    //webBrowser1.Navigate("");
                    webBrowser1.Url = null;
                    //webBrowser1.Dispose();
                    //webBrowser2.Navigate("");
                    webBrowser2.Url = null;
                    //webBrowser2.Dispose();

                    File.Delete(Path.Combine("actual", textBox3.Text));
                }
                catch { }

                DataRow[] drs = (Tabele["products_datasheets"].Select(String.Format( "DATASHEET_ID='{0}'", datasheet_id.ToString())));
                foreach(DataRow drds in drs)
                {
                    DataRow drp = (Tabele["products"].Select(String.Format( "ID='{0}'", drds["PRODUCT_ID"].ToString())))[0];
                    drp["MODIFICAT"] = true;
                }
                //DataRow dr = (Tabele["products"].Select("ID=" + ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString()))[0];
                //dr["MODIFICAT"] = true;
                Tabele["products"].AcceptChanges();
                DataRow dr = (Tabele["datasheets"].Select(String.Format( "ID='{0}'", datasheet_id.ToString())))[0];
                dr["DATASHEET"] = textBox2.Text;
                Tabele["datasheets"].AcceptChanges();
                try
                {
                    File.Copy(Path.Combine("actual", textBox2.Text), Path.Combine("pdf", textBox2.Text));
                    File.Delete(Path.Combine("pdf", textBox1.Text));
                }
                catch { }

                WriteDataToDisk();
                LoadData();
                checkBox1.Checked = false;
                textBox2.Text = textBox3.Text = "";
                checkBox1.Enabled = button2.Enabled = false;
            }
        }

        private void FtpUpload(FileInfo fi)
        {
            try
            {
                FtpWebRequest ftpClientDelete = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/" + textBox1.Text);
                ftpClientDelete.Credentials = new NetworkCredential("rtermo93", "4aaa75e6f23ad");
                ftpClientDelete.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpClientDelete.UseBinary = true;
                ftpClientDelete.KeepAlive = false;
                var x = (FtpWebResponse)ftpClientDelete.GetResponse();
            }
            catch { }

            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/" + textBox2.Text);
            ftpClient.Credentials = new NetworkCredential("rtermo93", "4aaa75e6f23ad");
            ftpClient.Method = WebRequestMethods.Ftp.UploadFile;
            ftpClient.UseBinary = true;
            ftpClient.KeepAlive = true;
            ftpClient.ContentLength = fi.Length;
            //byte[] buffer = new byte[4097];
            byte[] buffer = new byte[fi.Length];
            int bytes = 0;
            int total_bytes = (int)fi.Length;
            FileStream fs = fi.OpenRead();
            Stream rs = ftpClient.GetRequestStream();
            while (total_bytes > 0)
            {
                bytes = fs.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                total_bytes = total_bytes - bytes;
            }
            //fs.Flush();
            fs.Close();
            rs.Close();
            FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
            var value = uploadResponse.StatusDescription;
            uploadResponse.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProductIndex = ((ListBox)sender).SelectedIndex;
            //MessageBox.Show(((DataRowView)((ListBox)sender).SelectedItem)["NAME"].ToString());
            int _product_id = Convert.ToInt32(((DataRowView)((ListBox)sender).SelectedItem)["ID"]);
            var produse = from products in Tabele["products"].AsEnumerable()
                          join products_datasheets in Tabele["products_datasheets"].AsEnumerable() on Convert.ToInt32(products["ID"]) equals Convert.ToInt32(products_datasheets["PRODUCT_ID"])
                          join datasheets in Tabele["datasheets"].AsEnumerable() on Convert.ToInt32(products_datasheets["DATASHEET_ID"]) equals Convert.ToInt32(datasheets["ID"])
                          where Convert.ToInt32(products["ID"]) == _product_id
                          select new
                          {
                              PRODUCT_ID = Convert.ToInt32(products["ID"]),
                              PRODUCT_NAME = products["NAME"].ToString(),
                              PRODUCT_DESCRIPTION = products["DESCRIPTION"].ToString(),
                              PRODUCT_MANUFACTURER_PAGE = products["MANUFACTURER_PAGE"].ToString(),
                              PRODUCT_DATASHEET = datasheets["DATASHEET"].ToString(),
                              PRODUCT_STOCK = products["STOCK"].ToString()
                          };
            foreach (var produs in produse)
            {
                FileInfo fi = new FileInfo(Path.Combine("PDF", produs.PRODUCT_DATASHEET));
                webBrowser1.Navigate(fi.FullName);
                textBox1.Text = produs.PRODUCT_DATASHEET;
                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orfans o = new Orfans(Tabele["datasheets"]);
            o.ShowDialog(this);
        }
    }
}
