using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace ExtractTermo
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Server=89.42.223.64;Port=3306;Database=rtermo93_termodinamic;Uid=rtermo93;Pwd=4aaa75e6f23ad;default command timeout=10240;";
            MySqlConnection mcon = new MySqlConnection(ConnectionString);
            MySqlCommand mcom = new MySqlCommand();
            mcom.Connection = mcon;
            mcom.CommandType = CommandType.Text;
            mcom.CommandText = "show tables from `rtermo93_termodinamic`";
            MySqlDataAdapter ma = new MySqlDataAdapter(mcom);
            DataTable da = new DataTable();
            mcon.Open();
            ma.Fill(da);
            mcon.Close();
            foreach(DataRow dr in da.Rows)
            {
                Console.Error.Write(dr[0].ToString() + "\r\n");
                MySqlConnection mcon2 = new MySqlConnection(ConnectionString);
                mcon2.Open();
                MySqlCommand mcom2 = new MySqlCommand();
                mcom2.Connection = mcon2;
                mcom2.CommandType = CommandType.Text;
                mcom2.CommandText = String.Format( "select * from `{0}`", dr[0].ToString());
                MySqlDataAdapter ma2 = new MySqlDataAdapter(mcom2);
                DataTable da2 = new DataTable(dr[0].ToString());
                ma2.Fill(da2);
                da2.WriteXml(Path.Combine("DATA", String.Format("{0}.xml", dr[0].ToString())));
                mcon2.Close();
            }
        }
    }
}
