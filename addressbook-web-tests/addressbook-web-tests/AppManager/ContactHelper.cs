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
            InitContactCardFromList(p);
            Modify(newData);
            return this;
        }

        public ContactHelper ModifyFromDetails(int p, ContactData newData)
        {
            BrowseContactDetail(p);
            InitContactCardFromDetail();
            Modify(newData);
            return this;
        }

        public ContactHelper RemoveFromList(int p)
        {
            SelectContact(p);
            RemoveContactList();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromList(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContactList();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromCardEdit(int p)
        {
            InitContactCardFromList(p);
            RemoveContactCard();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromCardEdit(ContactData contact)
        {
            InitContactCardFromList(contact.Id);
            RemoveContactCard();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveFromCardDetails(int p)
        {
            BrowseContactDetail(p);
            InitContactCardFromDetail();
            RemoveContactCard();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper RemoveFromCardDetails(ContactData contact)
        {
            BrowseContactDetail(contact.Id);
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

        public void PreconditionsContact(ContactData contact)
        {
            if (!IsContactIn())
            {
                Create(contact);
            }
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
            Type(By.Name("work"), contact.PhoneWork);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public ContactHelper RemoveContactList()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        
        private ContactHelper InitContactCardFromList(int index)
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }

        private ContactHelper InitContactCardFromList(string id)
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']//img[@alt='Edit']")).Click();
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
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        private ContactHelper BrowseContactDetail(string id)

        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//a[@href='view.php?id="+id+"']//img[@alt='Details']")).Click();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper RemoveContactCard()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public bool IsContactIn()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.CssSelector("td:nth-child(2)")).Text, 
                                                     element.FindElement(By.CssSelector("td:nth-child(3)")).Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                    
                }
            }

            return new List<ContactData>(contactCache);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
        }

        public ContactData GetContactInformationEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactCardFromList(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename= driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string phoneHome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string phoneMobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string phoneWork = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phoneFax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string phoneHome2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            if (bday== "0")
            {
                bday = "";
            }
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            if (bmonth == "-")
            {
                bmonth = "";
            }
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            if (aday == "0")
            {
                aday = "";
            }
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            if (amonth== "-")
            {
                amonth = "";
            }
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string adress2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");



            return new ContactData(lastName, firstName)
            {
                Middlename= middlename,
                NickName=nickname,
                Company=company,
                Title=title,
                Address = address,
                PhoneHome = phoneHome,
                PhoneMobile = phoneMobile,
                PhoneWork = phoneWork,
                PhoneHome2=phoneHome2,
                PhoneFax=phoneFax,
                Homepage=homepage,
                BirthdayDay=bday,
                BirthdayMonth=bmonth,
                BirthdayYear=byear,
                AnniversaryDay=aday,
                AnniversaryMonth=amonth,
                AnniversaryYear=ayear,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Address2=adress2,
                Notes=notes
            };
        }
        public ContactData GetContactInformationDetailsForm(int p)
        {
            manager.Navigator.GoToHomePage();
            BrowseContactDetail(p);
            string firstName = "";
            string lastName = "";
            string allContactInfo = driver.FindElement(By.CssSelector("div#content")).Text;

            return new ContactData(firstName, lastName)
            {
                AllContactInfo = allContactInfo
            };
        }
    }
}
