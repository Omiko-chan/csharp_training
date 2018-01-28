using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new ApplicationManager();
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));

        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Auth.Logout();
            appManager.Stop();
        }
    }
}
