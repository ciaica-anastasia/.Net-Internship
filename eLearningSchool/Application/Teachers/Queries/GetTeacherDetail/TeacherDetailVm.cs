using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Teachers.Queries.GetTeacherDetail
{
    public class TeacherDetailVm : IMapFrom<Teacher>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.TeacherId));
        }
    }
}