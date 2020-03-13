using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFrameWork_ExtentReports.Login
{
    [TestFixture]
 public class LoginPage
    {
        IWebDriver driver;
        ExtentReports extent = null;
        ExtentHtmlReporter extenthtmlreportes = null;
        ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentReports_start()
        {
            extent = new ExtentReports();
            var extenthtmlreportes = new ExtentHtmlReporter(@"D:\Sample_BDD_Framework\NunitFrameWork_ExtentReports\NunitFrameWork_ExtentReports\Extent_Reportes\LoginPage.html");
            extent.AttachReporter(extenthtmlreportes);
        }

        [OneTimeTearDown]
        public void ExtentReports_close()
        {
            extent.Flush();
        }

       [Test]
        public void Login_Page()
        {
          
            try
            {
               test= extent.CreateTest("Login_Page").Info("Test case is started");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Browser Lanched");
                driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
                driver.FindElement(By.XPath("//*[@id='txtUsername']")).SendKeys("Admin");
                driver.FindElement(By.XPath("//*[@id='txtPassword']")).SendKeys("admin123");
                driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();
                test.Log(Status.Pass, "Test case is passed");
                IWebElement result = driver.FindElement(By.XPath("//*[@id='welcome']"));
                String strmsg = result.Text;
                Assert.AreEqual(strmsg, "Welcome Admin");
                driver.Quit();
                test.Log(Status.Pass, "Test case is sucessfully completed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [Test]
        public void Login_Page2()
        {

            try
            {
                test = extent.CreateTest("Login_Page2").Info("Test case is started");
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Browser Lanched");
                driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
                driver.FindElement(By.XPath("//*[@id='txtUsername']")).SendKeys("Admin");
                driver.FindElement(By.XPath("//*[@id='txtPassword']")).SendKeys("admin123");
                driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();
                test.Log(Status.Pass, "Test case is passed");
                IWebElement result = driver.FindElement(By.XPath("//*[@id='wel']"));
                String strmsg = result.Text;
                Assert.AreEqual(strmsg, "Welcome Admin");
                driver.Quit();
                test.Log(Status.Pass, "Test case is sucessfully completed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw;
            }
            finally
            {
                //if (driver != null)
                //{
                //    driver.Quit();
                //}
            }
        }
    }
}

