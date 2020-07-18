using Fluke.API.Mappers;
using Fluke.API.Models;
using Fluke.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<EventDto>> GetAll()
        {
            var result = await _eventRepository.GetAllAsync();
            return result.Select(e => e.MapToDto()).ToList();
        }
    }
}
