using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09_ADO.NET
{
    class Program
    {
        private const string accdbFilepath = @"C:\Projects\DNET1-P\DNET1\P09_ADO.NET\app97.accdb";
        static string path = @"../../app97.accdb";
        static string xml_path = @"../../Appointments.xml";
        static string strConnection = @"Provider=Microsoft.ACE.OLEDB.16.0; Data Source=" + path;
        static void Main(string[] args)
        {
            //IDbConnection conn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0; data source = m:\private\app97.mdb;");


            //IDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.14.0; Data Source = " + accdbFilepath);
            //conn.Open();
            
            //IDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.10.0; Data Source=../../app97.accdb;");
            //conn.Open();
            DataSet ds = new DataSet("Appointments");
            //var strConnection =@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=../../app97.accdb;";
            var tableName = "Appointments";
            OleDbConnection con = new OleDbConnection(strConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + tableName, con);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(ds, tableName);
            if (ds.HasErrors)
            {
                ds.RejectChanges();
                throw new Exception("Error Loading Data");
            }
            else ds.AcceptChanges();
            adapter.Dispose();
            Console.WriteLine("Loaded Table:" + tableName);
        }
    }
}
