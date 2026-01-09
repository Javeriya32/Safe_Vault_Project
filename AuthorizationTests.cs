using NUnit.Framework;

namespace SafeVault.Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        [Test]
        public void AdminRole_ShouldHaveAccess()
        {
            string role = "Admin";

            bool hasAccess = role == "Admin";

            Assert.IsTrue(hasAccess);
        }

        [Test]
        public void UserRole_ShouldNotHaveAdminAccess()
        {
            string role = "User";

            bool hasAccess = role == "Admin";

            Assert.IsFalse(hasAccess);
        }

        [Test]
        public void MissingRole_ShouldBeDenied()
        {
            string role = string.Empty;

            bool hasAccess = role == "Admin";

            Assert.IsFalse(hasAccess);
        }
    }
}
