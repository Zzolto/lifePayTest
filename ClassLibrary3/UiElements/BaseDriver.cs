using Allure.Net.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ClassLibrary3
{
    public class BaseDriver
    {
        private IWebDriver driver;
    
        public BaseDriver()
        {
            driver = StartBrowser();
        }
        private string remoteWdUri = "http://localhost:4444/";

    
        private ChromeDriver StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            var nameSession = TestContext.CurrentContext.Test.Name;

            TimeSpan waiting = TimeSpan.FromMinutes(10);

            var driver = new ChromeDriver();
            return driver;
        }

        public void Quit()
        {
            driver.Quit();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
     
        #region навигация
        public void GoToUrl(string url = null)
        {
            if (url != null) driver.Url = Utilities.baseUrl + url;
            driver.Navigate().Refresh();
        }
        #endregion
        
        
        public IWebElement GetEl(By locator, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
                if (elements.Count > 0)
                {
                    foreach (IWebElement element in elements)
                    {
                        return element;
                    }
                }
                System.Threading.Thread.Sleep(1000);
                secondsToWait -= 1;
            }
            throw new NoSuchElementException($"На странице не найден элемент: {locator.ToString()};");
        }
        
        public void AttachScreenToReport()
        {
            byte[] img = TakeScreenshot();

            try
            {
                Random rnd = new Random();
                AllureLifecycle.Instance.AddAttachment($"ScreenShot-{DateTime.Now.Hour.ToString()}-{DateTime.Now.Minute.ToString()}-{DateTime.Now.Second.ToString()}" +
                                                       $"-{rnd.Next(100, 999).ToString()}", "image/png", img, "png");
            }
            catch
            {

            }
        }
        
        private byte[] TakeScreenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                byte[] screenshotAsByteArray = ss.AsByteArray;
                return screenshotAsByteArray;
            }
            catch (Exception e)
            {
                throw new Exception($"Не удалось сделать скриншот; {e.Message}");
            }
        }
    }
}

