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
                PhoneWork = "(495)256-56-65"
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
                PhoneWork = "(495)256-56-65"
            };

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];
            appManager.Contact.ModifyFromList(oldData, newData);

            Assert.AreEqual(oldContact.Count, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }

        [Test]
        public void ContactModificationLastnameFromListTest()
        {
            ContactData newData = new ContactData("Usersurnameonlymodif", null)
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                PhoneWork = null
            };

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];

            appManager.Contact.ModifyFromList(oldData, newData);

            Assert.AreEqual(oldContact.Count, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(oldData.Firstname, contact.Firstname);
                }
            }
        }

        [Test]
        public void ContactModificationFromDetailsTest()
        {
            ContactData newData = new ContactData("Usersurnamemodif","Usernamemodif" )
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                PhoneWork = "(495)256-56-65"
            };

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];

            appManager.Contact.ModifyFromDetails(oldData, newData);

            Assert.AreEqual(oldContact.Count, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Lastname = newData.Lastname;
            oldContact[0].Firstname = newData.Firstname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
        [Test]
        public void ContactModificationLastnameFromDetailsTest()
        {
            ContactData newData = new ContactData("Usersurnameonlymodif", null)
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                PhoneWork = null
            };

            List<ContactData> oldContact = ContactData.GetAll();
            ContactData oldData = oldContact[0];

            appManager.Contact.ModifyFromDetails(oldData, newData);

            Assert.AreEqual(oldContact.Count, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact[0].Lastname = newData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(oldData.Firstname, contact.Firstname);
                }
            }
        }

    }
}
