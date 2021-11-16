using MongoDB.Driver;
using RiseTech.Contact.Entities;
using RiseTech.Contact.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiseTech.Contact.Data
{
    public class ContactContextSeed
    {
        public static void SeedData(IMongoCollection<Person> personCollection, IMongoCollection<PersonInformation> personInformationCollection)
        {
            bool existPerson = personCollection.Find(p => true).Any();
            if (!existPerson)
            {
                personCollection.InsertManyAsync(GetPreconfiguredPersons());
            }

            bool existPersonInformation = personInformationCollection.Find(p => true).Any();
            if (!existPersonInformation)
            {
                personInformationCollection.InsertManyAsync(GetPreconfiguredPersonInformations());
            }
        }

        private static IEnumerable<Person> GetPreconfiguredPersons()
        {
            return new List<Person>()
            {
                new Person()
                {
                  Id = "602d2149e773f2a3990b47f5",
                  FirstName="Ahmet",
                  LastName="Aydeniz",
                  Company="Sipay"
                },
                new Person()
                {
                  Id = "602d2149e773f2a3990b47fa",
                  FirstName="Alper",
                  LastName="Yazır",
                  Company="Sipay"
                }
            };
        }

        private static IEnumerable<PersonInformation> GetPreconfiguredPersonInformations()
        {
            return new List<PersonInformation>()
            {
                new PersonInformation()
                {
                  Id = "602d2149e773f2a3990b47f7",
                  PersonId="602d2149e773f2a3990b47fa",
                  ContactType=ContactType.Konum,
                  Description="Gaziosmanpaşa"
                },
                new PersonInformation()
                {
                  Id = "602d2149e773f2a3990b47f8",
                  PersonId="602d2149e773f2a3990b47f5",
                  ContactType=ContactType.Konum,
                  Description="Şişli"
                },
                new PersonInformation()
                {
                  Id = "602d2149e773f2a3990b47f6",
                  PersonId="602d2149e773f2a3990b47f5",
                  ContactType=ContactType.TelefonNumarası,
                  Description="123 123 12 12"
                },
                new PersonInformation()
                {
                  Id = "602d2149e773f2a3990b47f9",
                  PersonId="602d2149e773f2a3990b47f5",
                  ContactType=ContactType.Email,
                  Description="seed@data.com"
                }
            };
        }
    }
}
