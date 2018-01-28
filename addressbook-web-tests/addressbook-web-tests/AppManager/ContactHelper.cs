using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        //CreateContact
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.BirthdayDay);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.BirthdayMonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.BirthdayYear);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

    }
}
