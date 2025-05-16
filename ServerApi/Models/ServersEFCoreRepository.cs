using Microsoft.EntityFrameworkCore;
using ServerApi.Data;

namespace ServerApi.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> _contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
            => _contextFactory = contextFactory;

        public List<Server> GetAllServers()
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public Server? GetServerById(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers.Find(id);
        }

        public List<Server> SearchServers(string filter)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers
                .Where(s => s.Name != null && s.Name.ToLower().Contains(filter.ToLower()))
                .ToList();
        }

        public List<Server> GetServersByCity(string city)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers
                .Where(s => s.City != null && s.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void AddServer(Server server)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public void UpdateServer(int id, Server server)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Servers.Update(server);
            db.SaveChanges();
        }

        public void DeleteServer(int id)
        {
            using var db = _contextFactory.CreateDbContext();
            var entity = new Server { ServerId = id };
            db.Attach(entity);
            db.Servers.Remove(entity);
            db.SaveChanges();
        }
    }
}
