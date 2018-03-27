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
        AccountData account = new AccountData()
        {
            Name = "administrator",
            Password = "root"
        };
        [SetUp]
        public void PreconditionsRemoval()
        {
            ProjectData projectData = new ProjectData()
            {
                Name="Preconditionsproject"
            };
            appManager.Project.PreconditionsProject(account,projectData);
        }
        [Test]
        public void TestProjectRemoval()
        {
            appManager.navigationHelper.OpenProjectManagement();

            List<ProjectData> oldProjects = appManager.Project.GetAllProject(account);
            ProjectData toBeRemoved = oldProjects[0];

            appManager.Project.Remove(toBeRemoved.Id);

            Assert.AreEqual(oldProjects.Count - 1, appManager.Project.GetAllProject(account).Count);

            List<ProjectData> newProjects = appManager.Project.GetAllProject(account);
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);
            foreach (ProjectData group in newProjects)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }


    }
}
