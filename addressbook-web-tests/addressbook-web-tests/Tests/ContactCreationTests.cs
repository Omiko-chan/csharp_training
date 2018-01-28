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
            appManager.Navigator.GoToHomePage();
            appManager.Auth.Login(new AccountData("admin", "secret"));
            appManager.Contact.InitContactCreation();
            ContactData contact = new ContactData("Usernametest", "Usersurnametest");
            contact.BirthdayDay = "11";
            contact.BirthdayMonth = "May";
            contact.BirthdayYear = "1987";
            appManager.Contact.FillContactForm(contact);
            appManager.Contact.SubmitContactCreation();
            appManager.Contact.ReturnToHomePage();
            appManager.Auth.Logout();
        }
    }
}
