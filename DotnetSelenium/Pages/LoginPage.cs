using OpenQA.Selenium;

namespace DotnetSelenium.Pages
{
    public class LoginPage
    //ctor para generar el constructor de la clase LoginPage

    // porque necesitamos el objeto driver para interactuar
    // con los elementos de la página
    {
        private readonly IWebDriver driver;

        //ctrl + . para generar el constructor de la clase
        //LoginPage sobre el driver
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //usaremos la propiedad de Lambda para generar los elementos de la página
        //Lambda elimina llaves, return y get
        //Cada vez que accedemos a la propiedad:LoginLink
        //TxtUserName, TxtPassword, TxtPassword, BtnLogin 
        //se ejecuta el código que está a la derecha de la flecha o driver.FindElement(...)
        //
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));

        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

        IWebElement BtnLogin => driver.FindElement(By.XPath("//button[@type='submit' and contains(@class,'btn-signin')]"));

        IWebElement LnkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));

        IWebElement LnkManageUsers => driver.FindElement(By.LinkText("Manage Users"));

        IWebElement LnkLogoff => driver.FindElement(By.LinkText("Log off"));

        //Estos métodos representan las acciones que
        //se pueden realizar en la página de inicio
        //de sesión, como hacer clic en el enlace de
        //inicio de sesión, ingresar el nombre de usuario
        //y la contraseña, y verificar si el usuario ha
        //iniciado sesión correctamente.
        public void ClickLoginLink()
        {
            LoginLink.ClickElement();//SeleniumCustomMethods
        }

        public void Login(string username, string password)
        {
            TxtUserName.Clear();//Limpia el campo antes de escribir
            TxtUserName.SendKeys(username);//acá se escribe el usuario y es una extensión personalizada
            //ya que normalmente se usaría TxtUserName.SendKeys(username);

            TxtPassword.Clear();//buena practica
            TxtPassword.SendKeys(password);
            ClickSignInSafe();
        }

        private void ClickSignInSafe()
        {
            try
            {
                // intento normal
                BtnLogin.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // si algo lo tapa o está animado: scroll + JS click
                var js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", BtnLogin);
                js.ExecuteScript("arguments[0].click();", BtnLogin);
            }
        }

        //Esto basicamente devuelve una tupla con tres valores
        //booleanos que indican si los enlaces "Employee Details",
        //"Manage Users" y "Log off" están visibles en la página
        //después de iniciar sesión. Esto se puede usar para verificar
        //si el inicio de sesión fue exitoso y si los elementos
        //específicos de la página están disponibles para el usuario.
        public (bool employeeDetails, bool manageUsers, bool lnkLogoff) IsLoggedIn()
        {
            return (LnkEmployeeDetails.Displayed, LnkManageUsers.Displayed, LnkLogoff.Displayed);
        }

        public void ClickSignIn()
        {
            try
            {
                // 1) Intento normal
                BtnLogin.Click();
            }
            catch (ElementClickInterceptedException)
            {
                // 2) Scroll + JS click (a prueba de overlays)
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", BtnLogin);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", BtnLogin);
            }
        }

    }
}