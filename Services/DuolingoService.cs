using Duolingo.NET;
using Duolingonator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Duolingonator.Services;

public class DuolingoService
{
    private readonly DuolingoClient _client;

    private readonly AutoMapper.IMapper _mapper;

    private readonly IMemoryCache _memoryCache;

    private static bool RequestRunning = false;

    public DuolingoService(
        DuolingoClient client, AutoMapper.IMapper mapper, IMemoryCache memoryCache)
    {
        _client = client;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<Profile> GetProfile(string username, string password)
    {
        var user = await this.GetUserAsync(username, password).ConfigureAwait(false);

        return this._mapper.Map<Profile>(user);
    }

    public async Task<IEnumerable<Language>> GetLanguages(string username, string password)
    {
        var user = await this.GetUserAsync(username, password).ConfigureAwait(false);

        return user.Languages
            .Where(t => t.Points > 0)
            .Select(t => this._mapper.Map<Language>(t));
    }

    public async Task<ActiveLanguage> GetActiveLanguage(string username, string password)
    {
        var user = await this.GetUserAsync(username, password);

        return user != null && user.LanguageData.Count() > 0 ?
        this._mapper.Map<ActiveLanguage>(user.LanguageData.FirstOrDefault().Value)
        : throw new Exception();

    }

    private async Task<Duolingo.NET.Models.User> GetUserAsync(string username, string password)
    {
        await WaitForRunningRequestAsync(username).ConfigureAwait(false);
        RequestRunning = true;

        try
        {
            if (_memoryCache.TryGetValue(username, out Duolingo.NET.Models.User cacheValue))
            {
                return cacheValue;
            }

            var user = await this._client.GetUser(username, password).ConfigureAwait(false);
            cacheValue = user ?? throw new NullReferenceException("User is null");

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(900));

            _memoryCache.Set(username, cacheValue, cacheEntryOptions);

            return cacheValue;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            RequestRunning = false;
        }
    }

    private async Task WaitForRunningRequestAsync(string username)
    {
        while (RequestRunning)
        {
            await Task.Delay(1000).ConfigureAwait(false);
        }
    }
}
