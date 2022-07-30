using Duolingonator.Models;

namespace Duolingonator.Profiles;

public class DuolingoProfile : AutoMapper.Profile
{
    public DuolingoProfile()
    {
        CreateMap<Duolingo.NET.Models.Language, Language>();
        CreateMap<Duolingo.NET.Models.LanguageData, ActiveLanguage>();
        CreateMap<Duolingo.NET.Models.Skill, Skill>();

        CreateMap<Duolingo.NET.Models.Calendar, Calendar>()
            .ForMember(a => a.DateTime, g => g.MapFrom(a => DateTimeOffset.FromUnixTimeMilliseconds(a.DateTime)));

        CreateMap<Duolingo.NET.Models.User, Profile>()
            .ForMember(a => a.CreatedAt, g => g.MapFrom(a => DateTimeOffset.FromUnixTimeMilliseconds(a.CreatedDate)))
            .ForMember(a => a.Followers, g => g.MapFrom(a => a.TrackingProperties.NumFollowers))
            .ForMember(a => a.Streak, g => g.MapFrom(a => a.SiteStreak));

    }
}