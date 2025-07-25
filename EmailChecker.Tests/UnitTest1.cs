using Xunit;
using EmailChecker;

namespace EmailChecker.Tests
{
    public class EmailValidatorTests
    {
        [Fact]
        public void IsValidSyntax_Should_ReturnTrue_For_ValidEmail()
        {
            var result = EmailValidator.IsValidSyntax("john@example.com");
            Assert.True(result);
        }

        [Fact]
        public void IsValidSyntax_Should_ReturnFalse_For_InvalidEmail()
        {
            var result = EmailValidator.IsValidSyntax("not-an-email");
            Assert.False(result);
        }

        [Fact]
        public void IsDisposable_Should_ReturnTrue_For_DisposableEmail()
        {
            var disposableDomains = new HashSet<string> { "mailinator.com", "yopmail.com" };
            var result = EmailValidator.IsDisposable("user@mailinator.com", disposableDomains);
            Assert.True(result);
        }

        [Fact]
        public void IsDisposable_Should_ReturnFalse_For_NormalEmail()
        {
            var disposableDomains = new HashSet<string> { "mailinator.com", "yopmail.com" };
            var result = EmailValidator.IsDisposable("john@gmail.com", disposableDomains);
            Assert.False(result);
        }
    }
}
