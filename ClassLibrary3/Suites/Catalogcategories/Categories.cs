using ClassLibrary3.PageObject.Catalog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ClassLibrary3.Suites.Catalogcategories;

[Parallelizable]
[AllureParentSuite("[Каталог]")]
[AllureSuite("[Категории]")]
[Category("Все")]
[TestFixture]
[AllureNUnit]
public class Categories:FixtureHelper
{
    public CatalogCategoriesPage page;
    public override void SetUp()
    {
        base.SetUp();
        page = new CatalogCategoriesPage(fixture.Driver);
        page.LogIn(Utilities.Phone, Utilities.Password);
    }        

    [Order(0)]
    [TestCase(Description = "Создание новой категории")]
    [Author("Zolto")]
    public void _00_AddCategory()
    {
        page.ChooseOrganization("Магазин_I8xm");

        page.OpenPage();
            
        page.Press_Button(" ДОБАВИТЬ ");
        
        page.Fill_Field("Наименование", "ывывывывы");
        
        page.Fill_Field("Описание", "ывывывывы");
        
        page.Press_Button("Добавить");
        
        page.Assert_HasRecord("ывывывывы");
    }
    
    [Order(0)]
    [TestCase(Description = "Создание новой категории без ввода обязательных полей")]
    [Author("Zolto")]
    public void _00_AddCategory_FailData()
    {
        page.ChooseOrganization("Магазин_I8xm");

        page.OpenPage();
            
        page.Press_Button(" ДОБАВИТЬ ");
        
        page.Press_Button("Добавить");

        page.AssertMessageQuickContains("Ошибка");
    }
}