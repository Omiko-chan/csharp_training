using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
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
    
}
}
