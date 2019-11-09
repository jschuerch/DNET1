using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace P07_NextChange
{
    public enum Locale { EN, DE };

    public class Contact : IComparable<Contact>
    {
        public string Title;
        public string FirstName;
        public string LastName;
        public string Company;
        public string Department;
        public string JobTitle;
        public string BusinessStreet;
        public string BusinessCity;
        public string BusinessPostalCode;
        public string BusinessCountry;
        public string HomeStreet;
        public string HomeCity;
        public string HomeState;
        public string HomePostalCode;
        public string HomeCountry;
        public string BusinessFax;
        public string BusinessPhone;
        public string HomePhone;
        public string MobilePhone;
        public string Birthday;
        public string Categories;
        public string EmailAddress;
        public string EmailDisplayName;
        public string Email2Address;
        public string Email2DisplayName;
        public string Gender;
        public string Initials;
        public string Language;
        public string Notes;
        public string OfficeLocation;
        public string POBox;
        public string Priority;
        public string Private;
        public string Profession;
        public string WebPage;
        public string Nickname;


        public Contact()
        {

        }

        public IEnumerator<String> GetEnumerator()
        {
            FieldInfo[] fi = this.GetType().GetFields();
            foreach(FieldInfo f in fi)
            {
                yield return (string) f.GetValue(this);
            }
        }

        public Contact(string FirstName, string LastName,
                       string Company,
                       string Department, string JobTitle,
                       string BusinessPhone,
                       string EmailAddress,
                       string Initials, string OfficeLocation, string Profession
          ) : this()
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Company = Company;
            this.Department = Department;
            this.JobTitle = JobTitle;
            this.BusinessPhone = BusinessPhone;
            this.EmailAddress = EmailAddress;
            this.Initials = Initials;
            this.OfficeLocation = OfficeLocation;
            this.Profession = Profession;
        }

        public int CompareTo(Contact obj)
        {
            if (obj == null) return 1;

            var comp = LastName.CompareTo(obj.LastName);
            if (comp == 0)
                comp = FirstName.CompareTo(obj.FirstName);

            return comp;
        }


        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public void FillPersonAddressFromWeb()
        {
            WebRequest rq = WebRequest.Create("https://www.zhaw.ch/de/ueber-uns/person/" + Initials + "/");
            WebResponse rsp = rq.GetResponse();

            StreamReader r = new StreamReader(rsp.GetResponseStream());
            var file = r.ReadToEnd();

            /*Regex pattern = new Regex(
                "<span class=\"contact-address\">(\\n|\\s)*<span>(?<Street>.*)</span><br>(\\n|\\s)*<span>(?<PLZ>\\d+)</span>(\\s)*<span>(?<City>.*)</span>(\\n|\\s)*</span>"
                , RegexOptions.Singleline);*/

             Regex pattern = new Regex(
                 "<span itemprop=\"streetAddress\">(?<Street>[A-Za-z 0-9]*)</span><br>(\\n|\\s)*<span itemprop=\"postalCode\">(?<PLZ>[\\d|\\s]*)</span>(\\n|\\s)*<span itemprop=\"addressLocality\">(?<City>[A-Za-z 0-9]*)</span>"
                 , RegexOptions.Singleline);

            Match match = pattern.Match(file);
            HomeStreet = match.Groups["Street"].Value.Trim();
            HomePostalCode = match.Groups["PLZ"].Value.Trim();
            HomeCity = match.Groups["City"].Value.Trim();

            /*Console.WriteLine(Initials);
            Console.WriteLine(HomeStreet);
            Console.WriteLine(HomePostalCode + " " + HomeCity);*/
        }
    }
}
