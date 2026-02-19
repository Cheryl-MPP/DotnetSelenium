using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Sudo code for setting up Selenium
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com");
            // 2a. Maximize the browser window
            driver.Manage().Window.Maximize();
            // 3. Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            // 4. Type in the element
            webElement.SendKeys("Selenium WebDriver");
            // 5. Click on the element
            webElement.SendKeys(Keys.Return);
        }

        [Test]
        public void EAWebSiteTestReduceSizeCode()
        {
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //3. Find and Click the Login link
            driver.FindElement(By.Id("loginLink")).Click();
            //4. Find the UserName text box
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            //5. Find the Password text box
            driver.FindElement(By.Id("Password")).SendKeys("password");
            //6. Click on the Login button
            driver.FindElement(By.CssSelector(".btn")).Submit();
            
        }

        [Test]
        public void WorkingWithAdvacedControls()
        {
            // 1. Create a new instance of Selenium Web Driver
            //IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            //driver.Navigate().GoToUrl("file:///C:/Users/cheryl.picado/OneDrive-BABEL/Documentos/testpage.html");

            //SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("ddlOptions")));
            //selectElement.SelectByText("Option 2");


            using var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            var path = @"C:\Users\cheryl.picado\OneDrive - BABEL\Documentos\testpage.html";
            var url = new Uri(path).AbsoluteUri;

            driver.Navigate().GoToUrl(url);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Esperar a que el documento termine de cargar
            wait.Until(d =>
                ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.ToString() == "complete"
            );

            // Esperar a que exista el dropdown (y que esté visible)
            wait.Until(d =>
            {
                var el = d.FindElement(By.Id("ddlOptions"));
                return el.Displayed && el.Enabled;
            });

            // Dropdown
            var dropdown = new SelectElement(driver.FindElement(By.Id("ddlOptions")));
            dropdown.SelectByText("Option 3");

            // Esperar a que exista el multiselect (visible)
            wait.Until(d =>
            {
                var el = d.FindElement(By.Id("msOptions"));
                return el.Displayed && el.Enabled;
            });

            // MultiSelect
            var multi = new SelectElement(driver.FindElement(By.Id("msOptions")));
            multi.SelectByValue("multi1");
            multi.SelectByValue("multi2");

            IList<IWebElement> selectedOptions = multi.AllSelectedOptions;

            foreach (IWebElement option in selectedOptions)
            {
                Console.WriteLine($"Opción seleccionada: {option.Text}");
            }

            Console.WriteLine("Presioná Enter para cerrar...");
            Console.ReadLine();


            // Dejarlo abierto para ver
            Thread.Sleep(20000);
        }
    }
}
