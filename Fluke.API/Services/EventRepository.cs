using Fluke.API.Models;
using Fluke.API.Models.Extentions;
using Fluke.API.Models.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        public async Task<EventDetailsDto> GetEventDetails(string id)
        {
            var client = new HttpClient();
            var result = new EventDetailsDto();

            HttpResponseMessage responce = await client.GetAsync(_config.Urls.Events + $"/{id}");
            if (responce.IsSuccessStatusCode)
            {
                var resp = await responce.Content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<EventDetails>(resp);
                result = parsed.MapToDto();
            }
            return result;
        }

        public async Task<EventsAllDto> GetEventsAllAsync()
        {
            var client = new HttpClient();
            var result = new EventsAllDto();

            HttpResponseMessage responce = await client.GetAsync(_config.Urls.Events);
            if (responce.IsSuccessStatusCode)
            {
                var resp = await responce.Content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<EventsAll>(resp);
                result = parsed.MapToDto();
            }
            return result;
        }

        
    }
}
