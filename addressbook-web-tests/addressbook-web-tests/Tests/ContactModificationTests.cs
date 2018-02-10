using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void PreconditionsContactModif()
        {
            ContactData contactData = new ContactData("Usersurname", "Username")
            {
                BirthdayDay = "22",
                BirthdayMonth = "October",
                BirthdayYear = "1990",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.PreconditionsContact(contactData);
        }
        
        [Test]
        public void ContactModificationFromListTest()
        {
            ContactData newData = new ContactData("Usersurnamemodif", "Usernamemodif")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };

            List<ContactData> oldContact = appManager.Contact.GetContactList();

            appManager.Contact.ModifyFromList(0, newData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void ContactModificationLastnameFromListTest()
        {
            ContactData newData = new ContactData("Usersurnameonlymodif", null)
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                TelephoneWork = null
            };

            List<ContactData> oldContact = appManager.Contact.GetContactList();

            appManager.Contact.ModifyFromList(0, newData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void ContactModificationFromDetailsTest()
        {
            ContactData newData = new ContactData("Usersurnamemodif","Usernamemodif" )
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };

            List<ContactData> oldContact = appManager.Contact.GetContactList();

            appManager.Contact.ModifyFromDetails(0, newData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
        [Test]
        public void ContactModificationLastnameFromDetailsTest()
        {
            ContactData newData = new ContactData("Usersurnameonlymodif", null)
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                TelephoneWork = null
            };

            List<ContactData> oldContact = appManager.Contact.GetContactList();

            appManager.Contact.ModifyFromDetails(0, newData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

    }
}
