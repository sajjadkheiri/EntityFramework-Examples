using EF.Relationship.Application;
using EF.Relationship.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RelationshipDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetSection("EFConnectionString").Value));

builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<GroupRepository>();

builder.Services.AddScoped<PersonApplicationService>();
builder.Services.AddScoped<GroupApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
//    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();