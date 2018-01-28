using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin","secret"));
            appManager.Navigator.GoToGroupsPage();
            appManager.Group.SelectGroup(1);
            appManager.Group.RemoveGroup();
            appManager.Group.ReturnToGroupsPage();
            appManager.Auth.Logout();
        }
    }
}
