using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContractRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalListTest()
        {
            appManager.Contact.RemoveFromList(1);
        }

        [Test]
        public void ContactRemovalCardDetailsTest()
        {
            appManager.Contact.RemoveFromCardDetails(1);
        }

        [Test]
        public void ContactRemovalCardEditTest()
        {
            appManager.Contact.RemoveFromCardEdit(1);
        }
    }
}
