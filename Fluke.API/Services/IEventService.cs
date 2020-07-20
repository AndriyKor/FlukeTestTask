using Fluke.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public interface IEventService
    {
        public Task<EventDto> Get(string id);
        public Task<List<EventDto>> GetAll();
        public Task<List<EventDto>> GetAll(string orderBy, FilterModel filter);
    }
}
