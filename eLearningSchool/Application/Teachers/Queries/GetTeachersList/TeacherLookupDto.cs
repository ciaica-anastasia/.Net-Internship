using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Teachers.Queries.GetTeachersList
{
    public class TeacherLookupDto : IMapFrom<Teacher>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.TeacherId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName));
        }
    }
}