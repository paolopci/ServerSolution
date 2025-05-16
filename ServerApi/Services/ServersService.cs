
using BlazorApp.Shared.Services;
using BlazorApp.Shared;
using ServerApi.Models;



namespace ServerApi.Services
{
    public class ServersService : IServersService
    {
        private readonly IServersEFCoreRepository _repo;
        public ServersService(IServersEFCoreRepository repo) => _repo = repo;


        public Task<IEnumerable<Server>> GetAllAsync()
        {
            return Task.FromResult(_repo.GetAllServers().AsEnumerable());
        }
    }
}
