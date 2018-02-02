﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationFromListTest()
        {
            ContactData newData = new ContactData("Usernamemodif", "Usersurnamemodif")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.ModifyFromList(1, newData);
        }

        [Test]
        public void ContactModificationLastnameFromListTest()
        {
            ContactData newData = new ContactData(null, "Usersurnameonlymodif")
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                TelephoneWork = null
            };
            appManager.Contact.ModifyFromList(1, newData);
        }

        [Test]
        public void ContactModificationFromDetailsTest()
        {
            ContactData newData = new ContactData("Usernamemodif", "Usersurnamemodif")
            {
                BirthdayDay = "15",
                BirthdayMonth = "October",
                BirthdayYear = "1998",
                TelephoneWork = "(495)256-56-65"
            };
            appManager.Contact.ModifyFromDetails(1, newData);
        }
        [Test]
        public void ContactModificationLastnameFromDetailsTest()
        {
            ContactData newData = new ContactData(null, "Usersurnameonlymodif")
            {
                BirthdayDay = null,
                BirthdayMonth = null,
                BirthdayYear = null,
                TelephoneWork = null
            };
            appManager.Contact.ModifyFromDetails(1, newData);
        }

    }
}
