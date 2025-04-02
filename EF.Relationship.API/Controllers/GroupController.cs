using EF.Relationship.Application;
using EF.Relationship.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EF.Relationship.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupApplicationService _groupApplicationService;

        public GroupController(GroupApplicationService groupApplicationService)
        {
            _groupApplicationService = groupApplicationService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<GroupOutputDto> GetAll()
        {
            return _groupApplicationService.GetAll();
        }
        
        [HttpGet("GetById/{id}")]
        public GroupOutputDto GetAll(int id)
        {
            return _groupApplicationService.GetById(id);
        }

        [HttpPost("Create")]
        public async Task<int> Add(GroupInputDto input)
        {
            return await _groupApplicationService.AddGroup(input);
        }
    }
}