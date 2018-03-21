using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenMainPage()
        {
            if (driver.Url == baseURL + "/login_page.php")
            {
                return;
            }
            driver.Url = baseURL + "/login_page.php";
        }

        public void OpenUserManagement()
        {
            if (driver.Url == baseURL + "/manage_user_page.php")
            {
                return;
            }
            driver.Url = baseURL + "/manage_user_page.php";
        }

        public void OpenLogoutPage()
        {
            driver.Url = baseURL + "/logout_page.php";
        }
    }
}
