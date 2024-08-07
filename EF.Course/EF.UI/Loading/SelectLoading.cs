using EF.DataAccess;

namespace EF.UI;

public class SelectLoading
{
    private readonly CourseStoreRepository _repository;

    public SelectLoading(CourseStoreRepository repository)
    {
        _repository = repository;
    }

    public void Run()
    {
        PrintCourseInfo();
    }

    public void PrintCourseInfo()
    {
        var courseInfo = _repository.GetCourseInfoSelect();

        foreach (var course in courseInfo)
        {
            Console.WriteLine($"Course Id : {course.Id}");
            Console.WriteLine($"Course Name : {course.Name}");
        }
    }
}
