using Duolingo.NET;
using AutoMapper;
using Duolingonator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Duolingonator.Services;

public class DuolingoService
{
    private readonly DuolingoClient _client;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public DuolingoService(
        DuolingoClient client, IMapper mapper, IMemoryCache memoryCache)
    {
        _client = client;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Language>> GetLanguages(string username, string password)
    {
        var user = await this.GetUser(username, password);

        return user.Languages
            .Where(t => t.Points > 0)
            .Select(t => this._mapper.Map<Language>(t));
    }

    public async Task<ActiveLanguage> GetLanguageData(string username, string password)
    {
        var user = await this.GetUser(username, password);

        return user != null && user.LanguageData.Count() > 0 ?
        this._mapper.Map<ActiveLanguage>(user.LanguageData.FirstOrDefault().Value)
        : throw new Exception();
    }

    private async Task<Duolingo.NET.Models.User> GetUser(string username, string password)
    {
        if (!_memoryCache.TryGetValue(username, out Duolingo.NET.Models.User cacheValue))
        {
            var user = await this._client.GetUser(username, password);

            cacheValue = user != null ? user : throw new Exception();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(900));

            _memoryCache.Set(username, cacheValue, cacheEntryOptions);

            return cacheValue;
        }
        else
        {
            return cacheValue;
        }
    }
}
