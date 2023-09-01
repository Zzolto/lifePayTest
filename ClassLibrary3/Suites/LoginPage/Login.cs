using ClassLibrary3.PageObject;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3
{
    [Parallelizable]
    [AllureParentSuite("[Вход]")]
    [Category("Все")]
    [TestFixture]
    [AllureNUnit]
    public class LoginPage:FixtureHelper
    {
        public LoginPage_ page;
        public override void SetUp()
        {
            base.SetUp();
            page = new LoginPage_(fixture.Driver);
        }        

        [Order(0)]
        [TestCase(Description = "Ввод неверных дданых при авторизации")]
        [Author("Zolto")]
        public void _00_DoLogin()
        {
            page.LogIn(Utilities.Phone, "sddsafsdfasdfasdf");
            
            page.AssertMessageQuickContains("Ошибка");
        }
    }
}

