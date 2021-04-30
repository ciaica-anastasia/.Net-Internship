namespace Domain.Entities
{
    public class StudentLevel
    {
        public int StudentId { get; set; }
        public int LevelId { get; set; }
        public int LanguageId { get; set; }

        public Student Student { get; set; }
        public Level Level { get; set; }
        public Language Language { get; set; }
    }
}