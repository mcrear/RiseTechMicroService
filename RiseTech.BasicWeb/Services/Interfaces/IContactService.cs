using RiseTech.BasicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseTech.BasicWeb.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<PersonModel>> GetCatalog();
        Task<IEnumerable<PersonModel>> GetPersonByCompany(string company);
        Task<IEnumerable<PersonModel>> GetPersonByFirstName(string firstName);
        Task<IEnumerable<PersonModel>> GetPersonByLastName(string lastName);
        Task<PersonModel> GetPerson(string id);
        Task<PersonModel> CreatePerson(PersonModel model);
    }
}
