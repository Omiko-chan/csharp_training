using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
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
            List<GroupData> oldGroups = appManager.Group.GetGroupList();
            
            appManager.Group.Remove(0);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
