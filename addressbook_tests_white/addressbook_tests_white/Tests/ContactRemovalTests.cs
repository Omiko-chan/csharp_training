using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white.Tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [SetUp]
        public void PreconditionsContactRemoval()
        {
            ContactData contactData = new ContactData()
            {
                Firstname = "Firstnametest",
                Lastname= "Lastnametest"
            };
            app.Contacts.PreconditionsContact(contactData);
        }

        [Test]
        public void TestContactRemoval()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactList().Count);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
