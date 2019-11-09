using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07_NextChange
{
    class Contacts
    {
        private ICollection<Contact> contactList { get; set; }
        private Dictionary<String, Action<Contact, string>> mappingsRead;

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
            mappingsRead.Add("Strasse", (contact, value) => contact.HomeStreet = value);
            mappingsRead.Add("PLZ", (contact, value) => contact.HomePostalCode = value);
            mappingsRead.Add("Ort", (contact, value) => contact.HomeCity = value);
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
            var cnt = 0;
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
                if (cnt < 20)
                {
                    c.FillPersonAddressFromWeb();
                    cnt++;
                }

                contactList.Add(c);
                Console.WriteLine("Imported: " + c.FirstName + " " + c.LastName);
            }

            sr.Close();
            Console.WriteLine(filename + " has been read");
        }

        public void WriteCSV(string filename)
        {
            ((List<Contact>) contactList).Sort();

            if (File.Exists(filename))
            {
                File.WriteAllText(filename, string.Empty);
            }
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            sw.BaseStream.Seek(0, SeekOrigin.End);

            var enumerator = Contact.GetFieldNames();
            StringBuilder sb = new StringBuilder();
            while (enumerator.MoveNext())
            {
                sb.Append(enumerator.Current);
                sb.Append(";");
            }
            sb.Remove(sb.Length - 1, 1);

            sw.WriteLine(sb.ToString());

            foreach (var contact in contactList)
            {
                sb = new StringBuilder();
                foreach(var field in contact)
                {
                    sb.Append(field);
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
