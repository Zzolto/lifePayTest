using ClassLibrary3.PageObject.Orders;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3.Suites.Orders;

[Parallelizable]
[TestFixture]
[AllureNUnit]
public class Orders:FixtureHelper
{
    public OrdersPage page;
    public override void SetUp()
    {
        base.SetUp();
        page = new OrdersPage(fixture.Driver);
    }

    [Order(0)]
    [TestCase(Description = "Проверка отображения приветствия на экране")]
    [Author("Zolto")]
    public void _00_Check_WelcomeMessage()
    {
        page.OpenPage();
            
        page.Assert_HasLocator(By.XPath("//*[text() = 'Добро пожаловать, Гунзенов Золто']"));
    }

    [Order(1)]
    [TestCase(Description = "")]
    [Author("")]
    public void _01_Create_Order()
    {
        page.ChooseOrganization("Магазин_I8xm");

        page.OpenPage();

        page.Press_Button("Создать");
        
        page.Fill_Field("Наименование", "Цена, ₽");
        
        page.Press_Button("Далее");
        page.Press_Button("Далее");
        page.Press_Button("Создать");
    }
}