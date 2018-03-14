using System;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            List<GroupData> groupData = new List<GroupData>();
            string dir=TestContext.CurrentContext.TestDirectory;
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"dir\groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void TestGroupCreation(GroupData groupData)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            //GroupData newGroup = new GroupData()
            //{
            //    Name = "white"
            //};
            app.Groups.Add(groupData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        //[Test]
        //public void TestGroupGreationLevelTwo()
        //{
        //    {
        //        if (!IsGroupIn())
        //        {
        //            Create(group);
        //        }
        //    }
        //    List<GroupData> oldGroups = app.Groups.GetGroupList();
        //    GroupData newGroup = new GroupData()
        //    {
        //        Name = "white"
        //    };

        //}
    }
}
