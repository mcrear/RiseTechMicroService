using RiseTech.Contact.Entities;
using RiseTech.Contact.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiseTech.Contact.Repositories.Interfaces
{
    public interface IPersonInformationRepository
    {
        Task<IEnumerable<PersonInformation>> GetPersonInformationByPersonId(string Id);
        Task<IEnumerable<PersonInformation>> GetPersonInformationByContactType(ContactType contactType);
    }
}
