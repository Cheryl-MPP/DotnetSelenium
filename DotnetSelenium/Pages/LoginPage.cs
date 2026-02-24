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
        //TxtUser, TxtPassword, TxtPassword, BtnLogin 
        //se ejecuta el código que está a la derecha de la flecha o driver.FindElement(...)
        //
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));

        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        IWebElement LnkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));

        IWebElement LnkManageUsers => driver.FindElement(By.LinkText("Manage Users"));

        IWebElement LnkLogoff => driver.FindElement(By.LinkText("Log off"));

        public void ClickLoginLink()
        {
            LoginLink.ClickElement();
        }

        public void Login(string username, string password)
        {
            TxtUserName.Clear();
            TxtUserName.EnterText(username);

            TxtPassword.Clear();
            TxtPassword.EnterText(password);
            BtnLogin.SubmitElement();
        }

        public (bool employeeDetails, bool manageUsers, bool lnkLogoff) IsLoggedIn()
        {
            return (LnkEmployeeDetails.Displayed, LnkManageUsers.Displayed, LnkLogoff.Displayed);
        }

    }
}
