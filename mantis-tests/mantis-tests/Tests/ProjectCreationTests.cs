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
    public class ProjectCreationTests : TestBase
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
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };
            ProjectData project = new ProjectData()
            {
                Name = "Newtestproject"
            };
            appManager.Registration.Login(account);
            appManager.navigationHelper.OpenProjectManagement();
            List<ProjectData> Projects = ProjectData.GetAll();
            foreach (ProjectData prj in Projects)
            {
                if (prj.Name == project.Name)
                {
                    int id = prj.Id;
                    appManager.Project.DeleteProject(id);
                }
            }

            List<ProjectData> oldProjects = ProjectData.GetAll();

          //  appManager.Project.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count + 1, ProjectData.GetAll().Count);
            List<ProjectData> newProject = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }

        [Test]
        public void Test()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root",
            };
            appManager.Registration.Login(account);
            appManager.navigationHelper.OpenProjectManagement();

            appManager.Project.CreateNewProject();
        }

        [OneTimeTearDown]
        public void restoreConfig()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            appManager.Ftp.RestoreBackupFile(@"/config_inc.php");

        }
    }
}
