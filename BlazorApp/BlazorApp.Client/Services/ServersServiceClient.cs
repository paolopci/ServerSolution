using System.Net.Http.Json;
using BlazorApp.Shared;
using BlazorApp.Shared.Services;


namespace BlazorApp.Client.Services
{
    public class ServersServiceClient : IServersService
    {
        private readonly HttpClient _http;
        public ServersServiceClient(HttpClient http) => _http = http;
        public Task<IEnumerable<Server>> GetAllAsync()
        {
            var servers = _http.GetFromJsonAsync<IEnumerable<Server>>("api/servers");
            return servers;
        }

        public async Task<Server?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Server?>($"api/servers/{id}");
        }

        public async Task<Server> CreateAsync(Server server)
        {
            var response = await _http.PostAsJsonAsync("api/servers", server);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Server>()
                   ?? throw new InvalidOperationException("Server creation failed.");
        }

        public async Task UpdateAsync(int id, Server server)
        {
            var response = await _http.PutAsJsonAsync($"api/servers/{id}", server);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/servers/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
