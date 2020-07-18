using Fluke.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public interface IEventService
    {
        public Task<EventDto> Get(string id);
        public Task<List<EventDto>> GetAll();
    }
}
