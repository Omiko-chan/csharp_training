﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get;  set; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get;  set; }
        public NavigationHelper navigationHelper { get; set; }
        public ProjectHelper Project { get; set; }
        public LoginHelper loginHelper;
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; private set; }

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox ESR\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/mantisbt-2.12.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            Project = new ProjectHelper(this);
            loginHelper = new LoginHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static  ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }


    }
}
