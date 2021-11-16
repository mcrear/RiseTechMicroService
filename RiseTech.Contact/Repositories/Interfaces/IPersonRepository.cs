using RiseTech.Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseTech.Contact.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersons();
        Task<Person> GetPerson(string id);
        Task<IEnumerable<Person>> GetPersonByFirstName(string firstName);
        Task<IEnumerable<Person>> GetPersonByLastName(string lastName);
        Task<IEnumerable<Person>> GetPersonByCompany(string company);

        Task CreatePerson(Person product);
        Task<bool> UpdatePerson(Person product);
        Task<bool> DeletePerson(string id);
    }
}
