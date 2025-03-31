using Fluke.Domain.Models.Options;
using Fluke.API.Helpers;
using Newtonsoft.Json;
using Fluke.Domain.Base;
using Fluke.Domain.Filters;
using Microsoft.Extensions.Options;

namespace Fluke.API.Repository
{
    public class EventRepository(IOptions<EONETConfiguration> config) : IEventRepository
    {
        private readonly EONETConfiguration _config = config.Value;

        public async Task<Event> GetAsync(string id)
        {
            var result = new Event();
            using var client = new HttpClient();
            
            var url = _config.Urls.Events + $"/{id}";
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) 
                return result;
            
            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<Event>(content);

            return result;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var result = new List<Event>();
            
            using var client = new HttpClient();
            
            var response = await client.GetAsync(_config.Urls.Events);
            if (!response.IsSuccessStatusCode) 
                return result;
            
            var content = await response.Content.ReadAsStringAsync();
            var eventsAll = JsonConvert.DeserializeObject<EventsAll>(content);
            result = eventsAll?.Events ?? [];

            return result;
        }

        public async Task<IEnumerable<Event>> GetAllAsync(OptionsModel options)
        {
            var result = new List<Event>();

            var validatedOptions = new OptionsModel
            {
                Days = options.Days != null && Enumerable.Range(1, _config.MaxDays).Contains(options.Days.Value) ? options.Days : _config.MaxDays,
                Limit = options.Limit != null && Enumerable.Range(1, _config.MaxLimit).Contains(options.Limit.Value) ? options.Limit : _config.MaxLimit,
                OrderBy = options.OrderBy,
                Status = options.Status
            };

            var queryString = QueryHelper.BuildQueryString(validatedOptions);
            var requestUrl = _config.Urls.Events + (queryString == string.Empty ? string.Empty : "?" + queryString);
            
            using var client = new HttpClient();
            var response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var eventsAll = JsonConvert.DeserializeObject<EventsAll>(content);
                result = eventsAll?.Events ?? [];
            }

            return result;
        }
    }
}
