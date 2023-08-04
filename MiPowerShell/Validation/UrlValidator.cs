using FluentValidation;
using System.Net;

namespace MiPowerShell.Validation
{
    public class UrlValidator : AbstractValidator<string>
    {
        public UrlValidator()
        {
            RuleFor(url => url).NotEmpty().WithMessage("URL cannot be empty");
            RuleFor(url => url).Must(NotBeKnownBadPort).WithMessage("URL must not be a known bad port");
            RuleFor(url => url).Must(BeValidUrlOrIPAddress).WithMessage("URL must be a valid URL or IP address");
        }

        private bool NotBeKnownBadPort(string url)
        {
            var knownBadPorts = new List<string> { "PRINTER", "LPT1:", "nul:" };
            return !knownBadPorts.Contains(url.ToUpperInvariant());
        }

        private bool BeValidUrlOrIPAddress(string url)
        {
            // Check if it's a valid IP address
            if (IPAddress.TryParse(url, out _))
                return true;

            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            // Check the URL contains "."
            if (result)
                result = uriResult.Host.Contains('.');

            return result;
        }
    }
}
