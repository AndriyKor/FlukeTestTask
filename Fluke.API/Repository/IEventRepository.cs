using Fluke.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Repository
{
    public interface IEventRepository
    {
        public Task<List<Event>> GetAllAsync();
        public Task<Event> GetAsync(string Id);
    }
}
