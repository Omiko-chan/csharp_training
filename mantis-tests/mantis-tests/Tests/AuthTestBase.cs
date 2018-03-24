﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [OneTimeSetUp]
        public void SetupLogin()
        {
            appManager.Auth.Login(new AccountData()
            {
                Name="administrator",
                Password="root"
            });

        }
        //[TearDown]
        //public void LogoutApplicationManager()
        //{
        //    appManager.Auth.Logout();
        //}
    }
}