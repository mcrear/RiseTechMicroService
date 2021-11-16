using MongoDB.Driver;
using RiseTech.Contact.Data.Interfaces;
using RiseTech.Contact.Entities;
using RiseTech.Contact.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseTech.Contact.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IContactContext _context;
        public PersonRepository(IContactContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task CreatePerson(Person person)
        {
            await _context.Persons.InsertOneAsync(person);
        }

        public async Task<bool> DeletePerson(string id)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Persons
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Person> GetPerson(string id)
        {
            return await _context
                              .Persons
                              .Find(p => p.Id == id)
                              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonByCompany(string company)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.ElemMatch(p => p.Company, company);

            return await _context
                            .Persons
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonByFirstName(string firstName)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.ElemMatch(p => p.FirstName, firstName);

            return await _context
                            .Persons
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonByLastName(string lastName)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.ElemMatch(p => p.LastName, lastName);

            return await _context
                            .Persons
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context
                             .Persons
                             .Find(p => true)
                             .ToListAsync();
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            var updateResult = await _context
                                        .Persons
                                        .ReplaceOneAsync(filter: g => g.Id == person.Id, replacement: person);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
