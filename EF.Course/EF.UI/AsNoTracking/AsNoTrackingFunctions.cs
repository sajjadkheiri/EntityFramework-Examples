using EF.DataAccess;
using EF.Entities;

namespace EF.UI;

public class AsNoTrackingFunctions
{
    private readonly CourseStoreRepository _repository;

    public AsNoTrackingFunctions(CourseStoreRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void WithAsNoTracking()
    {
        var courses = _repository.GetWithAsNoTracking();

        if (courses is null)
            throw new NullReferenceException();

        var course1 = courses.FirstOrDefault(x => x.Id == 1).CourseTeachers
                             .FirstOrDefault().Teacher;

        var course2 = courses.FirstOrDefault(x => x.Id == 2).CourseTeachers
                             .FirstOrDefault().Teacher;

        var course3 = courses.FirstOrDefault(x => x.Id == 3).CourseTeachers
                             .FirstOrDefault().Teacher;

        Console.WriteLine(object.ReferenceEquals(course1,course2));
        Console.WriteLine(object.ReferenceEquals(course1,course3));
        Console.WriteLine(object.ReferenceEquals(course2,course3));
    }

    public void WithAsNoTrackingWithIdentityResolution()
    {
        var courses = _repository.GetWithAsNoTrackingWithIdentityResolution();

        if (courses is null)
            throw new NullReferenceException();

        var course1 = courses.FirstOrDefault(x => x.Id == 1).CourseTeachers
                             .FirstOrDefault().Teacher;

        var course2 = courses.FirstOrDefault(x => x.Id == 2).CourseTeachers
                             .FirstOrDefault().Teacher;

        var course3 = courses.FirstOrDefault(x => x.Id == 3).CourseTeachers
                             .FirstOrDefault().Teacher;

        Console.WriteLine(object.ReferenceEquals(course1,course2));
        Console.WriteLine(object.ReferenceEquals(course1,course3));
        Console.WriteLine(object.ReferenceEquals(course2,course3));
    }
}
