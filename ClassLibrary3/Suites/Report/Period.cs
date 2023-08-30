﻿using ClassLibrary3.PageObject.Reports;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ClassLibrary3.Suites.Report
{
    [Parallelizable]
    [TestFixture]
    [AllureNUnit]
    public class Period:FixtureHelper
    {
        public ReportWorkPlacePagePeriod page;
        
        public override void SetUp()
        {
            base.SetUp();
            page = new ReportWorkPlacePagePeriod(fixture.Driver);
            page.ChooseOrganization("Магазин_I8xm");

        }

        [Order(0)]
        [TestCase(Description = "Проверка отображения приветствия на экране")]
        [Author("Zolto")]
        public void _00_Check_WelcomeMessage()
        {
            page.OpenPage();
            
            page.Assert_HasLocator(By.XPath("//*[text() = 'Добро пожаловать, Гунзенов Золто']"));
        }
        
    }
}
