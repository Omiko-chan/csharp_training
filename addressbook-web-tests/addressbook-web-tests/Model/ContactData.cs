using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _firstname;
        private string _lastname;
        private string _middlename = "";
        private string _nickname = "";
        private string _title = "";
        private string _company = "";
        private string _address = "";
        private string _telephoneHome = "";
        private string _telephoneMobile = "";
        private string _telephoneWork = "";
        private string _telephoneFax = "";
        private string _email = "";
        private string _email2 = "";
        private string _email3 = "";
        private string _homepage = "";
        private string _birthdayDay = "";
        private string _birthdayMonth = "";
        private string _birthdayYear = "";
        private string _anniversaryDay = "";
        private string _anniversaryMonth = "";
        private string _anniversaryYear = "";
        private string _new_group = "";
        private string _address2 = "";
        private string _phone2 = "";
        private string _notes = "";

        public ContactData(string lastname, string firstname)
        {
            _lastname = lastname;
            _firstname = firstname;

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

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
            }
        }
        public string NickName
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string TelephoneHome
        {
            get
            {
                return _telephoneHome;
            }
            set
            {
                _telephoneHome = value;
            }
        }
        public string TelephoneMobile
        {
            get
            {
                return _telephoneMobile;
            }
            set
            {
                _telephoneMobile = value;
            }
        }
        public string TelephoneWork
        {
            get
            {
                return _telephoneWork;
            }
            set
            {
                _telephoneWork = value;
            }
        }
        public string TelephoneFax
        {
            get
            {
                return _telephoneFax;
            }
            set
            {
                _telephoneFax = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Email2
        {
            get
            {
                return _email2;
            }
            set
            {
                _email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return _email3;
            }
            set
            {
                _email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return _homepage;
            }
            set
            {
                _homepage = value;
            }
        }
        public string BirthdayDay
        {
            get
            {
                return _birthdayDay;
            }
            set
            {
                _birthdayDay = value;
            }
        }
        public string BirthdayMonth
        {
            get
            {
                return _birthdayMonth;
            }
            set
            {
                _birthdayMonth = value;
            }
        }
        public string BirthdayYear
        {
            get
            {
                return _birthdayYear;
            }
            set
            {
                _birthdayYear = value;
            }
        }
        public string AnniversaryDay
        {
            get
            {
                return _anniversaryDay;
            }
            set
            {
                _anniversaryDay = value;
            }
        }
        public string AnniversaryMonth
        {
            get
            {
                return _anniversaryMonth;
            }
            set
            {
                _anniversaryMonth = value;
            }
        }
        public string AnniversaryYear
        {
            get
            {
                return _anniversaryYear;
            }
            set
            {
                _anniversaryYear = value;
            }
        }
        public string NewGroup
        {
            get
            {
                return _new_group;
            }
            set
            {
                _new_group = value;
            }
        }
        public string Address2
        {
            get
            {
                return _address2;
            }
            set
            {
                _address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return _phone2;
            }
            set
            {
                _phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }
    }
    

}
