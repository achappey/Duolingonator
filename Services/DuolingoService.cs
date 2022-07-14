using Duolingo.NET;
using AutoMapper;
using Duolingonator.Models;

namespace Duolingonator.Services;

public class DuolingoService
{
    private readonly DuolingoClient _client;
    private readonly IMapper _mapper;

    public DuolingoService(
        DuolingoClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Language>> GetLanguages(string username, string password)
    {
        var user = await this._client.GetUser(username, password);

        return user != null ?
        user.Languages
        .Where(t => t.Points > 0)
        .Select(t => this._mapper.Map<Language>(t))
        : throw new Exception();
    }

    public async Task<LanguageData> GetLanguageData(string username, string password)
    {
        var user = await this._client.GetUser(username, password);

        return user != null && user.LanguageData.Count() > 0 ?
        this._mapper.Map<LanguageData>(user.LanguageData.FirstOrDefault().Value)
        : throw new Exception();
    }
}
