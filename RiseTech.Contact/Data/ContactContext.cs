using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RiseTech.Contact.Data.Interfaces;
using RiseTech.Contact.Entities;

namespace RiseTech.Contact.Data
{
    public class ContactContext : IContactContext
    {
        public ContactContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Persons = database.GetCollection<Person>(configuration.GetValue<string>("Persons"));
            PersonInformations = database.GetCollection<PersonInformation>(configuration.GetValue<string>("PersonInformations"));
            ContactContextSeed.SeedData(Persons, PersonInformations);
        }

        public IMongoCollection<Person> Persons { get; }
        public IMongoCollection<PersonInformation> PersonInformations { get; }
    }
}
