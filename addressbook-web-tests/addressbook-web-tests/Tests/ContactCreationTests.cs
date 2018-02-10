using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Contact.InitContactCreation();
            ContactData contactData = new ContactData("Usersurnametest", "Usernametest" )
            {
                BirthdayDay = "11",
                BirthdayMonth = "May",
                BirthdayYear = "1987"
            };

            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.Create(contactData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            appManager.Contact.InitContactCreation();
            ContactData contactData = new ContactData("", "")
            {
                BirthdayMonth = "-"
            };
            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.Create(contactData);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

    }
}
