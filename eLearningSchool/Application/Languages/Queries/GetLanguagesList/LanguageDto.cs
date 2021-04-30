using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Languages.Queries.GetLanguagesList
{
    public class LanguageDto : IMapFrom<Language>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Language, LanguageDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.LanguageId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LanguageName));
        }
    }
}