using Fluke.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Repository
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> GetAllAsync();
        public Task<IEnumerable<Event>> GetAllAsync(OptionsModel options);
        public Task<Event> GetAsync(string Id);
    }
}
