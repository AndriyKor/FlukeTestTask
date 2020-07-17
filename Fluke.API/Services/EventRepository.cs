using Fluke.API.Models;
using Fluke.API.Models.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public class EventRepository : IEventsRepository
    {
        private readonly EONETConfiguration _config;

        public EventRepository(EONETConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetEventsAllAsync()
        {
            var client = new HttpClient();
            string result = string.Empty;
            HttpResponseMessage responce = await client.GetAsync(_config.Urls.Events);
            if (responce.IsSuccessStatusCode)
            {
                result = await responce.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}
