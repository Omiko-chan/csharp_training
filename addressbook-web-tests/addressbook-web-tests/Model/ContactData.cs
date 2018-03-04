using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests

{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allContactInfo;
        private string fio;
        private string allInfoMain;
        private string phones;
        private string webInfo;
        private string dateInfo;

        public ContactData() { }

        public ContactData(string lastname, string firstname)
        {
            Lastname = lastname;
            Firstname = firstname;

        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Lastname+Firstname).GetHashCode();
        }

        public override string ToString()
        {
            return "lName=" + Lastname + " fName=" + Firstname; 
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Lastname + Firstname).CompareTo(other.Lastname + other.Firstname);
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";           
        }
        private string CleanUpFIO(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name.Trim()+" ";
        }
        private int CalculateAge(string day, string month, string year)
        {
            Dictionary<string, int> months = new Dictionary<string, int>()
            {
                {"january", 1},{"february", 2},{"march", 3},{"april", 4},{"may", 5},{"june", 6},{"july", 7},{"august", 8},{"september", 9}
                ,{"october", 10},{"november", 11},{"december", 12}
            };
            int nmonth = months[month];
            int YearsPassed = DateTime.Now.Year - Int32.Parse(year);
            if (DateTime.Now.Month < nmonth || (DateTime.Now.Month == nmonth && DateTime.Now.Day < Int32.Parse(day)))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }

        private string CleanUpDate(string day, string month, string year)
        {
            string value = "";
            if (day != null && day != "")
            {
                value = day + ". ";
            }
            if (month != null && month != "")
            {
                value = value +( month.Substring(0,1).ToUpper()+month.Remove(0,1)) + " ";
            }
            if (year != null && year != "")
            {
                int d = CalculateAge(day, month.ToLower(), year);
                value = value + year + System.String.Format(" ({0})",d);
            }
            return value;
        }
        private string CleanUpValue(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            return value.Trim() + "\r\n";
        }

        [Column(Name ="id"), NotNull, PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }
        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }
        [Column(Name = "middlename"), NotNull]
        public string Middlename { get; set; }
        [Column(Name = "nickname"), NotNull]
        public string NickName { get; set; }
        [Column(Name = "title"), NotNull]
        public string Title { get; set; }
        [Column(Name = "company"), NotNull]
        public string Company { get; set; }
        [Column(Name = "address"), NotNull]
        public string Address { get; set; }
        [Column(Name = "home"), NotNull]
        public string PhoneHome { get; set; }
        [Column(Name = "mobile"), NotNull]
        public string PhoneMobile { get; set; }
        [Column(Name = "work"), NotNull]
        public string PhoneWork { get; set; }
        [Column(Name = "fax"), NotNull]
        public string PhoneFax { get; set; }
        [Column(Name = "email"), NotNull]
        public string Email { get; set; }
        [Column(Name = "email2"), NotNull]
        public string Email2 { get; set; }
        [Column(Name = "email3"), NotNull]
        public string Email3 { get; set; }
        [Column(Name = "homepage"), NotNull]
        public string Homepage { get; set; }
        [Column(Name = "bday"), NotNull]
        public string BirthdayDay { get; set; }
        [Column(Name = "bmonth"), NotNull]
        public string BirthdayMonth { get; set; }
        [Column(Name = "byear"), NotNull]
        public string BirthdayYear { get; set; }
        [Column(Name = "aday"), NotNull]
        public string AnniversaryDay { get; set; }
        [Column(Name = "amonth"), NotNull]
        public string AnniversaryMonth { get; set; }
        [Column(Name = "ayear"), NotNull]
        public string AnniversaryYear { get; set; }
        public string NewGroup { get; set; }
        [Column(Name = "address2"), NotNull]
        public string Address2 { get; set; }
        [Column(Name = "phone2"), NotNull]
        public string PhoneHome2 { get; set; }
        [Column(Name = "notes"), NotNull]
        public string Notes { get; set; }
        [Column(Name = "deprecated"),NotNull]
        public DateTime Deprecated { get; set; }
        public string FIO
        {
            get
            {
                if (fio != null)
                {
                    return fio;
                }
                else
                {
                    string val = CleanUpFIO(Firstname)+ CleanUpFIO(Middlename) + CleanUpFIO(Lastname);
                    return CleanUpValue(val);
                }
            }
            set
            {
                fio = value;
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(PhoneHome) + CleanUpPhone(PhoneMobile) + CleanUpPhone(PhoneWork) + CleanUpPhone(PhoneHome2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpValue(Email) + CleanUpValue(Email2) + CleanUpValue(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllInfoMain
        {
            get
            {
                if (allInfoMain != null)
                {
                    return allInfoMain;
                }
                else
                {
                    return FIO + CleanUpValue(NickName) + CleanUpValue(Title) + CleanUpValue(Company) + CleanUpValue(Address);
                       
                }
            }
            set
            {
                allInfoMain = value;
            }
        }
        public string Phones
        {
            get
            {
                if (phones != null)
                {
                    return phones;
                }
                else
                {
                    string val = "";
                    if (PhoneHome != null && PhoneHome != "")
                    {
                        if (PhoneHome.Trim().Length == 0)
                        {
                            val = val + "H:" +  CleanUpValue(PhoneHome);
                        }
                        else
                        {
                            val = val + "H:" + " " + CleanUpValue(PhoneHome);
                        }                        
                    }
                    if (PhoneMobile != null && PhoneMobile != "")
                    {
                        if (PhoneMobile.Trim().Length == 0)
                        {
                            val = val + "M:" + CleanUpValue(PhoneMobile);
                        }
                        else
                        {
                            val = val + "M:" + " " + CleanUpValue(PhoneMobile);
                        }
                    }
                    if (PhoneWork != null && PhoneWork != "")
                    {
                        if (PhoneWork.Trim().Length==0)
                        {
                            val = val + "W:" + CleanUpValue(PhoneWork);
                        }
                        else
                        {
                            val = val + "W:" + " " + CleanUpValue(PhoneWork);
                        }
                    }
                    if (PhoneFax != null && PhoneFax != "")
                    {
                        if (PhoneFax.Trim().Length==0)
                        {
                            val = val + "F:" + CleanUpValue(PhoneFax);
                        }
                        else
                        {
                            val = val + "F:" + " " + CleanUpValue(PhoneFax);
                        }
                    }
                    return val;
                }
            }
            set
            {
                phones = value;
            }
        }
        public string WebInfo
        {
            get
            {
                if (webInfo != null)
                {
                    return webInfo;
                }
                else
                {
                    string val = CleanUpValue(Email) + CleanUpValue(Email2) + CleanUpValue(Email3);
                    if (Homepage != null && Homepage != "")
                    {
                        val = val + "Homepage:" + "\r\n" + CleanUpValue(Homepage);
                    }
                    return val;
                }
            }
            set
            {
                webInfo = value; 
            }
        }
        public string DateInfo
        {
            get
            {
                if (dateInfo != null)
                {
                    return dateInfo;
                }
                else
                {
                    string val = "";
                    string date = CleanUpDate(BirthdayDay, BirthdayMonth, BirthdayYear);
                    if (date != null && date != "")
                    {
                        val = "Birthday " + date + "\r\n";
                    }
                    date = CleanUpDate(AnniversaryDay, AnniversaryMonth, AnniversaryYear);
                    if (date != null && date != "")
                    {
                        val = val + "Anniversary " + date + "\r\n";
                    }
                    return val;
                }
            }
            set
            {
                dateInfo = value;
            }
        }

        public string AllContactInfo
        {
            get
            {
                if (allContactInfo != null)
                {
                    return allContactInfo;
                }
                else
                {
                    string val = AllInfoMain;
                    if (Phones != null && Phones != "")
                    {
                        val = val + "\r\n" + Phones;
                    }
                    if (WebInfo != null && WebInfo != "")
                    {
                        val = val + "\r\n" + WebInfo;
                    }
                    if (DateInfo != null && DateInfo != "")
                    {
                        val = val + "\r\n" + DateInfo;
                    }
                    if (CleanUpValue(Address2) != null && CleanUpValue(Address2) != "")
                    {
                        val = val + "\r\n" + CleanUpValue(Address2);
                    }
                    if (CleanUpValue(PhoneHome2) != null && CleanUpValue(PhoneHome2) != "")
                    {
                        val = val + "\r\n" + "P: " + CleanUpValue(PhoneHome2);
                    }
                    if (CleanUpValue(Notes) != null && CleanUpValue(Notes) != "")
                    {
                        val = val + "\r\n" + CleanUpValue(Notes);
                    }
                    return val.Trim();
                }
            }
          set
            {
                allContactInfo = value;
            }
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts /*where c.Deprecated == "00.00.0000 00:00:00" */ select c).ToList();
            }
        }


    }
}
