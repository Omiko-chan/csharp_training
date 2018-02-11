using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData groupData = new GroupData("NameTestGroup")
            {
                Header = "HeaderTestGroup",
                Footer = "FooterTestGroup"
            };

            List<GroupData> oldGroups = appManager.Group.GetGroupList();

            appManager.Group.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.Group.GetGroupList();

            appManager.Group.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.Group.GetGroupList();

            appManager.Group.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
