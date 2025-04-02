using EF.Relationship.Domain.Model;
using EF.Relationship.Infrastructure.DTO;
using EF.Relationship.Infrastructure.Repository;

namespace EF.Relationship.Application;

public class GroupApplicationService
{
    private readonly GroupRepository _groupRepository;

    public GroupApplicationService(GroupRepository groupRepository)
    {
        _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    }

    public async Task<int> AddGroup(GroupInputDto input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var response = await _groupRepository.Add(new Group
            {
                Name = input.Name,
            }
        );

        return response;
    }

    public List<GroupOutputDto> GetAll()
    {
        var response = new List<GroupOutputDto>();

        var groups = _groupRepository.GetAll();

        if (groups.Count > default(int))
        {
            foreach (var group in groups)
            {
                response.Add(new GroupOutputDto
                {
                    Id = group.Id,
                    Name = group.Name,
                    CreationDate = group.CreationDate,
                });
            }
        }

        return response;
    }

    public GroupOutputDto GetById(int id)
    {
        var response = new GroupOutputDto();

        var group = _groupRepository.GetById(id);

        if (group.Id > default(int))
        {
            response.Id = group.Id;
            response.Name = group.Name;
            response.CreationDate = group.CreationDate;
        }

        return response;
    }
}