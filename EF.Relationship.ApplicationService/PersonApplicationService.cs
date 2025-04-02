using EF.Relationship.Domain.Model;
using EF.Relationship.Infrastructure.DTO;
using EF.Relationship.Infrastructure.Repository;

namespace EF.Relationship.Application;

public class PersonApplicationService
{
    private readonly PersonRepository _personRepository;
    private readonly GroupRepository _groupRepository;

    public PersonApplicationService(PersonRepository personRepository, GroupRepository groupRepository)
    {
        _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
    }

    public async Task<int> AddPerson(PersonInputDto input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var groups = _groupRepository.GetById(input.GroupId);

        if (groups == null)
        {
            throw new ApplicationException($"Group with id {input.GroupId} not found");
        }

        var response = await _personRepository.Add(new Person
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                BirthDate = input.BirthDate,
                GroupId = input.GroupId
            }
        );

        return response;
    }

    public List<PersonOutputDto> GetAll()
    {
        var response = new List<PersonOutputDto>();

        var people = _personRepository.GetAll();

        if (people.Count > default(int))
        {
            foreach (var person in people)
            {
                response.Add(new PersonOutputDto
                {
                    Id = person.Id,
                    GroupId = person.GroupId,
                    LastName = person.LastName,
                    FirstName = person.FirstName,
                    BirthDate = person.BirthDate,
                });
            }
        }

        return response;
    }
}