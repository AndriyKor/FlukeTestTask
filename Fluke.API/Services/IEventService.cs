using Fluke.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public interface IEventService
    {
        public Task<EventDto> Get(string id);
        public Task<IEnumerable<EventDto>> GetAll();
        public Task<IEnumerable<EventDto>> GetList(FilterModel filter, OptionsModel options);
    }
}
