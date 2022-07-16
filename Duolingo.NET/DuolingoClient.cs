using Duolingo.NET.Models;

namespace Duolingo.NET;

public class DuolingoClient
{
    private readonly HttpClient _httpClient = null!;

    private const string BaseAddress = "https://www.duolingo.com/";

    public DuolingoClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(BaseAddress);
        _httpClient = httpClient;
    }

    private async Task<User?> GetUserData(Login loginData)
    {
        return await _httpClient.GetFromJsonAsync<User>(
            string.Format("/users/{0}", loginData.Username));
    }

    private async Task<Login?> Login(string username, string password)
    {
        var loginResult = await _httpClient.PostAsJsonAsync<DuolingoAuth>("/login",
        new DuolingoAuth()
        {
            Login = username,
            Password = password
        });

        loginResult.EnsureSuccessStatusCode();

        return await loginResult.Content.ReadFromJsonAsync<Login>();
    }

    public async Task<User?> GetUser(string username, string password)
    {
        var loginData = await Login(username, password);

        if (loginData != null && !string.IsNullOrEmpty(loginData.Username))
        {
            return await GetUserData(loginData);
        }

        throw new NotSupportedException();
    }
}

public class DuolingoAuth
{
    public string Login { get; set; } = null!;
    
    public string Password { get; set; } = null!;
}
