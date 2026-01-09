using NUnit.Framework;
using SafeVault.Services;

[TestFixture]
public class SqlInjectionTests
{
    [Test]
    public void SqlPayload_ShouldBeSanitized()
    {
        string payload = "' OR 1=1; --";
        string result = InputSanitizer.Sanitize(payload);

        Assert.IsFalse(result.Contains("OR"));
        Assert.IsFalse(result.Contains("--"));
    }
}
