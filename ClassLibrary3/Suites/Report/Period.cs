using ClassLibrary3.PageObject.Reports;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

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
        }

        [Order(0)]
        [TestCase(Description = "")]
        [Author("")]
        public void _00_CreateReport()
        {
            Thread.Sleep(1000);
        }
    }
}
