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

    private async Task<User?> GetUserData(string username, string jwt)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwt);

        return await _httpClient.GetFromJsonAsync<User>(
            string.Format("/users/{0}", username));
    }

    public async Task<User?> GetUser(string username, string password)
    {
        return await GetUserData(username, password);
    }
}

public class DuolingoAuth
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
