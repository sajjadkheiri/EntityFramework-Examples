using EF.Relationship.Application;
using EF.Relationship.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EF.Relationship.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonApplicationService _personApplicationService;

    public PersonController(PersonApplicationService personApplicationService)
    {
        _personApplicationService = personApplicationService;
    }

    [HttpGet(Name = "GetPeople")]
    public IEnumerable<PersonOutputDto> GetAll()
    {
        return _personApplicationService.GetAll();
    }
    
    [HttpPost(Name = "AddPeople")]
    public int Add(PersonInputDto input)
    {
        return _personApplicationService.AddPerson(input);
    }
}