using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContractRemovalTests : AuthTestBase
    {
        [SetUp]
        public void PreconditionsContactRemove()
        {
            ContactData contactData = new ContactData("Username", "Usersurname")
            {
                BirthdayDay = "22",
                BirthdayMonth = "October",
                BirthdayYear = "1990",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.PreconditionsContact(contactData);
        }

        [Test]
        public void ContactRemovalListTest()
        {
            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.RemoveFromList(0);
            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void ContactRemovalCardDetailsTest()
        {
            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.RemoveFromCardDetails(0);
            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }

        [Test]
        public void ContactRemovalCardEditTest()
        {
            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.RemoveFromCardEdit(0);
            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);

        }
    }
}
