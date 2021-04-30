using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Courses.Queries.GetCoursesList
{
    public class CourseDto : IMapFrom<Course>
    {
        public string CourseId { get; set; }
        public int Capacity { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? Prerequisite { get; set; }
        public string PrerequisiteLevelName { get; set; } 
        public int? AgeId { get; set; }
        public string AgeRangeName { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseDto>()
                .ForMember(d => d.LevelName, opt => opt.MapFrom(s => s.Level.LevelName))
                .ForMember(d => d.LanguageName, opt => opt.MapFrom(s => s.Language.LanguageName))
                .ForMember(d => d.PrerequisiteLevelName,
                    opt => opt.MapFrom(s => s.PrerequisiteLevel != null ? s.PrerequisiteLevel.LevelName : string.Empty))
                .ForMember(d => d.AgeRangeName,
                    opt => opt.MapFrom(s => s.Age != null ? s.Age.AgeRangeName : string.Empty));
        }
    }
}