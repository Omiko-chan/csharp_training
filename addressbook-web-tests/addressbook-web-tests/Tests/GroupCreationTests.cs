using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            appManager.Group.Create(groupData);


        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData groupData = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            appManager.Group.Create(groupData);
        }
    }
}
