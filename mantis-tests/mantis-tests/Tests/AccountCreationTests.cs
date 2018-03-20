using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            appManager.Ftp.BackupFile(@"/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php",FileMode.Open))
            { appManager.Ftp.Upload(@"/config_inc.php", localFile); }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name="testuser",
                Password="password",
                Email= "testuser@localhost.localdomain"
            };
            appManager.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            appManager.Ftp.RestoreBackupFile(@"/config_inc.php");

        }
    }
}
