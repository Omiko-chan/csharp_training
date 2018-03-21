using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            manager.navigationHelper.OpenMainPage();
            OpenRegistrationForm();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            FillRegistrationForm(account);
            SubmitRegistration();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();

        }

        public void Login(AccountData loginAccount)
        {
            manager.navigationHelper.OpenMainPage();
            driver.FindElement(By.Name("username")).SendKeys(loginAccount.Name);
            driver.FindElement(By.CssSelector("input.btn")).Click();
            driver.FindElement(By.Name("password")).SendKeys(loginAccount.Password);
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        public void DeleteAccount(int id)
        {
            manager.navigationHelper.OpenUserManagement();
            driver.FindElement(By.XPath("//a[@href='manage_user_edit_page.php?user_id=" + id + "']")).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//input[@value='Удалить учетную запись']")).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//input[@value='Удалить учетную запись']")).Click();
           
        }

        public void Logout()
        {
            manager.navigationHelper.OpenLogoutPage();

        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;

        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);

        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector("button.btn")).Click();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }
    }
}
