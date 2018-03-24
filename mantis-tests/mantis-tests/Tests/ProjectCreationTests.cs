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
    public class ProjectCreationTests : AuthTestBase
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
            //AccountData account = new AccountData()
            //{
            //    Name = "administrator",
            //    Password = "root",
            //};
            ProjectData project = new ProjectData()
            {
                Name = "Newtestproject"
            };
            //appManager.Registration.Login(account);
            appManager.navigationHelper.OpenProjectManagement();
            List<ProjectData> Projects = ProjectData.GetAll();
            foreach (ProjectData prj in Projects)
            {
                if (prj.Name == project.Name)
                {
                    int id = prj.Id;
                    appManager.Project.Remove(id);
                    break;
                }
            }

            List<ProjectData> oldProjects = ProjectData.GetAll();

            appManager.Project.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count + 1, ProjectData.GetAll().Count);
            List<ProjectData> newProject = ProjectData.GetAll();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }

        [Test]
        public void TestProjectCreationDuplicateName()
        {
            //AccountData account = new AccountData()
            //{
            //    Name = "administrator",
            //    Password = "root",
            //};
            ProjectData project = new ProjectData()
            {
                Name = "Newtestproject"
            };
            bool existPrj = false;
            //appManager.Registration.Login(account);
            appManager.navigationHelper.OpenProjectManagement();
            List<ProjectData> Projects = ProjectData.GetAll();
            
            foreach (ProjectData prj in Projects)
            {
                if (prj.Name == project.Name)
                {
                    int id = prj.Id;
                    existPrj = true;
                    break;
                }
            }
            if(!existPrj)
            { 
                appManager.Project.CreateNewProject(project);
            }
            List<ProjectData> oldProjects = ProjectData.GetAll();

            appManager.Project.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count, ProjectData.GetAll().Count);
            List<ProjectData> newProject = ProjectData.GetAll();
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);

            Assert.IsFalse(!appManager.Project.CreateFail());
        }
      
        [OneTimeTearDown]
        public void restoreConfig()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
            appManager.Ftp.RestoreBackupFile(@"/config_inc.php");

        }
    }
}
