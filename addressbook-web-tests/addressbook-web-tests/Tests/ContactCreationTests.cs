using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.Contact.InitContactCreation();
            ContactData contactData = new ContactData("Usernametest", "Usersurnametest")
            {
                BirthdayDay = "11",
                BirthdayMonth = "May",
                BirthdayYear = "1987"
            };
            appManager.Contact.Create(contactData);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            appManager.Contact.InitContactCreation();
            ContactData contactData = new ContactData("", "")
            {
                BirthdayMonth = "-"
            };
            appManager.Contact.Create(contactData);
        }

    }
}
