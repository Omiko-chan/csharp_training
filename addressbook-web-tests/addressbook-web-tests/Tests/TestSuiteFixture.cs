using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void LogoutApplicationManager()
        {
            ApplicationManager.GetInstance().Auth.Logout();
//            ApplicationManager.GetInstance().Stop();

        }
    }
}
