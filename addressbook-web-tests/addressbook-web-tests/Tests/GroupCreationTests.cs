using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Group.InitGroupCreation();
            GroupData group = new GroupData("NameTestGroup")
            {
                Header = "HeaderTestGroup",
                Footer = "FooterTestGroup"
            };
            appManager.Group.FillGroupForm(group);
            appManager.Group.SubmitGroupCreation();
            appManager.Group.ReturnToGroupsPage();
            appManager.Auth.Logout();
        }
    }
}
