namespace EntityFramework.Entities;

public class CourseTeachers
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public Teacher Teacher { get; set; }
}
