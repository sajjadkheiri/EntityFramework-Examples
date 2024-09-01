using EF.DataAccess;

namespace EF.UI;

public class RelationalFixupFunctions
{
    private readonly CommentRepository _commentRepository;

    public RelationalFixupFunctions(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public void Run()
    {
        var withRelationalFixup = _commentRepository.GetCommentsByRelationalFixup(1);
        var withAsNoTracking = _commentRepository.GetCommentsByAsNoTracking(1);
    }
}
