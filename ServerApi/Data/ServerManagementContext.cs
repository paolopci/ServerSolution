using Microsoft.EntityFrameworkCore;
using ServerApi.Models;


namespace ServerApi.Data
{
    public class ServerManagementContext : DbContext
    {
        public ServerManagementContext(DbContextOptions<ServerManagementContext> options) : base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasData(
                new Server { ServerId = 1, Name = "Server1", City = "Rome", IsOnline = true },
                new Server { ServerId = 2, Name = "Server2", City = "Milan", IsOnline = false },
                // altri seed...
                new Server { ServerId = 15, Name = "Server15", City = "Halifax", IsOnline = true }
            );
        }
    }
}
