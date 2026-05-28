using System.Text.Json;

namespace BackEP26.Services;

public class RecaptchaService(HttpClient http, IConfiguration config)
{
    private readonly string _secret = config["Recaptcha:SecretKey"]
        ?? throw new InvalidOperationException("Recaptcha:SecretKey not configured");

    public async Task<bool> VerifyAsync(string token)
    {
        var response = await http.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={_secret}&response={token}",
            null);

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        bool success = root.GetProperty("success").GetBoolean();
        double score = root.TryGetProperty("score", out var s) ? s.GetDouble() : 0;

        return success && score >= 0.5;
    }
}
