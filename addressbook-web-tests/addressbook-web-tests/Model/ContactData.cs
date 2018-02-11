using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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

        public string Firstname { get; set; }
        public string Lastname { get; set; }        
        public string Middlename { get; set; }     
        public string NickName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public string TelephoneWork { get; set; }
        public string TelephoneFax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public string AnniversaryYear { get; set; }
        public string NewGroup { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }        
        public string Id { get; set; }
    }
    

}
