using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            appManager.Group.Remove(1);
        }
    }
}
