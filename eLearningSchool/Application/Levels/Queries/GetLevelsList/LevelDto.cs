using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Levels.Queries.GetLevelsList
{
    public class LevelDto : IMapFrom<Level>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Level, LevelDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.LevelId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LevelName));
        }
    }
}