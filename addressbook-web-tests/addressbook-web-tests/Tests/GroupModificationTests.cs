using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            appManager.Group.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = GroupData.GetAll();
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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            appManager.Group.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = GroupData.GetAll();
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
