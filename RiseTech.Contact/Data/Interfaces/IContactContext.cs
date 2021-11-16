using MongoDB.Driver;
using RiseTech.Contact.Entities;

namespace RiseTech.Contact.Data.Interfaces
{
    public interface IContactContext
    {
        IMongoCollection<Person> Persons { get; }
        IMongoCollection<PersonInformation> PersonInformations { get; }
    }
}
