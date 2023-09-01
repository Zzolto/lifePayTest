using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3
{
    public class WebPage
    {
        public BaseDriver BaseDriver { get; private set; }
        private string path;
        private string pageName;

        public WebPage(BaseDriver baseDriver,string path, string pageName)
        {
            BaseDriver = baseDriver;
            this.path = path;
            this.pageName = pageName;
        }

        /// <summary>
        /// Открывает страницу по заданному пути path
        /// </summary>
        public void OpenPage(string customPath = null)
        {
            if (customPath == null)
            {
                BaseDriver.Click(By.XPath($"//*[@title = '{path}']"));
                Thread.Sleep(1000);
                BaseDriver.Click(By.XPath($"//div[@class = 'mat-list-item-content']//*[text() = ' {pageName} ']"));
            }
            else
            {
                BaseDriver.GoToUrl(customPath);
            }

        }
        
        public void CheckWelcomeMessage(string welcomeMessage)
        {
            var currentTime = DateTime.Now.Hour;

            if(0 < currentTime && currentTime < 6)
                Assert.True(welcomeMessage.Contains("Доброй ночи"));
            else if(12 < currentTime && currentTime < 18)
                Assert.True(welcomeMessage.Contains("Добрый день"));
        }

        public void ChooseOrganization(string organization)
        {
            try
            {
                BaseDriver.GetEl(By.XPath($"//*[text() = '{organization}']")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public void Assert_HasLocator(By xpath)
        {
            Assert.True(BaseDriver.GetElsCount(xpath, 10) != 0, $"Локатор {xpath} не обнаружен");
        }

        public void AssertMessageQuickContains(string message)
        {
            var messageError = BaseDriver.GetEl(
                By.XPath("//*[@class = 'mat-simple-snackbar ng-star-inserted']//span")).Text;
            
            Assert.True(messageError.Contains(message), $"Expected {message}, but was {messageError}");
        }
        
        public void Press_Button(string name, int elementCount = 1)
        {
            By xpath = By.XPath($"(//*[text() = '{name}']/../..//button)[{elementCount}]");
            BaseDriver.Click(xpath, 30);
        }
        
        public void Fill_Field(string fieldName, string value, int elementCount = 1)
        {
            By elementPath = null;
            
            elementPath = By.XPath($"(//*[text() = '{fieldName}']/../..//input)[{elementCount}]");
            
            BaseDriver.ScrollToElement(elementPath);

            BaseDriver.Click(elementPath);

            BaseDriver.FillField(elementPath, value); // Заполняем поле
        }
    }
}

