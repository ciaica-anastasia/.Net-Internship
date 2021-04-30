using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.StudentCourseStatuses.Queries.GetStudentCourseStatusesList
{
    public class StudentCourseStatusDto : IMapFrom<StudentCourseStatus>
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentCourseStatus, StudentCourseStatusDto>()
                .ForMember(d => d.StatusId, opt => opt.MapFrom(s => s.StudentCourseStatusId))
                .ForMember(d => d.StatusName, opt => opt.MapFrom(s => s.StudentCourseStatusName));
        }
    }
}