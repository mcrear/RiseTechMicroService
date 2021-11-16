using MongoDB.Driver;
using RiseTech.Contact.Data.Interfaces;
using RiseTech.Contact.Entities;
using RiseTech.Contact.Enums;
using RiseTech.Contact.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiseTech.Contact.Repositories
{
    public class PersonInformationRepository : IPersonInformationRepository
    {
        private readonly IContactContext _context;
        public PersonInformationRepository(IContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<PersonInformation>> GetPersonInformationByContactType(ContactType contactType)
        {
            return await _context
                           .PersonInformations
                           .Find(p => p.ContactType == contactType)
                           .ToListAsync();
        }

        public async Task<IEnumerable<PersonInformation>> GetPersonInformationByPersonId(string Id)
        {
            return await _context
                           .PersonInformations
                           .Find(p => p.PersonId == Id)
                           .ToListAsync();
        }
    }
}
