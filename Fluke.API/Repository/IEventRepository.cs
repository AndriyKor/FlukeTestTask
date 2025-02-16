using Fluke.Domain.Base;
using Fluke.Domain.Filters;

namespace Fluke.API.Repository
{
    public interface IEventRepository
    {
        public Task<IEnumerable<Event>> GetAllAsync();
        public Task<IEnumerable<Event>> GetAllAsync(OptionsModel options);
        public Task<Event> GetAsync(string Id);
    }
}
