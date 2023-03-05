using System.Net.Http.Headers;
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

        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/users/{username}");
        requestMessage.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", jwt);

        using var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        using var content = response.Content;
        return await content.ReadFromJsonAsync<User>().ConfigureAwait(false);
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
