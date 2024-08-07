using EF.DataAccess;
using EF.UI;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
optionsBuilder.UseSqlServer("Server =.;Database=CourseDb;User Id=sa;Password=Str0ngPa$$w0rd;TrustServerCertificate=True");

CourseDbContext courseDbContext = new(optionsBuilder.Options);
CourseStoreRepository courseStoreRepository = new(courseDbContext);

#region EagerLoading

EagerLoading eagerLoading = new(courseStoreRepository);

eagerLoading.Run();

#endregion

#region Explicit Loading

ExplicitLoading explicitLoading = new(courseStoreRepository);

explicitLoading.Run();

#endregion

#region Select Loading

SelectLoading selectLoading = new(courseStoreRepository);

selectLoading.Run();

#endregion