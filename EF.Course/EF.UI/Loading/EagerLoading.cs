using EF.DataAccess;

namespace EF.UI;

public class EagerLoading
{
    private readonly CourseStoreRepository _repository;

    /// <summary>
    /// You can load all of data with relationships
    /// Tip : You have to remember to call .Include() to query related entities. If you forget to do this, your code will keep working
    /// </summary>
    public EagerLoading(CourseStoreRepository repository)
    {
        _repository = repository;
    }

    public void Run()
    {
        PrintCourseAndTeacher();
        PrintCourseAndTeacherAndTag();
    }

    public void PrintCourseAndTeacher()
    {
        var courses = _repository.GetCourseAndTeacherEager();

        foreach (var course in courses)
        {
            Console.WriteLine($"Course : {course.Name}");

            foreach (var teacher in course.CourseTeachers)
            {
                Console.WriteLine($"-> Teacher : {teacher.Teacher.FirstName} {teacher.Teacher.LastName}");
            }
        }
    }

    public void PrintCourseAndTeacherAndTag()
    {
        var courses = _repository.GetCourseAndTeacherEager();

        foreach (var course in courses)
        {
            Console.WriteLine($"Course : {course.Name}");

            foreach (var teacher in course.CourseTeachers)
            {
                Console.WriteLine($"-> Teacher : {teacher.Teacher.FirstName} {teacher.Teacher.LastName}");
            }

            foreach (var tag in course.Tags)
            {
                Console.WriteLine($"--> Tag : {tag.Name}");
            }
        }
    }
}
