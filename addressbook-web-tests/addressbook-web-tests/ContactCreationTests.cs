using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigationHelper.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitContactCreation();
            ContactData contact = new ContactData("Usernametest", "Usersurnametest");
            contact.BirthdayDay = "11";
            contact.BirthdayMonth = "May";
            contact.BirthdayYear = "1987";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}
