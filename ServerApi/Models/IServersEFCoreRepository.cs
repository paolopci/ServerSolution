using BlazorApp.Shared;


namespace ServerApi.Models
{
    public interface IServersEFCoreRepository
    {
        List<Server> GetAllServers(CancellationToken cancellationToken = default);
        //Server? GetServerById(int id);
        //List<Server> SearchServers(string filter);
        //List<Server> GetServersByCity(string city);
        //void AddServer(Server server);
        //void UpdateServer(int id, Server server);
        //void DeleteServer(int id);
    }
}
