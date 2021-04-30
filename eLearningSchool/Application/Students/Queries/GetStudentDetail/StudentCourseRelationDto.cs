using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Students.Queries.GetStudentDetail
{
    public class StudentCourseRelationDto : IMapFrom<StudentCourseRelation>
    {
        public int CourseId { get; set; }
        public bool Approved { get; set; }
        public string StudentCourseStatusName { get; set; }
        public string CourseLevel { get; set; }
        public string CourseLanguage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentCourseRelation, StudentCourseRelationDto>()
                .ForMember(d => d.CourseId, opts => opts.MapFrom(s => s.CourseId))
                .ForMember(d => d.Approved, opts => opts.MapFrom(s => s.Approved))
                .ForMember(d => d.StudentCourseStatusName,
                    opts => opts.MapFrom(s => s.StudentCourseStatus.StudentCourseStatusName))
                .ForMember(d => d.CourseLevel, opts => opts.MapFrom(s => s.Course.Level.LevelName))
                .ForMember(d => d.CourseLanguage, opts => opts.MapFrom(s => s.Course.Language.LanguageName));
        }
    }
}