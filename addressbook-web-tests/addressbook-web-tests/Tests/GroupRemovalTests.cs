using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
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
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            appManager.Group.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
