using EF.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EF.UI;

public class UpdateEntityFunctions
{
    private CourseDbContext _dbContext;
    private CourseStoreCommandRepository _repository;

    private UpdateEntityFunctions()
    {
        var optionBuilder = new DbContextOptionsBuilder<CourseDbContext>();
        optionBuilder.UseSqlServer("Server =.;Database=CourseDb;User Id=sa;Password=1qaz@WSX;TrustServerCertificate=True");

        _dbContext = new CourseDbContext(optionBuilder.Options);
        _repository = new CourseStoreCommandRepository(_dbContext);
    }

    public void RunConnectedUpdate()
    {
        _repository.UpdateTagConnected(1,"ASP.NET Core 6");
    }

    public void RunDisconnectedUpdate()
    {
        int tagId = 1;
        string tagName = _repository.GetTagName(tagId);

        _repository.UpdateTagDisconnected(tagId, tagName);
    }

    /// <summary>
    /// The difference with ConnectedUpdate is that EF identify that which field have changed.
    /// As you can see in the SaveCourse method, There are 2 fields for update. Name and description
    /// EF identify that It must just modify Description because Name doesn't have any changes
    /// </summary>
    public void RunDtoUpdate()
    {
        _repository.UpdateTagConnected(1, "ASP.NET Core 6");

        var dto = _repository.GetCourse(1);

        dto.Description = "Update description for Pro .Net Ecosystem";

        _repository.SaveCourse(dto);
    }
}
