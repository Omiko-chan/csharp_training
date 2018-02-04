using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContractRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalListTest()
        {
            ContactData contact = new ContactData("Username", "Usersurname")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.RemoveFromList(1, contact);
        }

        [Test]
        public void ContactRemovalCardDetailsTest()
        {
            ContactData contact = new ContactData("Username", "Usersurname")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.RemoveFromCardDetails(1, contact);
        }

        [Test]
        public void ContactRemovalCardEditTest()
        {
            ContactData contact = new ContactData("Username", "Usersurname")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.RemoveFromCardEdit(1, contact);
        }
    }
}
