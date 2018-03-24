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
    public class ProjectRemovalTests : AuthTestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            appManager.Ftp.BackupFile(@"/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            { appManager.Ftp.Upload(@"/config_inc.php", localFile); }
        }
        [SetUp]
        public void PreconditionsRemoval()
        {
            ProjectData projectData = new ProjectData()
            {
                Name="Preconditionsproject"
            };
            appManager.Project.PreconditionsProject(projectData);
        }
        [Test]
        public void ProjectRemovalTest()
        {
            //AccountData account = new AccountData()
            //{
            //    Name = "administrator",
            //    Password = "root",
            //};
            //appManager.Registration.Login(account);
            appManager.navigationHelper.OpenProjectManagement();

            List<ProjectData> oldProjects = ProjectData.GetAll();
            ProjectData toBeRemoved = oldProjects[0];

            appManager.Project.Remove(toBeRemoved.Id);

            Assert.AreEqual(oldProjects.Count - 1, ProjectData.GetAll().Count);

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
            foreach (ProjectData group in newProjects)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }


    }
}
