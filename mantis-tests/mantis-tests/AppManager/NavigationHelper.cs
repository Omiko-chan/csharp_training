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

        public void OpenProjectManagement()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            GoToManagement();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(40);
            GoToProjectManagement();
        }

        public void GoToProjectManagement()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.12.0/manage_proj_page.php']")).Click();
        }

        public void GoToManagement()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.12.0/manage_overview_page.php']")).Click();
        }

        public void OpenLogoutPage()
        {
            driver.Url = baseURL + "/logout_page.php";
        }
    }
}
