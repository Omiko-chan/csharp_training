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
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void Login(AccountData loginAccount)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(loginAccount))
                {
                    return;
                }
                Logout();
            }
            manager.navigationHelper.OpenMainPage();
            driver.FindElement(By.Name("username")).SendKeys(loginAccount.Name);
            driver.FindElement(By.CssSelector("input.btn")).Click();
            driver.FindElement(By.Name("password")).SendKeys(loginAccount.Password);
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                manager.navigationHelper.OpenLogoutPage();
            }

        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Name;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;
        }
    }
}
