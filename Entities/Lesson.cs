namespace Entities
{
    public class Lesson
    {
        public string Subject { get; set; }
        public int TeacherID { get; set; }
        public string TeacherFullName { get; set; }
        public int ClassNum { get; set; }
        public DayOfWeek Day { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }

    }
}
