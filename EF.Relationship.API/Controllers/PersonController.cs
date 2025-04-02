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

    [HttpGet("GetAll")]
    public IEnumerable<PersonOutputDto> GetAll()
    {
        return _personApplicationService.GetAll();
    }
    
    [HttpPost("Create")]
    public async Task<int> Add(PersonInputDto input)
    {
        return await _personApplicationService.AddPerson(input);
    }
}