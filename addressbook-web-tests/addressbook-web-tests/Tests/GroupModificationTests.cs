using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [SetUp]
        public void PreconditionsGroupModification()
        {
            GroupData groupData = new GroupData("NameGroup")
            {
                Header = "HeaderGroup",
                Footer = "FooterGroup"
            };
            appManager.Group.PreconditionsGroup(groupData);
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NameModifGroup")
            {
                Header = "HeaderModifGroup",
                Footer = "FooterModifGroup"
            };
            List<GroupData> oldGroups = appManager.Group.GetGroupList();
            GroupData oldData = oldGroups[0];
            appManager.Group.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups[0].Name=newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }

        [Test]
        public void GroupModificationNameTest()
        {
            GroupData newData = new GroupData("NameonlyModifGroup")
            {
                Header = null,
                Footer = null
            };
            List<GroupData> oldGroups = appManager.Group.GetGroupList();
            GroupData oldData = oldGroups[0];
            appManager.Group.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
