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
                PhoneWork = "(495)256-56-65"
            };
            appManager.Contact.PreconditionsContact(contactData);
        }

        [Test]
        public void ContactRemovalListTest()
        {
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemoved = oldContact[0];

            appManager.Contact.RemoveFromList(toBeRemoved);

            Assert.AreEqual(oldContact.Count - 1, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void ContactRemovalCardDetailsTest()
        {
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemoved = oldContact[0];

            appManager.Contact.RemoveFromCardDetails(toBeRemoved);

            Assert.AreEqual(oldContact.Count - 1, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }

        [Test]
        public void ContactRemovalCardEditTest()
        {
            List<ContactData> oldContact = ContactData.GetAll();
            ContactData toBeRemoved = oldContact[0];

            appManager.Contact.RemoveFromCardEdit(toBeRemoved);

            Assert.AreEqual(oldContact.Count - 1, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = ContactData.GetAll();
            oldContact.RemoveAt(0);
            Assert.AreEqual(oldContact, newContact);
            foreach (ContactData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }


        //[Test]
        //public void TestDBConnectiviti()
        //{
        //    DateTime start = DateTime.Now;
        //    List<ContactData> fromUI = appManager.Contact.GetContactList();
        //    DateTime end = DateTime.Now;
        //    System.Console.Out.WriteLine(end.Subtract(start));

        //    start = DateTime.Now;

        //    List<ContactData> fromDB = ContactData.GetAll();
        //    end = DateTime.Now;
        //    System.Console.Out.WriteLine(end.Subtract(start));
        //    System.Console.Out.WriteLine(fromDB[1].Deprecated);

        //}


    }

}
