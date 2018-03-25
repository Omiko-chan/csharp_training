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
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
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
            //выбор данных из БД
            //List<AccountData> accounts = AccountData.GetAll();
            //foreach (AccountData acc in accounts)
            //{
            //    if (acc.Name == account.Name)
            //    {
            //        AccountData loginAccount = new AccountData()
            //        {
            //            Name = "administrator",
            //            Password = "root"
            //        };
            //        int id = acc.Id;
            //        appManager.Auth.Login(loginAccount);
            //        appManager.Registration.Remove(id);
            //        appManager.Auth.Logout();

            //    }
            //}
            //выбор данных через облегченный браузер
            List<AccountData> accounts = appManager.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                appManager.Admin.DeleteAccount(existingAccount);
            }

            appManager.James.Delete(account);
            appManager.James.Add(account);
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
