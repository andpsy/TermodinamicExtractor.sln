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
        public static int SelectedProductIndex = -1;
        private string MySqlConnectionString = "Server=89.42.223.64;Port=3306;Database=rtermo93_termodinamic;Uid=rtermo93;Pwd=4aaa75e6f23ad;default command timeout=10240;";
        public List<object> forUndoing = new List<object>();
        public DataSet da = new DataSet();
        public DataSheets()
        {
            InitializeComponent();
            this.FormClosing += DataSheets_FormClosing;
            this.checkedListBox1.Click += CheckedListBox1_Click;
        }

        private void CheckedListBox1_Click(object sender, EventArgs e)
        {
            SelectedProductIndex = ((CheckedListBox)sender).SelectedIndex;

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
                              PRODUCT_STOCK = products["STOCK"].ToString(),
                              PRODUCT_VISIBLE = products["visible"],
                              PRODUCT_DISPLAYORDER = products["DISPLAY_ORDER"].ToString()
                          };
            foreach (var produs in produse)
            {
                FileInfo fi = new FileInfo(Path.Combine("PDF", produs.PRODUCT_DATASHEET));
                webBrowserLocal.Navigate(fi.FullName);
                tDenumireProdusLocal.Text = produs.PRODUCT_NAME;
                tDenumireFisierLocal.Text = produs.PRODUCT_DATASHEET;
                string[] lines = produs.PRODUCT_DESCRIPTION.Split(';');
                tDescriereProdusLocal.Lines = lines;
                lIdProdusLocal.Text = produs.PRODUCT_ID.ToString();
                tPaginaProducatorLocal.Text = produs.PRODUCT_MANUFACTURER_PAGE;
                cVizibilLocal.Checked = Convert.ToBoolean(produs.PRODUCT_VISIBLE);
                tDisplayOrderLocal.Text = produs.PRODUCT_DISPLAYORDER;
                tStocLocal.Text = produs.PRODUCT_STOCK;
                break;
            }

            var poze = from pictures in Tabele["pictures"].AsEnumerable()
                       join products_pictures in Tabele["products_pictures"].AsEnumerable() on Convert.ToInt32(pictures["ID"]) equals Convert.ToInt32(products_pictures["PICTURE_ID"])
                       where Convert.ToInt32(products_pictures["PRODUCT_ID"]) == _product_id
                       select new
                       {
                           PICTURE_ID = Convert.ToInt32(pictures["ID"]),
                           PICTURE = pictures["PICTURE"].ToString(),
                           PICTURE_EXTENSION = pictures["EXTENSION"].ToString(),
                           PICTURE_DESCRIPTION = pictures["DESCRIPTION"].ToString(),
                           PICTURE_PATH = pictures["PATH"].ToString()
                          };
            int counterLocal = 0;
            panelPozeLocal.Controls.Clear();
            foreach (var poza in poze)
            {
                Image img = null;
                try
                {
                    byte[] x = Convert.FromBase64String(poza.PICTURE);
                    MemoryStream ms = new MemoryStream(x);
                    img = Image.FromStream(ms);
                }catch { img = Image.FromFile("minion.jpg"); }
                ImageControl imgCtrl = new ImageControl();
                imgCtrl.id = poza.PICTURE_ID;
                imgCtrl.path = poza.PICTURE_PATH;
                imgCtrl.extension = poza.PICTURE_EXTENSION;
                imgCtrl.textBox1.Text = poza.PICTURE_DESCRIPTION;
                imgCtrl.label1.Text = String.Format("{0} x {1}", img.Width, img.Height);
                imgCtrl.pictureBox1.Image = ScaleImage(img, imgCtrl.pictureBox1);
                imgCtrl.Top = 0; imgCtrl.Left = counterLocal * (imgCtrl.Width + 2);
                panelPozeLocal.Controls.Add(imgCtrl);
                //buttons events

                counterLocal++;
            }


            //server
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from products where `ID`=" + _product_id.ToString();
            con.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(com);
            //DataSet da = new DataSet();
            da.Clear();
            mda.Fill(da, "products");
            com.CommandText = "select d.* from datasheets d inner join products_datasheets pd on d.id=pd.datasheet_id where pd.product_id=" + _product_id.ToString();
            mda.Fill(da, "datasheets");
            com.CommandText = "select p.* from pictures p inner join products_pictures pp on p.id=pp.picture_id where pp.product_id=" + _product_id.ToString();
            mda.Fill(da, "pictures");
            con.Close();
            tDenumireFisierServer.Text = da.Tables["datasheets"].Rows[0]["DATASHEET"].ToString();
            string pdf_url = "http://www.termodinamic.com/pdf/" + da.Tables["datasheets"].Rows[0]["DATASHEET"].ToString();
            webBrowserServer.Navigate(pdf_url);
            lIdProdusServer.Text = da.Tables["products"].Rows[0]["ID"].ToString();
            tDenumireProdusServer.Text = da.Tables["products"].Rows[0]["NAME"].ToString();
            string[] lServer = da.Tables["products"].Rows[0]["DESCRIPTION"].ToString().Split(';');
            tDescriereProdusServer.Lines = lServer;
            tPaginaProducatorServer.Text = da.Tables["products"].Rows[0]["MANUFACTURER_PAGE"].ToString();
            cVizibilServer.Checked = Convert.ToBoolean(da.Tables["products"].Rows[0]["visible"]);
            tDisplayOrderServer.Text = da.Tables["products"].Rows[0]["DISPLAY_ORDER"].ToString();
            tStocServer.Text = da.Tables["products"].Rows[0]["STOCK"].ToString();

            int counterServer = 0;
            panelPozeServer.Controls.Clear();
            foreach (DataRow dr in da.Tables["pictures"].Rows)
            {
                MemoryStream ms = new MemoryStream((byte[])dr["PICTURE"]);
                Image img = null;
                try
                {
                    img = Image.FromStream(ms);
                }catch { img = Image.FromFile("minion.jpg"); }
                ImageControl imgCtrl = new ImageControl();
                imgCtrl.id = Convert.ToInt32( dr["ID"]);
                imgCtrl.path = dr["PATH"].ToString();
                imgCtrl.extension = dr["EXTENSION"].ToString();
                imgCtrl.textBox1.Text = dr["DESCRIPTION"].ToString();
                imgCtrl.label1.Text = String.Format("{0} x {1}", img.Width, img.Height);
                imgCtrl.pictureBox1.Image = ScaleImage(img, imgCtrl.pictureBox1);
                imgCtrl.Top = 0; imgCtrl.Left = counterServer * (imgCtrl.Width + 2);
                panelPozeServer.Controls.Add(imgCtrl);

                counterServer++;
            }
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
            Tabele["pictures"].WriteXml(Path.Combine("DATA", "pictures.xml"));
            Tabele["products_pictures"].WriteXml(Path.Combine("DATA", "products_pictures.xml"));
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
            } catch { }
            try {
                ds.Tables[0].Columns["ID"].AutoIncrement = true;
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ID"] };
                ds.AcceptChanges();
            }
            catch(Exception exp) { }
            Tabele.Add("products", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "products_datasheets.xml"));
            try
            {
                ds.Tables[0].Columns["ID"].AutoIncrement = true;
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ID"] };
                ds.AcceptChanges();
            }
            catch (Exception exp) { }
            Tabele.Add("products_datasheets", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "datasheets.xml"));
            try
            {
                ds.Tables[0].Columns["ID"].AutoIncrement = true;
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ID"] };
                ds.AcceptChanges();
            }
            catch (Exception exp) { }
            Tabele.Add("datasheets", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "products_pictures.xml"));
            try
            {
                ds.Tables[0].Columns["ID"].AutoIncrement = true;
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ID"] };
                ds.AcceptChanges();
            }
            catch (Exception exp) { }
            Tabele.Add("products_pictures", ds.Tables[0]);
            ds = new DataSet();
            ds.ReadXml(Path.Combine("DATA", "pictures.xml"));
            try
            {
                ds.Tables[0].Columns["ID"].AutoIncrement = true;
                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["ID"] };
                ds.AcceptChanges();
            }
            catch (Exception exp) { }
            Tabele.Add("pictures", ds.Tables[0]);
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

        private void FtpUpload(FileInfo fi)
        {
            try
            {
                FtpWebRequest ftpClientDelete = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/" + tDenumireFisierLocal.Text);
                ftpClientDelete.Credentials = new NetworkCredential("rtermo93", "4aaa75e6f23ad");
                ftpClientDelete.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpClientDelete.UseBinary = true;
                ftpClientDelete.KeepAlive = false;
                var x = (FtpWebResponse)ftpClientDelete.GetResponse();
            }
            catch { }

            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/" + tDenumireFisierNouModificata.Text);
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

        }

        public static Image ScaleImage(Image image, PictureBox pb)
        {
            double ratioX = (double)pb.Width / (double)image.Width;
            double ratioY = (double)pb.Height / (double)image.Height;
            double sz = (double)Math.Max(image.Width, image.Height);
            double ratio = (double)Math.Min(pb.Width, pb.Height) / sz;
            ratio = ratio > 1 ? 1 : ratio;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void bPreluarePeServer_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Confirma suprascrierea valorilor de pe server cu cele de pe local!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d != DialogResult.Yes) return;
            forUndoing.Clear();
            forUndoing.Add("local->server");
            forUndoing.Add(tDenumireProdusServer.Text);
            forUndoing.Add(tDescriereProdusServer.Lines);
            forUndoing.Add(tPaginaProducatorServer.Text);
            forUndoing.Add(cVizibilServer.Checked);
            forUndoing.Add(tDisplayOrderServer.Text);
            forUndoing.Add(tStocServer.Text);
            foreach (ImageControl c in panelPozeServer.Controls)
            {
                ImageControl imgCtrl = new ImageControl();
                imgCtrl.pictureBox1.Image = c.pictureBox1.Image;
                imgCtrl.textBox1.Text = c.textBox1.Text;
                imgCtrl.label1.Text = c.label1.Text;
                imgCtrl.checkBox1.Checked = c.checkBox1.Checked;
                imgCtrl.id = c.id;
                imgCtrl.path = c.path;
                imgCtrl.extension = c.extension;
                forUndoing.Add(imgCtrl);
            }

            tDenumireProdusServer.Text = tDenumireProdusLocal.Text;
            tDescriereProdusServer.Lines = tDescriereProdusLocal.Lines;
            tPaginaProducatorServer.Text = tPaginaProducatorLocal.Text;
            cVizibilServer.Checked = cVizibilLocal.Checked;
            tDisplayOrderServer.Text = tDisplayOrderLocal.Text;
            tStocServer.Text = tStocLocal.Text;
            panelPozeServer.Controls.Clear();
            foreach (ImageControl c in panelPozeLocal.Controls)
                if (c.checkBox1.Checked)
                {
                    ImageControl imgCtrl = new ImageControl();
                    imgCtrl.id = c.id;
                    imgCtrl.path = c.path;
                    imgCtrl.extension = c.extension;
                    imgCtrl.textBox1.Text = c.textBox1.Text;
                    imgCtrl.pictureBox1.Image = c.pictureBox1.Image;
                    imgCtrl.label1.Text = c.label1.Text;
                    imgCtrl.checkBox1.Checked = c.checkBox1.Checked;
                    imgCtrl.Top = 0;
                    imgCtrl.Left = panelPozeServer.Controls.Count * (imgCtrl.Width + 2);
                    panelPozeServer.Controls.Add(imgCtrl);
                }
        }

        private void bPreluarePeLocal_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Confirma suprascrierea valorilor de pe local cu cele de pe server!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d != DialogResult.Yes) return;
            forUndoing.Clear();
            forUndoing.Add("server->local");
            forUndoing.Add(tDenumireProdusLocal.Text);
            forUndoing.Add(tDescriereProdusLocal.Lines);
            forUndoing.Add(tPaginaProducatorLocal.Text);
            forUndoing.Add(cVizibilLocal.Checked);
            forUndoing.Add(tDisplayOrderLocal.Text);
            forUndoing.Add(tStocLocal.Text);
            foreach (ImageControl c in panelPozeLocal.Controls)
            {
                ImageControl imgCtrl = new ImageControl();
                imgCtrl.pictureBox1.Image = c.pictureBox1.Image;
                imgCtrl.textBox1.Text = c.textBox1.Text;
                imgCtrl.label1.Text = c.label1.Text;
                imgCtrl.checkBox1.Checked = c.checkBox1.Checked;
                imgCtrl.id = c.id;
                imgCtrl.path = c.path;
                imgCtrl.extension = c.extension;
                forUndoing.Add(imgCtrl);
            }

            tDenumireProdusLocal.Text = tDenumireProdusServer.Text;
            tDescriereProdusLocal.Lines = tDescriereProdusServer.Lines;
            tPaginaProducatorLocal.Text = tPaginaProducatorServer.Text;
            cVizibilLocal.Checked = cVizibilServer.Checked;
            tDisplayOrderLocal.Text = tDisplayOrderServer.Text;
            tStocLocal.Text = tStocServer.Text;
            panelPozeLocal.Controls.Clear();
            foreach (ImageControl c in panelPozeServer.Controls)
                if (c.checkBox1.Checked)
                {
                    ImageControl imgCtrl = new ImageControl();
                    imgCtrl.id = c.id;
                    imgCtrl.path = c.path;
                    imgCtrl.extension = c.extension;
                    imgCtrl.textBox1.Text = c.textBox1.Text;
                    imgCtrl.pictureBox1.Image = c.pictureBox1.Image;
                    imgCtrl.label1.Text = c.label1.Text;
                    imgCtrl.checkBox1.Checked = c.checkBox1.Checked;
                    imgCtrl.Top = 0;
                    imgCtrl.Left = panelPozeLocal.Controls.Count * (imgCtrl.Width + 2);
                    panelPozeLocal.Controls.Add(imgCtrl);
                }
        }

        private void bAddLocal_Click(object sender, EventArgs e)
        {
            DialogResult ans = openFileDialog1.ShowDialog();
            if (ans == DialogResult.OK)
            {
                panelPozeLocal.HorizontalScroll.Value = 0;
                tNewImgLocal.Text = openFileDialog1.FileName;
                Image img = Image.FromFile(openFileDialog1.FileName);
                ImageControl imgCtrl = new ImageControl();
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                imgCtrl.extension = fi.Extension.Remove(0, 1);
                imgCtrl.pictureBox1.Image = ScaleImage(img, imgCtrl.pictureBox1);
                imgCtrl.label1.Text = String.Format("{0} x {1}", img.Width, img.Height);
                imgCtrl.Top = 0;
                imgCtrl.Left = panelPozeLocal.Controls.Count * (imgCtrl.Width + 2);
                panelPozeLocal.Controls.Add(imgCtrl);
            }
        }

        private void bDeleteLocal_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < panelPozeLocal.Controls.Count; i++)
            {
                if (((ImageControl)panelPozeLocal.Controls[i]).checkBox1.Checked)
                    panelPozeLocal.Controls.Remove(panelPozeLocal.Controls[i]);
            }
        }

        private void bDeleteServer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panelPozeServer.Controls.Count; i++)
            {
                if (((ImageControl)panelPozeServer.Controls[i]).checkBox1.Checked)
                    panelPozeServer.Controls.Remove(panelPozeServer.Controls[i]);
            }
        }

        private void bAddServer_Click(object sender, EventArgs e)
        {
            DialogResult ans = openFileDialog1.ShowDialog();
            if (ans == DialogResult.OK)
            {
                panelPozeServer.HorizontalScroll.Value = 0;
                tNewImgServer.Text = openFileDialog1.FileName;
                Image img = Image.FromFile(openFileDialog1.FileName);
                ImageControl imgCtrl = new ImageControl();
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                imgCtrl.extension = fi.Extension.Remove(0, 1);
                imgCtrl.pictureBox1.Image = ScaleImage(img, imgCtrl.pictureBox1);
                imgCtrl.label1.Text = String.Format("{0} x {1}", img.Width, img.Height);
                imgCtrl.Top = 0;
                imgCtrl.Left = panelPozeServer.Controls.Count * (imgCtrl.Width + 2);
                panelPozeServer.Controls.Add(imgCtrl);
            }
        }

        private void cToatePozeleLocal_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ImageControl c in panelPozeLocal.Controls)
                c.checkBox1.Checked = ((CheckBox)sender).Checked;
        }

        private void cToatePozeleServer_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ImageControl c in panelPozeServer.Controls)
                c.checkBox1.Checked = ((CheckBox)sender).Checked;
        }

        private void bUndoLocal_Click(object sender, EventArgs e)
        {
            if (forUndoing[0].ToString() == "local->server")
            {
                tDenumireProdusServer.Text = forUndoing[1].ToString();
                tDescriereProdusServer.Lines = (string[])forUndoing[2];
                tPaginaProducatorServer.Text = forUndoing[3].ToString();
                cVizibilServer.Checked = Convert.ToBoolean(forUndoing[4]);
                tDisplayOrderServer.Text = forUndoing[5].ToString();
                tStocServer.Text = forUndoing[6].ToString();
                panelPozeServer.Controls.Clear();
                for (int i = 7; i < forUndoing.Count; i++)
                {
                    ImageControl imgCtrl = (ImageControl)forUndoing[i];
                    imgCtrl.Top = 0;
                    imgCtrl.Left = panelPozeServer.Controls.Count * (imgCtrl.Width + 2);
                    panelPozeServer.Controls.Add(imgCtrl);
                }
            }
        }

        private void bUndoServer_Click(object sender, EventArgs e)
        {
            if (forUndoing[0].ToString() == "server->local")
            {
                tDenumireProdusLocal.Text = forUndoing[1].ToString();
                tDescriereProdusLocal.Lines = (string[])forUndoing[2];
                tPaginaProducatorLocal.Text = forUndoing[3].ToString();
                cVizibilLocal.Checked = Convert.ToBoolean(forUndoing[4]);
                tDisplayOrderLocal.Text = forUndoing[5].ToString();
                tStocLocal.Text = forUndoing[6].ToString();
                panelPozeLocal.Controls.Clear();
                for (int i = 7; i < forUndoing.Count; i++)
                {
                    ImageControl imgCtrl = (ImageControl)forUndoing[i];
                    imgCtrl.Top = 0;
                    imgCtrl.Left = panelPozeLocal.Controls.Count * (imgCtrl.Width + 2);
                    panelPozeLocal.Controls.Add(imgCtrl);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tDenumireProdusServer.Text.Trim() == "") throw new Exception("Nume necompletat");
                if (tDescriereProdusServer.Lines.Length < 1) throw new Exception("Descriere necompletata");
                try { int i = Convert.ToInt32(tDisplayOrderServer.Text); } catch { throw new Exception("Display order invalid"); }
                try { int i = Convert.ToInt32(tStocServer.Text); } catch { throw new Exception("Stoc invalid"); }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Eroare!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tDenumireProdusLocal.Text != tDenumireProdusServer.Text || String.Join(";", tDescriereProdusLocal.Lines) != String.Join(";", tDescriereProdusServer.Lines) || tDisplayOrderLocal.Text != tDisplayOrderServer.Text || tStocLocal.Text != tStocServer.Text || cVizibilLocal.Checked != cVizibilServer.Checked)
            {
                MessageBox.Show("Valorile de pe local nu coincid cu cele de pe server", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveServer();
            SaveLocal();

            WriteDataToDisk();
            LoadData();
        }

        private void SaveLocal()
        {
            DataRow produs = Tabele["products"].Select(String.Format("ID='{0}'", lIdProdusServer.Text))[0];
            produs["NAME"] = tDenumireProdusServer.Text;
            produs["DESCRIPTION"] = String.Join(";", tDescriereProdusServer.Lines); ;
            produs["MANUFACTURER_PAGE"] = tPaginaProducatorServer.Text;
            produs["VISIBLE"] = cVizibilServer.Checked;
            produs["DISPLAY_ORDER"] = Convert.ToInt32(tDisplayOrderServer.Text);
            produs["STOCK"] = tStocServer.Text;
            produs.AcceptChanges();
            Tabele["products"].AcceptChanges();

            DataRow[] pps = Tabele["products_pictures"].Select(String.Format("product_id='{0}'", lIdProdusLocal.Text));
            foreach (DataRow pp in pps)
            {
                bool gasit = false;
                foreach (ImageControl c in panelPozeServer.Controls)
                {
                    if (pp["PICTURE_ID"].ToString() == c.id.ToString())
                    {
                        gasit = true;
                        break;
                    }
                }
                if (!gasit)
                {
                    DataRow[] ps = Tabele["pictures"].Select(String.Format("ID='{0}'", pp["picture_id"].ToString()));
                    foreach (DataRow p in ps)
                        p.Delete();
                    pp.Delete();
                }
            }
            Tabele["products_pictures"].AcceptChanges();
            Tabele["pictures"].AcceptChanges();

            foreach (ImageControl c in panelPozeServer.Controls)
            {
                if (c.checkBox1.Checked)
                {
                    DataRow p = Tabele["pictures"].NewRow();
                    p["ID"] = c.id;
                    p["PICTURE"] = Convert.ToBase64String(ImageToByteArray(c.pictureBox1.Image));
                    p["DESCRIPTION"] = c.textBox1.Text;
                    p["EXTENSION"] = c.extension;
                    p["PATH"] = c.path;
                    Tabele["pictures"].Rows.Add(p);
                    Tabele["pictures"].AcceptChanges();

                    DataRow ppr = Tabele["products_pictures"].NewRow();
                    ppr["PRODUCT_ID"] = lIdProdusLocal.Text;
                    ppr["PICTURE_ID"] = p["ID"];
                    ppr["ID"] = c.pp_id;
                    ppr["DISPLAY_ORDER"] = 1;
                    Tabele["products_pictures"].Rows.Add(ppr);
                    Tabele["products_pictures"].AcceptChanges();
                }
            }
        }

        private void SaveServer()
        {
            string Description = String.Join(";", tDescriereProdusServer.Lines);

            MySqlConnection con = new MySqlConnection("Server=89.42.223.64;Port=3306;Database=rtermo93_termodinamic;Uid=rtermo93;Pwd=4aaa75e6f23ad;default command timeout=10240;");
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = String.Format("update products set NAME='{0}', DESCRIPTION='{1}', MANUFACTURER_PAGE='{2}', VISIBLE={3}, DISPLAY_ORDER={4}, STOCK={5} where ID={6}",
                tDenumireProdusServer.Text,
                Description,
                tPaginaProducatorServer.Text,
                cVizibilServer.Checked.ToString(),
                tDisplayOrderServer.Text,
                tStocServer.Text,
                lIdProdusServer.Text
                );
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            foreach (DataRow dr in da.Tables["pictures"].Rows)
            {
                bool gasit = false;
                foreach(ImageControl c in panelPozeServer.Controls)
                {
                    if(dr["ID"].ToString() == c.id.ToString())
                    {
                        gasit = true;
                        break;
                    }
                }
                if (!gasit)
                {
                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("delete from products_pictures where picture_id={0}", dr["ID"].ToString());
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("delete from pictures where id={0}", dr["ID"].ToString());
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                }
            }

            foreach(ImageControl c in panelPozeServer.Controls)
            {
                com = new MySqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandText = String.Format("select id from pictures where id={0}", c.id.ToString());
                con.Open();
                object id = com.ExecuteScalar();
                con.Close();
                if(id == null)
                {
                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("insert into pictures set picture=@blobGatuMatii, extension='{0}', description='{1}', path='{2}'",                        
                        c.extension,
                        c.textBox1.Text,
                        c.path);

                    byte[] data = ImageToByteArray(c.pictureBox1.Image);
                    MySqlParameter blob = new MySqlParameter("@blobGatuMatii", MySqlDbType.Blob, data.Length);
                    blob.Value = data;
                    com.Parameters.Add(blob);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("select last_insert_id()");
                    con.Open();
                    object new_id = com.ExecuteScalar();
                    con.Close();
                    c.id = Convert.ToInt32(new_id);

                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("insert into products_pictures set product_id={0}, picture_id={1}, display_order={2}",
                        lIdProdusServer.Text,
                        new_id.ToString(),
                        "1");
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();

                    com = new MySqlCommand();
                    com.Connection = con;
                    com.CommandType = CommandType.Text;
                    com.CommandText = String.Format("select last_insert_id()");
                    con.Open();
                    object new_id_pp = com.ExecuteScalar();
                    con.Close();
                    c.pp_id = Convert.ToInt32(new_id_pp);
                }
            }
        }

        public byte[] ImageToByteArray(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void bFisiereOrfane_Click(object sender, EventArgs e)
        {
            Orfans o = new Orfans(Tabele["datasheets"]);
            o.ShowDialog(this);
        }

        private void bSavePeServer_Click(object sender, EventArgs e)
        {
            {
                DialogResult ans = MessageBox.Show("Nu ati modificat denumirea fisierului! Continuati?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.No) return;
            }
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            if (fi.Name != tDenumireFisierNouModificata.Text)
                File.Copy(openFileDialog1.FileName, openFileDialog1.FileName.Replace(fi.Name, tDenumireFisierNouModificata.Text), true);
            MySqlConnection con = new MySqlConnection(MySqlConnectionString);
            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = "select id from datasheets where `DATASHEET`='" + tDenumireFisierLocal.Text + "'";
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
                FtpUpload(new FileInfo(Path.Combine("actual", tDenumireFisierNouModificata.Text)));
                com = new MySqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                con.Open();
                if (cCreazaFisaNoua.Checked)
                {
                    com.CommandText = String.Format("delete from products_datasheets where PRODUCT_ID={0}", ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString());
                    com.ExecuteNonQuery();
                    DataRow[] rs = Tabele["products_datasheets"].Select(String.Format("PRODUCT_ID='{0}'", ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString()));
                    foreach (DataRow r in rs)
                        Tabele["products_datasheets"].Rows.Remove(r);

                    com.CommandText = "insert into datasheets set `DATASHEET`='" + tDenumireFisierNouModificata.Text + "'";
                    com.ExecuteNonQuery();
                    com.CommandText = "select LAST_INSERT_ID()";
                    datasheet_id = Convert.ToInt32(com.ExecuteScalar());
                    DataRow nr = Tabele["datasheets"].NewRow();
                    nr["ID"] = datasheet_id; nr["DATASHEET"] = tDenumireFisierNouModificata.Text;
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
                    com.CommandText = "update datasheets set `DATASHEET`='" + tDenumireFisierNouModificata.Text + "' where `ID`=" + datasheet_id.ToString();
                    com.ExecuteNonQuery();
                }
                con.Close();

                try
                {
                    openFileDialog1.FileName = "";
                    //webBrowser1.Navigate("");
                    webBrowserLocal.Url = null;
                    //webBrowser1.Dispose();
                    //webBrowser2.Navigate("");
                    webBrowserNou.Url = null;
                    //webBrowser2.Dispose();

                    File.Delete(Path.Combine("actual", tDenumireFisierNou.Text));
                }
                catch { }

                DataRow[] drs = (Tabele["products_datasheets"].Select(String.Format("DATASHEET_ID='{0}'", datasheet_id.ToString())));
                foreach (DataRow drds in drs)
                {
                    DataRow drp = (Tabele["products"].Select(String.Format("ID='{0}'", drds["PRODUCT_ID"].ToString())))[0];
                    drp["MODIFICAT"] = true;
                }
                //DataRow dr = (Tabele["products"].Select("ID=" + ((DataRowView)checkedListBox1.SelectedItem)["ID"].ToString()))[0];
                //dr["MODIFICAT"] = true;
                Tabele["products"].AcceptChanges();
                DataRow dr = (Tabele["datasheets"].Select(String.Format("ID='{0}'", datasheet_id.ToString())))[0];
                dr["DATASHEET"] = tDenumireFisierNouModificata.Text;
                Tabele["datasheets"].AcceptChanges();
                try
                {
                    File.Copy(Path.Combine("actual", tDenumireFisierNouModificata.Text), Path.Combine("pdf", tDenumireFisierNouModificata.Text));
                    File.Delete(Path.Combine("pdf", tDenumireFisierLocal.Text));
                }
                catch { }

                WriteDataToDisk();
                LoadData();
                cCreazaFisaNoua.Checked = false;
                tDenumireFisierNouModificata.Text = tDenumireFisierNou.Text = "";
                cCreazaFisaNoua.Enabled = bSavePeServer.Enabled = false;
            }
        }

        private void nIncarca_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".pdf";
            openFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Path.Combine(Environment.CurrentDirectory, "actual");
            DialogResult ans = openFileDialog1.ShowDialog();
            if (ans == DialogResult.OK)
            {
                webBrowserNou.Navigate(openFileDialog1.FileName);
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                tDenumireFisierNouModificata.Text = tDenumireFisierNou.Text = fi.Name;
                cCreazaFisaNoua.Enabled = bSavePeServer.Enabled = true;
            }
        }
    }
}
