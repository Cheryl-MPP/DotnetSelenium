using DotnetSelenium;
using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataDrivenTesting
{

    public class NUnitTestsDemo
    {

        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();//inicializa el driver de Chrome
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/Account/Login");//navega a la URL de la aplicación
            _driver.Manage().Window.Maximize();//maximiza la ventana del navegador
        }

        //este test es un ejemplo de cómo usar
        //el patrón de diseño POM (Page Object Model)
        //para realizar pruebas de inicio de sesión
        //en una aplicación web.
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]//json


        public void TestWithPOM(LoginModel loginModel)
        {

            //Inicia la página con POM
            //Arrange creás el objeto Page Object (POM) pasándole el driver.
            //Esto centraliza selectores y acciones dentro de LoginPage.
            //Esto centraliza selectores y acciones dentro de LoginPage.
            LoginPage loginPage = new LoginPage(_driver);//loginpage

            //Act ejecutás el flujo de login:
            //click en el link de login
            //llenás user y pass con los datos del JSON
            //enviás el formulario
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            //Assert, estas se crean solamente dentro de los tests, nunca dentro del POM
            //validás que el login se hizo bien verificando que aparecen links
            //del menú post-login.
            var getLoggedIn = loginPage.IsLoggedIn();
            Assert.That(getLoggedIn.employeeDetails && getLoggedIn.manageUsers && getLoggedIn.lnkLogoff, Is.True);
        }//Aquí hacemos la validación y se confirma que los elementos post-login estén visibles

        [Test]
        [Category("ddt")] //data driven test
        public void TestWithPOMWithJsonData()
        {

            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json"); // Ruta del archivo JSON
            //leer el file
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            //Inicia la página con POM
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.ClickLoginLink();

            loginPage.Login(loginModel.UserName, loginModel.Password);

        }//no

        public static IEnumerable<LoginModel> Login()//**
        {
            yield return new LoginModel()
            {
                UserName = "admin",
                Password = "password"

            };

            yield return new LoginModel()
            {
                UserName = "admin2",
                Password = "passwords"

            };

            yield return new LoginModel()
            {
                UserName = "admin3",
                Password = "passwordss"

            };//esto pasa porque el método es un IEnumerable,
              //por lo que se puede usar yield return para
              //devolver cada instancia de LoginModel sin
              //necesidad de crear una lista completa.
        }

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            // Ruta del archivo JSON
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");//archivo que estamos tratando de leer, se encuentra en el bin del proyecto
            //leer el file
            var jsonString = File.ReadAllText(jsonFilePath);
            //va a leer toda la lista de datos
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);//***
            //Se utiliza JsonSerializer.Deserialize para mapear el contenido
            //JSON a una lista de objetos LoginModel, permitiendo aplicar
            //Data Driven Testing con datos externos

            //correr a través de la interacción 
            foreach (var loginData in loginModel)

            {
                yield return loginData;//y devolver cada pequeño valor 1 a 1 cada vez,
                                       //mientras la data source de LoginJsonDataSource
                                       //es llamada allá arriba
            }
        }


        //private void ReadJsonFile()
        //{
        //archivo que estamos tratando de leer, se encuentra en la raíz del proyecto
        //string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json"); // Ruta del archivo JSON
        //leer el file
        //var jsonString = File.ReadAllText(jsonFilePath);
        //deserializar el contenido del JSON a un objeto LoginModel
        //var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString); 
        //Console.WriteLine($"Username {loginModel.UserName} {loginModel.Password}");
        //}// esta información es la que usamos en el TestWithPOM; para que este sirva debo agregar arriba Read...


        [TearDown]

        public void TearDown()
        {
            _driver.Quit(); //cierra el navegador
            _driver.Dispose(); //libera los recursos del driver y memoria
        }
    }
}