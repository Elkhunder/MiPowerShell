using MiPowerShell.Validation;
using Xunit;
using System.Threading.Tasks;
using FluentValidation;

namespace MiPowerShell.Tests.Validation
{
    public class UrlSchemeValidatorTests
    {
        private UrlSchemeValidator _validator;

        public UrlSchemeValidatorTests()
        {
            _validator = new UrlSchemeValidator();
        }

        [Theory]
        [InlineData("https://google.com")]
        public async Task Should_Return_True_For_Valid_Url_Scheme(string url)
        {
            var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
            Assert.True(result.IsSuccessCode);
            Assert.Null(result.FailureReason);
            Assert.Null(result.FailureMessage);
        }

        [Theory]
        [InlineData("ftp://google.com")]
        
        public async Task Should_Return_False_For_Unsupported_Url_Scheme(string url)
        {
            var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
            Assert.False(result.IsSuccessCode);
            Assert.Equal(FailureReason.UnsupportedScheme, result.FailureReason);
            Assert.NotNull(result.FailureMessage);
        }

        [Theory]
        [InlineData("https://192.168.1.120")]
        public async Task Should_Return_False_For_Socket_Error(string url)
        {
            var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
            Assert.False(result.IsSuccessCode);
            Assert.Equal(FailureReason.Socket, result.FailureReason);
            Assert.NotNull(result.FailureMessage);
        }

        [Theory]
        [InlineData("http://192.168.1.120")]
        public async Task Should_Return_False_For_Http_Scheme(string url)
        {
            var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
            Assert.False(result.IsSuccessCode);
            Assert.Equal(FailureReason.HttpScheme, result.FailureReason);
            Assert.NotNull(result.FailureMessage);
        }

        //[Theory]
        //public async Task Should_Return_False_For_UknownException(string url)
        //{
        //    var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
        //    Assert.False(result.IsSuccessCode);
        //    Assert.Equal(FailureReason.General, result.FailureReason);
        //}

        [Theory]
        [InlineData("https://192.168.1.120")]
        public async Task Should_Return_False_For_Ssl_Unsupported(string url)
        {
            var result = await _validator.IsValidAsync(new ValidationContext<string>(url), url);
            Assert.False(result.IsSuccessCode);
            Assert.Equal(FailureReason.SslUnsupported, result.FailureReason);
        }
    }
}

