using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>
    {
        private string _firstname;
        private string _lastname;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string telephoneHome = "";
        private string telephoneMobile = "";
        private string telephoneWork = "";
        private string telephoneFax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthdayDay = "";
        private string birthdayMonth = "";
        private string birthdayYear = "";
        private string anniversaryDay = "";
        private string anniversaryMonth = "";
        private string anniversaryYear = "";
        private string new_group = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";

        public ContactData(string firstname, string lastname)
        {
            this._firstname = firstname;
            this._lastname = lastname;
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
            return (Firstname+Lastname).GetHashCode();
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
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string TelephoneHome
        {
            get
            {
                return telephoneHome;
            }
            set
            {
                telephoneHome = value;
            }
        }
        public string TelephoneMobile
        {
            get
            {
                return telephoneMobile;
            }
            set
            {
                telephoneMobile = value;
            }
        }
        public string TelephoneWork
        {
            get
            {
                return telephoneWork;
            }
            set
            {
                telephoneWork = value;
            }
        }
        public string TelephoneFax
        {
            get
            {
                return telephoneFax;
            }
            set
            {
                telephoneFax = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string BirthdayDay
        {
            get
            {
                return birthdayDay;
            }
            set
            {
                birthdayDay = value;
            }
        }
        public string BirthdayMonth
        {
            get
            {
                return birthdayMonth;
            }
            set
            {
                birthdayMonth = value;
            }
        }
        public string BirthdayYear
        {
            get
            {
                return birthdayYear;
            }
            set
            {
                birthdayYear = value;
            }
        }
        public string AnniversaryDay
        {
            get
            {
                return anniversaryDay;
            }
            set
            {
                anniversaryDay = value;
            }
        }
        public string AnniversaryMonth
        {
            get
            {
                return anniversaryMonth;
            }
            set
            {
                anniversaryMonth = value;
            }
        }
        public string AnniversaryYear
        {
            get
            {
                return anniversaryYear;
            }
            set
            {
                anniversaryYear = value;
            }
        }
        public string NewGroup
        {
            get
            {
                return new_group;
            }
            set
            {
                new_group = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
    }
    

}
