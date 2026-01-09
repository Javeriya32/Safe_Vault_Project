using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class AuthenticationTests
    {
        [Test]
        public void PasswordHashing_ShouldValidateCorrectPassword()
        {
            string password = "SecurePassword123!";
            string hash = PasswordHasher.Hash(password);

            bool isValid = PasswordHasher.Verify(password, hash);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void PasswordHashing_ShouldRejectIncorrectPassword()
        {
            string password = "CorrectPassword";
            string wrongPassword = "WrongPassword";

            string hash = PasswordHasher.Hash(password);
            bool isValid = PasswordHasher.Verify(wrongPassword, hash);

            Assert.IsFalse(isValid);
        }
    }
}
