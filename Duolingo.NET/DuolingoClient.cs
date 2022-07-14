using Duolingo.NET.Models;
using System.Text.Json;

namespace Duolingo.NET;

public class DuolingoClient
{
    private readonly HttpClient _httpClient = null!;

    private static Dictionary<string, User> _cache = new Dictionary<string, User>();

    private const string BaseAddress = "https://www.duolingo.com/";

    public DuolingoClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(BaseAddress);
        _httpClient = httpClient;
    }

    private async Task<User?> GetUserData(Login loginData)
    {
        var userData = await _httpClient.GetAsync(string.Format("/users/{0}", loginData.Username));

        userData.EnsureSuccessStatusCode();

        var json = await userData.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<User>(json);
    }

    private async Task<Login?> Login(string username, string password)
    {
        var homePage = await _httpClient.GetAsync("/");

        homePage.EnsureSuccessStatusCode();

        var jsonString = string.Format(@"{{""login"":""{0}"",""password"":""{1}""}}", username, password);
        var loginResult = await _httpClient.PostAsync("/login", new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

        loginResult.EnsureSuccessStatusCode();

        var data = await loginResult.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Login>(data);
    }

    public async Task<User?> GetUser(string username, string password)
    {
        if (_cache.ContainsKey(username))
        {
            return _cache[username];
        }

        var loginData = await Login(username, password);

        if (loginData != null && !string.IsNullOrEmpty(loginData.Username))
        {
            var user = await GetUserData(loginData);

            if (user != null)
            {
                _cache.Add(username, user);
            }

            return user;
        }

        return null;
    }

}
