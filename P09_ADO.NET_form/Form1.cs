using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P09_ADO.NET_form {
    public partial class Form1 : Form
    {
        static string path = @"../../app97.accdb";
        static string xml_path = @"../../Appointments.xml";
        static string strConnection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path;
        private DataSet dsTemp;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = appointmentSet1.Tables["Appointments"].DefaultView;

            dateTimePicker1.Value = new DateTime(2010, 1, 11);
        }

        static void LoadTable(DataSet ds, string tableName)
        {
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

        static void StoreTable(DataSet ds, string tableName)
        {
            OleDbConnection con = new OleDbConnection(strConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + tableName, con);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            //cmdBuilder.QuotePrefix = "[";
            //cmdBuilder.QuoteSuffix = "]";
            adapter.AcceptChangesDuringUpdate = true;
            adapter.AcceptChangesDuringFill = true;
            adapter.ContinueUpdateOnError = true;
            adapter.Update(ds, tableName);
            adapter.Dispose();
            Console.WriteLine("Stored Table:" + tableName);
        }

        static void Print(DataSet ds)
        {
            Console.WriteLine("DataSet {0}:", ds.DataSetName);
            Console.WriteLine();
            foreach (DataTable t in ds.Tables)
            {
                Print(t);
                Console.WriteLine();
            }
        }

        static void Print(DataTable t)
        {
            Console.WriteLine("Tabelle {0}:", t.TableName);
            foreach (DataColumn col in t.Columns)
            {
                Console.Write(col.ColumnName + "|");
            }
            Console.WriteLine();
            for (int i = 0; i < 40; i++) { Console.Write("-"); }
            Console.WriteLine();


            int nrOfCols = t.Columns.Count;
            foreach (DataRow row in t.Rows)
            {
                for (int i = 0; i < nrOfCols; i++)
                {
                    Console.Write(row[i]); Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        private void loadMDBButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("Appointments");
            try {
                LoadTable(ds, "Appointments");
                Print(ds);
                dataGridView1.DataSource = ds.Tables["Appointments"].DefaultView;
                dsTemp = ds;
            } catch {
                // Ich konnte die Verbindung mit der accdb nicht zum laufen bringen.
            }
        }

        private void storeMDBButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("Appointments");
            DataView dv = (DataView) dataGridView1.DataSource;
            try {
                ds.Tables.Add(dv.ToTable());
                ds.AcceptChanges();
                Print(ds);
                StoreTable(ds, "Appointments");
            } catch {
                // Ich konnte die Verbindung mit der accdb nicht zum laufen bringen.
            }
        }

        private void loadXMLButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("Appointments");
            ds.ReadXml(xml_path, XmlReadMode.Auto);
            dataGridView1.DataSource = ds.Tables["Appointments"].DefaultView;
            dsTemp = ds;
        }

        private void storeXMLButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("Appointments");
            DataView dv = (DataView)dataGridView1.DataSource;
            ds.Tables.Add(dv.ToTable());
            ds.AcceptChanges();
            ds.WriteXml(xml_path);
        }

        private void filterButton_Click(object sender, EventArgs e) {
            string dateDB = dateTimePicker1.Value.ToString("MM.dd.yyyy");
            string filter = "Start > #" + dateDB + " 00:00:00# and Start < #" + dateDB + " 23:59:59#";

            DataSet ds = dsTemp;
            ds.Tables["Appointments"].DefaultView.RowFilter = filter;
            ds.AcceptChanges();
            dataGridView1.DataSource = ds.Tables["Appointments"].DefaultView;
        }

        private void resetFilterButton_Click(object sender, EventArgs e) {
            DataSet ds = dsTemp;
            ds.Tables["Appointments"].DefaultView.RowFilter = "";
            ds.AcceptChanges();
            dataGridView1.DataSource = ds.Tables["Appointments"].DefaultView;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            //
        }
    }
}
