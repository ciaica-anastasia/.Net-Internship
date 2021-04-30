using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Students.Queries.GetStudentsList
{
    public class StudentLookupDto : IMapFrom<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.StudentId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LastName + ", " + s.FirstName));
        }
    }
}