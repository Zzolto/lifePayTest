using OpenQA.Selenium;

namespace ClassLibrary3;

public class Fixture:IDisposable
{
    public BaseDriver Driver { get; private set; }
    
    public Fixture()
    {
        Driver = new BaseDriver();
    }
    
    
    
    public void Dispose()
    {
        Driver.Quit();
        
        Driver.Dispose();
    }
}