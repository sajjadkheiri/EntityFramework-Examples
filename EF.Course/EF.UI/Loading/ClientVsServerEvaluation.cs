using EF.DataAccess;

namespace EF.UI;

public class ClientVsServerEvaluation
{
    private readonly CourseStoreRepository _repository;

    public ClientVsServerEvaluation(CourseStoreRepository repository)
    {
        _repository = repository;
    }

    public void Execute()
    {
        var result = _repository.GetCourseTagsClientVsServer();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} : {item.Description}");
        }
    }
}
