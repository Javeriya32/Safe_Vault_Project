using NUnit.Framework;
using SafeVault.Services;

[TestFixture]
public class XssTests
{
    [Test]
    public void Script_ShouldBeRemoved()
    {
        string payload = "<script>alert('xss')</script>";
        string sanitized = InputSanitizer.Sanitize(payload);

        Assert.IsFalse(sanitized.Contains("script"));
    }
}
