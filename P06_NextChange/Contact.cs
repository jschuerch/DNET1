using System;
using System.Collections;
using System.Collections.Generic;

namespace P06_NextChange
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
            yield return Title;
            yield return FirstName;
            yield return LastName;
            yield return Company;
            yield return Department;
            yield return JobTitle;
            yield return BusinessStreet;
            yield return BusinessCity;
            yield return BusinessPostalCode;
            yield return BusinessCountry;
            yield return HomeStreet;
            yield return HomeCity;
            yield return HomeState;
            yield return HomePostalCode;
            yield return HomeCountry;
            yield return BusinessFax;
            yield return BusinessPhone;
            yield return HomePhone;
            yield return MobilePhone;
            yield return Birthday;
            yield return Categories;
            yield return EmailAddress;
            yield return EmailDisplayName;
            yield return Email2Address;
            yield return Email2DisplayName;
            yield return Gender;
            yield return Initials;
            yield return Language;
            yield return Notes;
            yield return OfficeLocation;
            yield return POBox;
            yield return Priority;
            yield return Private;
            yield return Profession;
            yield return WebPage;
            yield return Nickname;
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
    }
}
