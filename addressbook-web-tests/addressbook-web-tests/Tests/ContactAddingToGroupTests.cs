using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        public string id = null;
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
            if (appManager.Group.FindGroupWithoutContact().Item1 == false)
            {
                appManager.Contact.Create(contactData);
            }
            else
            {
                id = appManager.Group.FindGroupWithoutContact().Item2;
            }
        }

        [Test]
        public void ContactAddingToGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();

            GroupData group = groups.Where(p =>p.Id==id).Single();
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            appManager.Contact.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
