﻿using System;
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

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper ModifyFromList(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactCardFromList(p);
            Modify(newData);
            return this;
        }

        public ContactHelper ModifyFromDetails(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            BrowseContactDetail(p);
            InitContactCardFromDetail();
            Modify(newData);
            return this;
        }

        public ContactHelper RemoveFromList(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            RemoveContactList();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromCardEdit(int p)
        {
            manager.Navigator.GoToHomePage();
            InitContactCardFromList(p);
            RemoveContactCard();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromCardDetails(int p)
        {
            manager.Navigator.GoToHomePage();
            BrowseContactDetail(p);
            InitContactCardFromDetail();
            RemoveContactCard();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private void Modify(ContactData newData)
        {
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
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

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            if (contact.BirthdayDay != null)
            {
                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.BirthdayDay);
            }
            if (contact.BirthdayMonth != null)
            {
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.BirthdayMonth);
            }
            Type(By.Name("byear"), contact.BirthdayYear);
            Type(By.Name("work"), contact.TelephoneWork);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContactList()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        
        private ContactHelper InitContactCardFromList(int index)
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper InitContactCardFromDetail()
        {
            driver.FindElement(By.Name("modifiy")).Click(); 
            return this;
        }

        private ContactHelper BrowseContactDetail(int index)

        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper RemoveContactCard()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

    }
}