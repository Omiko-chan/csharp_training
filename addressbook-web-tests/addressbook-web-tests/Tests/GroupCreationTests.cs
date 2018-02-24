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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groupData = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groupData.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groupData;
        }

        [Test,TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData groupData)
        {
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
