using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3
{
    public class WebPage
    {
        public BaseDriver BaseDriver { get; private set; }
        private string path;

        public WebPage(BaseDriver baseDriver, string path)
        {
            BaseDriver = baseDriver;
            this.path = path;
        }

        /// <summary>
        /// Открывает страницу по заданному пути path
        /// </summary>
        public void OpenPage(string pathCustom = null)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
                {
                    if (!string.IsNullOrEmpty(pathCustom))
                        BaseDriver.GoToUrl(pathCustom);
                    else
                        BaseDriver.Click(By.XPath(
                            "//*[@class = 'mat-nav-list mat-list-base ng-tns-c127-8 ng-star-inserted']//*[text() = ' Все заказы ']"));
                        //BaseDriver.GoToUrl(path);

                    Thread.Sleep(6000);

                }, $"Открытие страницы '{path}'");
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
            AllureLifecycle.Instance.WrapInStep(() =>
                {
                    Assert.True(BaseDriver.GetElsCount(xpath, 10) != 0, $"Локатор {xpath} не обнаружен");

                }, $"Проверка присутствия '{xpath}'");
        }

        
        public void Press_Button(string name, int elementCount = 1)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                By xpath = By.XPath($"//*[text() = '{name}']/../..//button)[{elementCount}]");
                BaseDriver.Click(xpath, 30);

            }, $"Нажатие на кнопку '{name}'");
        }
        
        public void Fill_Field(string fieldName, string value, int elementCount = 1)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
                {
                    By elementPath = null;

      
                    elementPath = By.XPath($"//*[text() = '{fieldName}']/../..//input)[{elementCount}]");
      

                    BaseDriver.ScrollToElement(elementPath);

                    BaseDriver.Click(elementPath);

                    BaseDriver.FillField(elementPath, value); // Заполняем поле

                }, $"Заполнение поля '{fieldName}' = {value}");
        }
    }
}

