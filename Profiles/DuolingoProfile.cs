using AutoMapper;
using Duolingonator.Models;

namespace Duolingonator.Profiles;

public class DuolingoProfile : Profile
{
    public DuolingoProfile()
    {
        CreateMap<Duolingo.NET.Models.Language, Language>();
        CreateMap<Duolingo.NET.Models.LanguageData, LanguageData>();
        CreateMap<Duolingo.NET.Models.Skill, Skill>();

        CreateMap<Duolingo.NET.Models.Calendar, Calendar>()
            .ForMember(a => a.DateTime, g => g.MapFrom(a => DateTimeOffset.FromUnixTimeMilliseconds(a.DateTime)));
    }
}