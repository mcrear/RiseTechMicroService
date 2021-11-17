using Microsoft.Extensions.Logging;
using RiseTech.BasicWeb.Extensions;
using RiseTech.BasicWeb.Models;
using RiseTech.BasicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiseTech.BasicWeb.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;

        public ContactService(HttpClient client, ILogger<ContactService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<PersonModel> CreatePerson(PersonModel model)
        {

            var response = await _client.PostAsJson($"/Contact", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<PersonModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<PersonModel>> GetPersons()
        {
            var response = await _client.GetAsync("/Contact");
            return await response.ReadContentAs<List<PersonModel>>();
        }

        public async Task<PersonModel> GetPerson(string id)
        {
            var response = await _client.GetAsync($"/Contact/{id}");
            return await response.ReadContentAs<PersonModel>();
        }

        public async Task<IEnumerable<PersonModel>> GetPersonByCompany(string company)
        {
            var response = await _client.GetAsync($"/Catalog/GetPersonByCompany/{company}");
            return await response.ReadContentAs<List<PersonModel>>();
        }

        public async Task<IEnumerable<PersonModel>> GetPersonByFirstName(string firstName)
        {
            var response = await _client.GetAsync($"/Catalog/GetPersonByFirstName/{firstName}");
            return await response.ReadContentAs<List<PersonModel>>();
        }

        public async Task<IEnumerable<PersonModel>> GetPersonByLastName(string lastName)
        {
            var response = await _client.GetAsync($"/Catalog/GetPersonByLastName/{lastName}");
            return await response.ReadContentAs<List<PersonModel>>();
        }
    }
}
