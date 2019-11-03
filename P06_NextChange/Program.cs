using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_NextChange
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = new Contacts();
            contacts.ReadCSV("ZHAW-Namelist.csv");

            contacts.WriteCSV("ZHAW-Namelist-copy.csv");
            Console.ReadKey();
        }
    }
}
