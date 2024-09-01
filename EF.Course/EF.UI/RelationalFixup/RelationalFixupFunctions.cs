using EF.DataAccess;

namespace EF.UI;

public class RelationalFixupFunctions
{
    private readonly CourseStoreRepository _courseStoreRepository;

    public RelationalFixupFunctions(CourseStoreRepository courseStoreRepository)
    {
        _courseStoreRepository = courseStoreRepository;
    }

    public void Run()
    {
        var withRelationalFixup = _courseStoreRepository.GetCommentsByRelationalFixup(1);
        var withAsNoTracking = _courseStoreRepository.GetCommentsByAsNoTracking(1);
    }
}
