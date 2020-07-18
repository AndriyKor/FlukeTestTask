using Fluke.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public interface IEventsRepository
    {
        public Task<EventsAllDto> GetEventsAllAsync();
        public Task<EventDetailsDto> GetEventDetails(string Id);
    }
}
