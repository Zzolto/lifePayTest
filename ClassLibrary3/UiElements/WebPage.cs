using Allure.Net.Commons;
using NUnit.Allure.Core;
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
                        BaseDriver.GoToUrl(path);

                    Thread.Sleep(6000);

                }, $"Открытие страницы '{path}'");
        }
        
    }
}

