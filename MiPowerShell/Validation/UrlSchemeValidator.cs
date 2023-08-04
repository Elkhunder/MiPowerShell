using FluentValidation;
using FluentValidation.Validators;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Authentication;

namespace MiPowerShell.Validation
{
    public class HttpsTestResult
    {
        public bool IsSuccessCode { get; set; }
        public FailureReason? FailureReason { get; set; }
        public string? FailureMessage { get; set; }
    }

    public enum FailureReason
    {
        None,
        Offline,
        UnsupportedScheme,
        SslUnsupported,
        Null,
        Autentication,
        Socket,
        HttpRequest,
        General,
        HttpScheme
    }
        
    public class UrlSchemeValidator : AsyncPropertyValidator<string, string>
    {
        public override string Name => "UrlSchemeValidator";

        public override Task<bool> IsValidAsync(ValidationContext<string> context, string url, CancellationToken cancellation)
        {
            if(url == null)
            {
                return Task.FromResult<bool>(false);
            }
            return Task.FromResult<bool>(true);
        }

        public async Task<HttpsTestResult> IsValidAsync(ValidationContext<string> context, string url)
        {
            if (url == null)
            {
                return new HttpsTestResult
                {
                    IsSuccessCode = false,
                    FailureReason = FailureReason.Null,
                    FailureMessage = "didn't receive a url to test",
                };
            }

            return await TestHttpsSupportAsync(url);
        }

        private async Task<HttpsTestResult> TestHttpsSupportAsync(string url)
        {
            if (!url.StartsWith("https://"))
            {
                if (!url.StartsWith("http://"))
                {
                    return new HttpsTestResult
                    {
                        IsSuccessCode = false,
                        FailureReason = FailureReason.UnsupportedScheme,
                        FailureMessage = "Unsupportd scheme was received"
                    };
                }

                return new HttpsTestResult
                {
                    IsSuccessCode = false,
                    FailureReason = FailureReason.HttpScheme,
                    FailureMessage = "Was Expecting https:// got http://"
                };
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Head,
                        RequestUri = new Uri(url)
                    };

                    var response = await client.SendAsync(request);

                    return new HttpsTestResult
                    {
                        IsSuccessCode = response.IsSuccessStatusCode,
                    };
                }
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException is SocketException)
                    {
                        return new HttpsTestResult
                        {
                            IsSuccessCode = false,
                            FailureReason = FailureReason.Socket,
                            FailureMessage = ex.InnerException.Message
                        };
                    }
                    else if (ex.InnerException is AuthenticationException)
                    {
                        return new HttpsTestResult
                        {
                            IsSuccessCode = false,
                            FailureReason = FailureReason.Autentication,
                            FailureMessage = ex.InnerException.Message
                        };
                    }
                    else
                    {
                        return new HttpsTestResult
                        {
                            IsSuccessCode = false,
                            FailureReason = FailureReason.HttpRequest,
                            FailureMessage = ex.InnerException.Message
                        };
                    }
                }
                else
                {
                    return new HttpsTestResult
                    {
                        IsSuccessCode = false,
                        FailureReason = FailureReason.HttpRequest,
                        FailureMessage = ex.Message,
                    };
                }
            }
            catch (Exception ex)
            {
                return new HttpsTestResult 
                { 
                    IsSuccessCode = false,
                    FailureReason = FailureReason.General,
                    FailureMessage = ex.Message, 
                };
            }
        }
    }
}
