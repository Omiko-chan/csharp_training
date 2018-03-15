using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contactData = new ContactData() { Firstname = "Firstnametest", Lastname = "Lastnametest" };
            app.Contacts.Add(contactData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            System.Console.Out.WriteLine(oldContacts[0]);
        }


    }
}
