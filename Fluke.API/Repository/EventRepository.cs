using Fluke.Domain.Models;
using Fluke.Domain.Models.Options;
using Fluke.API.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<IEnumerable<Event>> GetAllAsync()
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

        public async Task<IEnumerable<Event>> GetAllAsync(OptionsModel options)
        {
            var result = new List<Event>();

            var validatedOptions = new OptionsModel
            {
                Days = Enumerable.Range(1, _config.MaxDays).Contains(options.Days) ? options.Days : _config.MaxDays,
                Limit = Enumerable.Range(1, _config.MaxLimit).Contains(options.Limit) ? options.Limit : _config.MaxLimit,
                OrderBy = options.OrderBy,
                Status = options.Status
            };

            var queryString = QueryHelper.BuildQueryString(validatedOptions);
            var requestUrl = _config.Urls.Events + (queryString == string.Empty ? string.Empty : "?" + queryString);
            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(requestUrl);
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
