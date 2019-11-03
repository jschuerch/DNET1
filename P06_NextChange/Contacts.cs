using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_NextChange
{
    class Contacts
    {
        private ICollection<Contact> contactList { get; set; }
        private Dictionary<String, Action<Contact, string>> mappingsRead;
        private Dictionary<String, Func<Contact, string>> mappingsWrite;
        private string columnsWrite;

        public Contacts()
        {
            contactList = new List<Contact>();
            mappingsRead = new Dictionary<string, Action<Contact, string>>();
            mappingsRead.Add("TelIntern", (contact, value) => contact.BusinessPhone = value);
            mappingsRead.Add("Nachname", (contact, value) => contact.LastName = value);
            mappingsRead.Add("Vorname", (contact, value) => contact.FirstName = value);
            mappingsRead.Add("PKZ", (contact, value) => contact.Initials = value);
            mappingsRead.Add("Gebaeude", (contact, value) => contact.OfficeLocation = value + contact.OfficeLocation);
            mappingsRead.Add("Büro", (contact, value) => contact.OfficeLocation += value);
            mappingsRead.Add("Departement", (contact, value) => contact.Department = value);
            mappingsRead.Add("Taetigkeit", (contact, value) => contact.JobTitle = value);
            mappingsRead.Add("Kategorie", (contact, value) => contact.Categories = value);

            mappingsWrite = new Dictionary<string, Func<Contact, string>>();
            mappingsWrite.Add("TelIntern", (contact) => contact.BusinessPhone);
            mappingsWrite.Add("Nachname", (contact) => contact.LastName);
            mappingsWrite.Add("Vorname", (contact) => contact.FirstName);
            mappingsWrite.Add("PKZ", (contact) => contact.Initials);
            mappingsWrite.Add("Gebaeude", (contact) => contact.OfficeLocation);
            mappingsWrite.Add("Departement", (contact) => contact.Department);
            mappingsWrite.Add("Taetigkeit", (contact) => contact.JobTitle);
            mappingsWrite.Add("Kategorie", (contact) => contact.Categories);

            columnsWrite = "TelIntern;Nachname;Vorname;PKZ;Gebaeude;Departement;Taetigkeit;Kategorie";
        }

        public void ReadCSV(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine(filename + " does not exist");
                return;
            }

            var sr = new StreamReader(filename, Encoding.GetEncoding("windows-1252"));

            string line = sr.ReadLine();
            string[] headerCells = line.Split(';');

            while ((line = sr.ReadLine()) != null)
            {
                string[] cells = line.Split(';');
                int i = 0;
                Contact c = new Contact();
                foreach (var cell in cells)
                {
                    mappingsRead[headerCells[i]](c, cell);
                    i++;
                }
                contactList.Add(c);
            }

            sr.Close();
            Console.WriteLine(filename + " has been read");
        }

        public void WriteCSV(string filename)
        {
            if (File.Exists(filename))
            {
                File.WriteAllText(filename, string.Empty);
            }
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(columnsWrite);
            var headerCells = columnsWrite.Split(';');
            foreach (var contact in contactList)
            {
                StringBuilder sb = new StringBuilder();
                foreach(var h in headerCells)
                {
                    sb.Append(mappingsWrite[h](contact));
                    sb.Append(";");
                }
                sb.Remove(sb.Length - 1, 1);
                sw.WriteLine(sb.ToString());
            }

            sw.Close();
            fs.Close();
            Console.WriteLine(filename + " has been written");
        }
    }
}
