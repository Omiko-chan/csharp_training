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
        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contactData = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contactData.Add(new ContactData(parts[0],parts[1])
                {
                    BirthdayDay = parts[2],
                    BirthdayMonth = parts[3],
                    BirthdayYear = parts[4]
                });
            }
            return contactData;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contactData = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            List<ContactData> contactData = new List<ContactData>();
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contactData = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contactData.Add(new ContactData()
                {
                    Lastname = range.Cells[i, 1].Value,
                    Firstname = range.Cells[i, 2].Value,
                    BirthdayDay = range.Cells[i, 3].Value,
                    BirthdayMonth = range.Cells[i, 4].Value,
                    BirthdayYear = range.Cells[i, 5].Value,
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contactData;
        }

        [Test, TestCaseSource("ContactDataFromCsvFile")]
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
