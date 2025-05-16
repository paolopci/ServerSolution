namespace BlazorApp.Shared.Services
{
    public interface IServersService
    {
        Task<IEnumerable<Server>> GetAllAsync();
        //Task<Server?> GetByIdAsync(int id);
        //Task<Server> CreateAsync(Server server);
        //Task UpdateAsync(int id, Server server);
        //Task DeleteAsync(int id);
    }

}
