using Fluke.API.Extensions;
using Fluke.API.Mappers;
using Fluke.Domain.Models;
using Fluke.API.Repository;
using Fluke.Domain.Filters;

namespace Fluke.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventDto> Get(string id)
        {
            var result = await _eventRepository.GetAsync(id);
            return result.MapToDto();
        }

        public async Task<IEnumerable<EventDto>> GetAll()
        {
            var result = await _eventRepository.GetAllAsync();
            return result.Select(e => e.MapToDto()).ToList();
        }

        public async Task<IEnumerable<EventDto>> GetList(FilterModel filter, OptionsModel options)
        {
            var events = await _eventRepository.GetAllAsync(options);
            var result = events.Select(e => e.MapToDto());

            if (filter.Category != null)
                result = result.Where(r => r.Category == filter.Category);

            if (filter.Date > DateTime.MinValue)
                result = result.Where(r => r.Date.Date == filter.Date.Value.Date);

            if (options.OrderBy != null)
                result = result.AsQueryable().OrderBy(options.OrderBy);

            return result.ToList();
        }
    }
}
