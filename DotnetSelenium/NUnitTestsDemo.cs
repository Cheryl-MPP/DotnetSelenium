using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetSelenium
{

    [TestFixture("admin","password")]
    public class NUnitTestsDemo
    {
        
        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;

        public NUnitTestsDemo(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        //[TestCase]
        [Category("smoke")]
        public void TestWithPOM()
        {

            //Inicia la página con POM
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLoginLink();

            loginPage.Login(userName,password);

        }

        [Test]
        [TestCase("chrome", "30")]
        public void TestBrowserVersion(string browser, string version) 
        { 
            Console.WriteLine($"El servidor de pruebas se ejecuta en el navegador: {browser} y la versión: {version}");
        }

        [TearDown]

        public void TearDown()
        {
            _driver.Quit(); //cierra el navegador
            _driver.Dispose(); //libera los recursos del driver y memoria
        }
    }
}
