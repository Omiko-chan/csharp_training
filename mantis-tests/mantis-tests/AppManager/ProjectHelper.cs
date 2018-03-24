using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) {  }

        public void Remove(int id)
        {
            manager.navigationHelper.OpenProjectManagement();
            driver.FindElement(By.XPath("//a[@href='manage_proj_edit_page.php?project_id=" + id + "']")).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(20);
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void CreateNewProject(ProjectData project)
        {
            manager.navigationHelper.OpenProjectManagement();
            driver.FindElement(By.XPath("//fieldset[input[@name='manage_proj_create_page_token']]")).Click();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }

        public void PreconditionsProject(ProjectData projectData)
        {
            if (!IsProjectIn())
            {
                CreateNewProject(projectData);
            }
           
        }

        public bool IsProjectIn()
        {
            return ProjectData.GetAll().Count > 0;


        }

        public bool CreateFail()
        {
            return IsElementPresent(By.XPath("//p[contains(text(),'APPLICATION ERROR #701')]"));
        }
    }
}
