using EF.Relationship.Application;
using EF.Relationship.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RelationshipDbContext>(option => option.UseSqlServer(builder.Configuration.GetSection("EFConnectionString").Value));

builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<PersonApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();