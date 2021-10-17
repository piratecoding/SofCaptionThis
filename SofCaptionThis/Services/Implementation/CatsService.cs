using SofCaptionThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SofCaptionThis.Services.Implementation
{
    public class CatsService : ICatsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        const string BaseUri = "https://api.thecatapi.com/v1/images/search";

        public CatsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Cat> GetCat()
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.GetFromJsonAsync<IEnumerable<Cat>>("search");

            return response.FirstOrDefault();
        }

        public async Task<Cat> GetCatById(string id)
        {
            var client = _httpClientFactory.CreateClient("API");

            var response = await client.GetFromJsonAsync<Cat>(id);

            return response;
        }
    }
}
