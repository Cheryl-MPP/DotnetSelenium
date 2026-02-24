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

        //[Test]
        //public void EAWebSiteTestReduceSizeCode()
        //{
        // 1. Create a new instance of Selenium Web Driver
        //var driver = new ChromeDriver();
        // 2. Navigate to the URL
        //driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        //3. Find and Click the Login link
        //driver.FindElement(By.Id("loginLink")).Click();

        //línea nueva para implementar el método click de SeleniumCustomMethods
        //SeleniumCustomMethods.Click(driver, By.Id("loginLink"));
        //4. Find the UserName text box
        //driver.FindElement(By.Name("UserName")).SendKeys("admin");
        //SeleniumCustomMethods.EnterText(driver, By.Name("UserName"), "admin");
        //5. Find the Password text box
        //driver.FindElement(By.Id("Password")).SendKeys("password");
        //6. Click on the Login button
        //driver.FindElement(By.CssSelector(".btn")).Submit();

        //}

        //[Test]
        //public void WorkingWithAdvacedControls()
        //{


        //1) Crear el navegador (ChromeDriver) y preparar la ventana
        //Inicializo una instancia de ChromeDriver y maximizo
        //la ventana para asegurar estabilidad visual y
        //consistencia en la interacción con elementos.

        //using var driver = new ChromeDriver();
        //driver.Manage().Window.Maximize();

        //2)Construir la URL de HTML local (file : //) de forma segura
        //Convierto la ruta local a una URI absoluta
        //para navegar con el protocolo file://
        //y evitar fallos por espacios o caracteres especiales

        //var path = @"C:\Users\cheryl.picado\OneDrive - BABEL\Documentos\testpage.html";
        //var url = new Uri(path).AbsoluteUri;

        //3) Abrir la página en el navegador
        //Navego a una página de prueba local para
        //ejecutar automatización sin depender de
        //ambientes externos.

        //driver.Navigate().GoToUrl(url);

        //4) Crear una espera explícita(WebDriverWait)
        //Uso waits explícitos para sincronización;
        //evita condiciones de carrera y hace el
        //test más estable.

        // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //5) Esperar a que el documento termine de cargar (DOM ready)
        //Sincronizo con el estado de carga del documento usando
        //document.readyState para asegurar que el DOM está listo
        //antes de buscar elementos.
        //***

        //wait.Until(d =>
        //((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.ToString() == "complete"
        //);


        //6) Esperar a que el dropdown exista y sea interactuable
        //Espero a que el control esté presente y listo para
        //interacción (visible y habilitado) antes de operar
        //sobre él.
        // wait.Until(d =>
        //{
        //var el = d.FindElement(By.Id("ddlOptions"));
        // return el.Displayed && el.Enabled;
        //});

        //7) Manipular el dropdown con SelectElement
        //Para elementos <select> uso SelectElement,
        //y selecciono por texto visible para que el
        //script sea legible y mantenible
        //var dropdown = new SelectElement(driver.FindElement(By.Id("ddlOptions")));
        //dropdown.SelectByText("Option 2");
        //SeleniumCustomMethods.SelectDropdownByText(driver, By.Id("ddlOptions"), "Option 2");

        //8) Esperar a que el multiselect esté listo
        //Aplico la misma estrategia de sincronización
        //al multiselect para evitar fallos por timing.
        //wait.Until(d =>
        //{
        //var el = d.FindElement(By.Id("msOptions"));
        //return el.Displayed && el.Enabled;
        //});

        //9) Seleccionar múltiples opciones del multiselect
        //En un multiselect selecciono múltiples valores
        //usando SelectByValue para apuntar directo al
        //atributo value del HTML.
        //var multi = new SelectElement(driver.FindElement(By.Id("msOptions")));

        //Este método se reemplaza por el de SeleniumCustomMethods
        //para seleccionar múltiples opciones
        //multi.SelectByValue("multi1");
        //multi.SelectByValue("multi3");

        //SeleniumCustomMethods.MultiSelectElements(driver, By.Id("msOptions"), new string[] { "multi1", "multi3" });

        //var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedLists(driver, By.Id("msOptions"));

        //getSelectedOptions.ForEach(option => Console.WriteLine($"Opción seleccionada: {option}"));


        // foreach (var  selectedOptions in getSelectedOptions)
        //{
        //  Console.WriteLine(selectedOptions);
        //}


        //10) Obtener lo seleccionado y imprimirlo (evidencia)
        //Recupero las selecciones del multiselect y las
        //registro en consola como evidencia
        //y trazabilidad del test
        //IList<IWebElement> selectedOptions = multi.AllSelectedOptions;

        //foreach (IWebElement option in selectedOptions)
        //{
        // Console.WriteLine($"Opción seleccionada: {option.Text}");
        //}

        //11) Pausa manual
        //Esto es solo para el demo;
        //normalmente en ejecución CI/CD
        //no se usa input manual.
        //Console.WriteLine("Presioná Enter para cerrar...");
        //Console.ReadLine();


        //12) Ojo: con este Sleep porque sobra
        //(y está después del ReadLine.....)
        //Son dos mecanismos de pausa para mi
        //demo; se deja uno según el contexto.
        //En automático real se elimina.
        //Thread.Sleep(20000);

        //id es un elemento dinámico
        //click en el link de login y cambiará 
        //dependiendo de la necesidad de la web



        //loginLink está comunicado con el
        //locator de SeleniumCustomMethods

        //SeleniumCustomMethods.Click(driver, By.Id("loginLink"));


        //}

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