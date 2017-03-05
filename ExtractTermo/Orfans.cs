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
using System.Net;

namespace ExtractTermo
{
    public partial class Orfans : Form
    {
        public DataTable DataSheets;
        public Orfans()
        {
            InitializeComponent();
        }

        public Orfans(DataTable dataSheets)
        {
            InitializeComponent();
            DataSheets = dataSheets;
        }

        private void Orfans_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, ((CheckBox)sender).CheckState);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString() != "server")
                LoadData(((ComboBox)sender).SelectedItem.ToString());
            else
                FtpList();
        }

        private void LoadData(string dir)
        {
            checkedListBox1.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] fis = di.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in fis)
            {
                if (DataSheets.Select(String.Format("DATASHEET='{0}'", fi.Name)).Length <= 0)
                {
                    checkedListBox1.Items.Add(fi.Name, true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "server")
            {
                string dir = Path.Combine(comboBox1.SelectedItem.ToString(), "original");
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        try
                        {
                            File.Move(Path.Combine(comboBox1.SelectedItem.ToString(), checkedListBox1.Items[i].ToString()), Path.Combine(dir, checkedListBox1.Items[i].ToString()));
                        }
                        catch {
                            try
                            {
                                File.Delete(Path.Combine(comboBox1.SelectedItem.ToString(), checkedListBox1.Items[i].ToString()));
                            }
                            catch { }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        FtpMove(checkedListBox1.Items[i].ToString());
                    }
                }
            }
            if (comboBox1.SelectedItem.ToString() != "server")
                LoadData(comboBox1.SelectedItem.ToString());
            else
                FtpList();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "server")
            {
                FileInfo fi = new FileInfo(Path.Combine(comboBox1.SelectedItem.ToString(), ((CheckedListBox)sender).SelectedItem.ToString()));
                webBrowser1.Navigate(fi.FullName);
            }else
            {
                webBrowser1.Navigate("http://www.termodinamic.com/pdf/" + ((CheckedListBox)sender).SelectedItem.ToString());
            }
        }

        private void FtpMove(string fi)
        {
            try
            {
                FtpWebRequest ftpClientMove = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/" + fi);
                ftpClientMove.Credentials = new NetworkCredential("rtermo93", "4aaa75e6f23ad");
                ftpClientMove.Method = WebRequestMethods.Ftp.Rename;
                ftpClientMove.UseBinary = true;
                ftpClientMove.KeepAlive = false;
                ftpClientMove.RenameTo = "original/" + fi;
                FtpWebResponse x = (FtpWebResponse)ftpClientMove.GetResponse();
            }
            catch { }
        }

        private void FtpList()
        {
            FtpWebRequest ftpClientList = (FtpWebRequest)FtpWebRequest.Create("ftp://www.termodinamic.com/public_html/pdf/");
            ftpClientList.Credentials = new NetworkCredential("rtermo93", "4aaa75e6f23ad");
            ftpClientList.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpClientList.UseBinary = true;
            ftpClientList.KeepAlive = false;

            FtpWebResponse response = (FtpWebResponse)ftpClientList.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, true);
            while (!reader.EndOfStream)
            {
                string fileName = reader.ReadLine();
                if (fileName.ToLower().EndsWith(".pdf") && DataSheets.Select(String.Format("DATASHEET='{0}'", fileName)).Length <= 0) // ar trebui sa compar cu db de pe server !
                {
                    checkedListBox1.Items.Add(fileName, true);
                }
            }
            reader.Close();
            response.Close();
        }
    }
}
