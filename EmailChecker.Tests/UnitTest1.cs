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
    }
}
