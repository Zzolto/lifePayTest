using ClassLibrary3;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject.Drivers;

namespace SpecFlowProject.Steps;


[Binding]
[NUnit.Framework.DescriptionAttribute("Login")]
public sealed class LoginFeature
{
    private BaseDriver Driver;

    [Given(@"the user is on the login page")]
    public void GivenTheUserIsOnTheLoginPage()
    {
        Driver.GoToUrl("https://my.life-pos.ru/auth/login");
    }
    [When(@"the user clicks the '(.*)' button")]
    public void WhenTheUserClicksTheButton(string login)
    {
        Driver.GetEl(By.XPath("//input[@type = 'tel']")).SendKeys(Utilities.Phone);
        Driver.GetEl(By.XPath("//input[@type = 'password']")).SendKeys(Utilities.Password);
        Thread.Sleep(3000);
        Driver.GetEl(By.XPath("//*[@elementid = 'login-lk']")).Click();
    }
    
    [When(@"the user enters valid credentials")]
    public void WhenTheUserEntersValidCredentials()
    {
        ScenarioContext.StepIsPending();
    }
    
    [Then(@"the user is successfully logged in")]
    public void ThenTheUserIsSuccessfullyLoggedIn()
    {
        ScenarioContext.StepIsPending();
    }
}