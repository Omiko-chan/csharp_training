using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contactData = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contactData.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    BirthdayDay = "11",
                    BirthdayMonth = "May",
                    BirthdayYear = "1987"
                });
            }
            return contactData;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contactData)
        {

            List<ContactData> oldContact = appManager.Contact.GetContactList();
            appManager.Contact.Create(contactData);

            Assert.AreEqual(oldContact.Count + 1, appManager.Contact.GetContactList().Count);

            List<ContactData> newContact = appManager.Contact.GetContactList();
            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
