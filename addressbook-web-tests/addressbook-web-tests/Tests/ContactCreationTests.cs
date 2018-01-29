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
            appManager.Contact.InitContactCreation();
            ContactData contact = new ContactData("Usernametest", "Usersurnametest")
            {
                BirthdayDay = "11",
                BirthdayMonth = "May",
                BirthdayYear = "1987"
            };
            appManager.Contact.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            appManager.Contact.InitContactCreation();
            ContactData contact = new ContactData("", "")
            {
                BirthdayMonth = "-"
            };
            appManager.Contact.Create(contact);
        }

    }
}
