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
        [Test]
        public void TestProjectCreation()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Newtestproject"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            appManager.navigationHelper.OpenProjectManagement();
            List<ProjectData> Projects = appManager.Project.GetAllProject(account);
            foreach (ProjectData prj in Projects)
            {
                if (prj.Name == project.Name)
                {
                    int id = prj.Id;
                    appManager.Project.Remove(id);
                    break;
                }
            }
            
            List<ProjectData> oldProjects = appManager.Project.GetAllProject(account);

            appManager.Project.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count + 1, appManager.Project.GetAllProject(account).Count);
            List<ProjectData> newProject = appManager.Project.GetAllProject(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProject.Sort();
            Assert.AreEqual(oldProjects, newProject);
        }

        [Test]
        public void TestProjectCreationDuplicateName()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Newtestproject"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            bool existPrj = false;
            appManager.navigationHelper.OpenProjectManagement();
            List<ProjectData> Projects = appManager.Project.GetAllProject(account);
            
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
            List<ProjectData> oldProjects = appManager.Project.GetAllProject(account);

            appManager.Project.CreateNewProject(project);

            Assert.AreEqual(oldProjects.Count, appManager.Project.GetAllProject(account).Count);
            List<ProjectData> newProject = appManager.Project.GetAllProject(account);
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
