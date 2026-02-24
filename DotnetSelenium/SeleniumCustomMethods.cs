using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public static class SeleniumCustomMethods
    {

        //1.Nuestro método debe tomar el locator
        //2.Empezar a obtener el tipo de identifier
        //3.Realizar operación en el locator


        //parametrizamos el driver dentro del click

        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            //este método va a limpiar el campo de texto antes de escribir
            //el nuevo texto, para evitar concatenar el nuevo texto con el
            //texto que ya estaba escrito en el campo
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropdownByText(this IWebElement locator, string text)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }


        public static void SelectDropdownByValue(this IWebDriver driver, By locator, string value)
        {
            var selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            var multiSelect = new SelectElement(locator);

            foreach (string value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(this IWebElement locator)
        {
            var options = new List<string>();
            var multiSelect = new SelectElement(locator);

            var selectedOptions = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOptions)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
