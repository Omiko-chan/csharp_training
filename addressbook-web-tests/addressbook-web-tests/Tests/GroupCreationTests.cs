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
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groupData = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groupData.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groupData;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groupData.Add(new GroupData(parts[0])
                {
                    Header=parts[1],
                    Footer=parts[2]
                });
            }
            return groupData;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));       
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            return JsonConvert.DeserializeObject<List<GroupData>> (File.ReadAllText(@"groups.json"));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groupData.Add(new GroupData()
                {
                    Name=range.Cells[i,1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });                                
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groupData;
        }

        [Test,TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData groupData)
        {
             List<GroupData> oldGroups = appManager.Group.GetGroupList();

            appManager.Group.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData groupData = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.Group.GetGroupList();

            appManager.Group.Create(groupData);

            Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupList().Count);

            List<GroupData> newGroups = appManager.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectiviti()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = appManager.Group.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;

            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }

    }
}
