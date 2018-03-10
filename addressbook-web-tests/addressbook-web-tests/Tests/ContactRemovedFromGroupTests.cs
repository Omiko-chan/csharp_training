using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactRemovedFromGroupTests : AuthTestBase
    {
        public string id = null;
        [SetUp]
        public void PreconditionsContactRemove()
        {
            if (appManager.Group.FindGroupWithContact().Item1 == false)
            {
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> oldList = group.GetContacts();
                ContactData contact = ContactData.GetAll().Except(oldList).First();
                appManager.Contact.AddContactToGroup(contact, group);
                id = group.Id;
            }
            else
            {
                id = appManager.Group.FindGroupWithContact().Item2;
            }
        }

        [Test]
        public void ContactRemovalFromGroupTest()
        {
            List<GroupData> groups = GroupData.GetAll();

            GroupData group = groups.Where(p => p.Id == id).Single();
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];
            appManager.Contact.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
