using MHWEntity.Enumerations;

namespace MHWEntity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public TeachingMode ModeOfTeaching { get; set; }
    }
}