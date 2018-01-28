using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("NameTestGroup")
            {
                Header = "HeaderTestGroup",
                Footer = "FooterTestGroup"
            };
            appManager.Group.Create(group);


        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };
            appManager.Group.Create(group);
        }
    }
}
