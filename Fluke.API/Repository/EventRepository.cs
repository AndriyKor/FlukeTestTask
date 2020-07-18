using Fluke.API.Models;
using Fluke.API.Models.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fluke.API.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EONETConfiguration _config;

        public EventRepository(EONETConfiguration config)
        {
            _config = config;
        }

        public async Task<Event> GetAsync(string id)
        {
            var result = new Event();
            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(_config.Urls.Events + $"/{id}");
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Event>(content);
                }
            }
            return result;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            var result = new List<Event>();
            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(_config.Urls.Events);
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                    var eventsAll = JsonConvert.DeserializeObject<EventsAll>(content);
                    result = eventsAll.Events;
                }
            }
            return result;
        }
    }
}
