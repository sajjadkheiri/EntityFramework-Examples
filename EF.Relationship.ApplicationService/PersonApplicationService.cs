using EF.Relationship.Domain.Model;
using EF.Relationship.Infrastructure.DTO;
using EF.Relationship.Infrastructure.Repository;

namespace EF.Relationship.Application;

public class PersonApplicationService
{
    private readonly PersonRepository _personRepository;

    public PersonApplicationService(PersonRepository personRepository)
    {
        _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
    }

    public async Task<int> AddPerson(PersonInputDto input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var response = await _personRepository.Add(new Person
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                BirthDate = input.BirthDate,
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
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate
                });
            }
        }

        return response;
    }
}