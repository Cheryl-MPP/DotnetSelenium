using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            // 1. Create a new instance of Selenium Web Driver
            var driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com");
            // 2a. Maximize the browser window
            driver.Manage().Window.Maximize();
            // 3. Find the element
            var webElement = driver.FindElement(By.Name("q"));
            // 4. Type in the element
            webElement.SendKeys("Selenium WebDriver");
            // 5. Click on the element
            webElement.SendKeys(Keys.Return);
        }

        [Test]

        public void EAWebSiteTest()
        {
            //1. Crear una nueva instancia de Selenium Web Driver
            var driver = new ChromeDriver();
            //2. Navegar a la URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //3. Find and Click the Login link
            var loginLink = driver.FindElement(By.Id("loginLink"));
            //4. Find the login link and click on it
            loginLink.Click();
            //5. Find the username text box
            var txtUsername = driver.FindElement(By.Name("UserName"));
            //6. Typing in the username text box
            txtUsername.SendKeys("admin");
            //7. Find the password text box
            var txtPassword = driver.FindElement(By.Id("Password"));
            //8. Typing the textUserName
            txtPassword.SendKeys("password");
            //9. Find the login button using Class Name
            //IwebElement btnLogin = driver.FindElement(By.ClassName("btn"));
            //9. Find the login button using CSS Selector
            var btnLogin = driver.FindElement(By.CssSelector(".btn"));
            //10. Click on the login button
            btnLogin.Submit();

        }

        [Test]
        public void TestWithPOM()
        {
            //1. Crear una nueva instancia de Selenium Web Driver
            var driver = new ChromeDriver();
            //2. Navegar a la URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //3.Inializar la página con POM
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLoginLink();

            loginPage.Login("admin", "password");

        }

        

        [Test]

        public void Test4() 
        
        { 

        
        }
        [Test]
        public void Test5()

        {


        }

    }
}