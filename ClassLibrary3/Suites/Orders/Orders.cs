using ClassLibrary3.PageObject.Orders;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3.Suites.Orders;

[Parallelizable]
[AllureParentSuite("[Заказы]")]
[AllureSuite("[Все заказы]")]
[Category("Заказы")]
[Category("Все_заказы")]
[Category("Все")]
[TestFixture]
[AllureNUnit]
public class Orders:FixtureHelper
{
    private OrdersPage page;
    public override void SetUp()
    {
        base.SetUp();
        page = new OrdersPage(fixture.Driver);
        page.LogIn(Utilities.Phone, Utilities.Password);
    }

    [Order(0)]
    [TestCase(Description = "Проверка отображения приветствия на экране")]
    [Author("Zolto")]
    public void _00_Check_WelcomeMessage()
    {
        //page.CheckWelcomeMessage(page.welcomeMessage);
        
        page.ChooseOrganization("Магазин_I8xm");

        page.Assert_HasLocator(By.XPath("//*[text() = 'Добро пожаловать, Гунзенов Золто']"));
    }

    [Order(1)]
    [TestCase(Description = "Сохранение записи без ввода обязательных полей с вводом недопустимых символов")]
    [Author("Zolto")]
    public void _01_Create_Order()
    {
        page.ChooseOrganization("Магазин_I8xm");

        page.OpenPage();
        
        Thread.Sleep(4000);

        page.Press_Button(" СОЗДАТЬ ");
        
        page.Fill_Field("Цена, ₽", "Цена, ₽");
        
        page.Press_Button("Далее");
        
        page.Press_Button("Далее");
        
        page.Press_Button("Создать");
        
        page.AssertMessageQuickContains("Заполните поля формы корректно");
    }
}