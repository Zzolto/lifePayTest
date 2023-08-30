using OpenQA.Selenium;

namespace ClassLibrary3;

public class Fixture:IDisposable
{
    public BaseDriver Driver { get; private set; }

    public Fixture()
    {
        Driver = new BaseDriver();
        LogIn(Utilities.Phone, Utilities.Password);
    }
    
    public void LogIn(string username, string password)
    {
        try
        {
            Driver.GoToUrl("login");
            Thread.Sleep(2500);
            Driver.GetEl(By.XPath("//input[@type = 'tel']")).SendKeys(username);
            Driver.GetEl(By.XPath("//input[@type = 'password']")).SendKeys(password);
            Driver.GetEl(By.XPath("//*[@elementid = 'login-lk']")).Click();
        }
        catch (Exception e)
        {
            throw new ElementNotVisibleException($"Не удалось найти элемент на странице: {e.Message}");
        }
    }

    public void ChooseOrganization()
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public void Dispose()
    {
        Driver.Quit();
        
        Driver.Dispose();
    }
}