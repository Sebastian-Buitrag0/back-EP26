using Google.Apis.Auth;

namespace BackEP26.Services;

public class GoogleTokenService(IConfiguration config)
{
    private readonly string _clientId = config["Google:ClientId"]
        ?? throw new InvalidOperationException("Google:ClientId not configured");

    public async Task<string> ValidateAndGetSubAsync(string idToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = [_clientId]
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        return payload.Subject;
    }
}
