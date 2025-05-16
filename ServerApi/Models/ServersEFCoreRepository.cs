using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using ServerApi.Data;

namespace ServerApi.Models
{
    public class ServersEFCoreRepository:IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> _contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
            => _contextFactory = contextFactory;

        public List<Server> GetAllServers(CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Servers.AsNoTracking().ToList();
        }
    }


}
