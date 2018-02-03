﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
    
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NameModifGroup")
            {
                Header = "HeaderModifGroup",
                Footer = "FooterModifGroup"
            };
            appManager.Group.Modify(1, newData);
        }

        [Test]
        public void GroupModificationNameTest()
        {
            GroupData newData = new GroupData("NameonlyModifGroup")
            {
                Header = null,
                Footer = null
            };
            appManager.Group.Modify(1, newData);
        }


    }
}