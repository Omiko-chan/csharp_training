﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [SetUp]
        public void PreconditionsGroupRemoval()
        {

            GroupData groupData = new GroupData()
            {
                Name = "white"
            };
            app.Groups.PreconditionsGroup(groupData);
        }

        [Test]
        public void TestGroupRemoval()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupList().Count);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
