using MediatR;

namespace Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<string>
    {
        public int Capacity { get; set; }
        public string Schedule { get; set; }
        public int LevelId { get; set; }
        public int? TeacherId { get; set; }
        public int LanguageId { get; set; }
        public string Duration { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? PrerequisiteId { get; set; }
        public int? AgeId { get; set; }
        public string Purpose { get; set; }
    }
}