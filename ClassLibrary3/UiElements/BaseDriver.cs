using Allure.Net.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    
        private ChromeDriver StartBrowser()
        {
            return new ChromeDriver();;
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
        
        public void ScrollToElement(By locator)
        {
            try
            {
                Actions action = new Actions(driver);
                IWebElement element = GetEl(locator, 30);
                action.ScrollToElement(element).Perform();
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(1000);
                throw new Exception($"Элемент {locator.ToString()} не найден!");
            }
        }
        
        public IWebElement FillField(By locator, string value, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    
                    element.SendKeys(value);
                    
                    return element;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    secondsToWait -= 1;
                }
            }
            throw new Exception($"Element {locator.ToString()} not fillable!");
        }
        
        public void WaitUntilPageIsLoaded()
        {
            bool areEqual = false;
            while (!areEqual)
            {
                var old_pagesource = driver.PageSource;
                Thread.Sleep(500);
                var new_pagesource = driver.PageSource;

                if (old_pagesource == new_pagesource)
                {
                    areEqual = true;
                }
            }
        }
        public IWebElement Click(By locator, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    element.Click();
                    WaitUntilPageIsLoaded();
                    return element;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    secondsToWait -= 1;
                }
            }
            throw new Exception($"Element {locator.ToString()} not clickable!");
        }
        
        public IReadOnlyCollection<IWebElement> GetEls(By locator, int secondsToWait = 3)
        {
            while (secondsToWait > 0)
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
                if (elements.Count > 0)
                {
                    return elements;
                }
                Thread.Sleep(1000);
                secondsToWait -= 1;
            }
            throw new NoSuchElementException($"На странице не найден элемент: {locator.ToString()};");
        }
        
        public int GetElsCount(By locator, int secToWait = 3)
        {
            try
            {
                IReadOnlyCollection<IWebElement> elements = GetEls(locator, secToWait);
                return elements.Count;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}

