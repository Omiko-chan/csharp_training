using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [SetUp]
        public void PreconditionsContactInform()
        {
            ContactData contactData = new ContactData("Usersurname", "Username")
            {
                BirthdayDay = "22",
                BirthdayMonth = "October",
                BirthdayYear = "1990",
                PhoneHome="+7 (567) 786-78-89",
                PhoneMobile="8 976-67-98",
                PhoneWork = "(495)256-56-65",
                PhoneHome2="8(495)675-23-21",
                Email="emailone@mail.ru",
                Email2="email.two@gmail.com",
                Email3="email-three@yandex.ru"
            };
            appManager.Contact.PreconditionsContact(contactData);
        }


        [Test]
        public void ContactInformationEditTest()
        {
            int index = 0;
            ContactData fromTable = appManager.Contact.GetContactInformationFromTable(index);
            ContactData fromForm = appManager.Contact.GetContactInformationEditForm(index);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones,fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactInformationDetailsTest()
        {
            int index = 1;
            ContactData fromForm = appManager.Contact.GetContactInformationEditForm(index);
            ContactData fromDetails = appManager.Contact.GetContactInformationDetailsForm(index);
            Assert.AreEqual(fromForm.AllContactInfo, fromDetails.AllContactInfo);
        }
    }
}
