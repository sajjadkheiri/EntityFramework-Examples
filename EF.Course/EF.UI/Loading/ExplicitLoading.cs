using EF.DataAccess;

namespace EF.UI;

public class ExplicitLoading
{
    private readonly CourseStoreRepository _repository;

    public ExplicitLoading(CourseStoreRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// According to the situation you want to load selected data
    /// Tip : to fetch data, you need to have round-trip from database for each object
    /// </summary>
    public void Run()
    {
        PrintCourseAndTeacher();
    }

    public void PrintCourseAndTeacher()
    {
        var courses = _repository.GetCourseAndTeacherExplicit();

        foreach (var course in courses)
        {
            Console.WriteLine($"Course : {course.Name}");

            foreach (var teacher in course.CourseTeachers)
            {
                Console.WriteLine($"-> Teacher : {teacher.Teacher.FirstName} {teacher.Teacher.LastName}");
            }
        }
    }
}
