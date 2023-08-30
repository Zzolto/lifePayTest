using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ClassLibrary3;

public class FixtureHelper
{
    protected Fixture fixture { get; private set; }

    public FixtureHelper()
    {
            
    }

    [OneTimeSetUp]
    public virtual void SetUp()
    {
        fixture = new Fixture();
    }

    [OneTimeTearDown]
    public virtual void Dispose()
    {
        fixture.Dispose();
    }
    
}