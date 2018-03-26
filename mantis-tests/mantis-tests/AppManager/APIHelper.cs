using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id.ToString();
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetAllProject(AccountData account)
        {

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData>  projects = new List<ProjectData>();
            Mantis.ProjectData[] projectArray = client.mc_projects_get_user_accessible(account.Name, account.Password);
            projectArray.ToList();
            foreach (Mantis.ProjectData prj in projectArray)
            {
                projects.Add(new ProjectData() { Name = prj.name, Id = int.Parse(prj.id) });
            }            
            return new List<ProjectData>(projects);
        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);

        }

    }
}
