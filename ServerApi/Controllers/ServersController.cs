using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApi.Models;


namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServersEFCoreRepository _repo;
        public ServersController(IServersEFCoreRepository repo) => _repo = repo;

        [HttpGet]
        public ActionResult<List<Server>> GetAll() => _repo.GetAllServers();

        [HttpGet("{id:int}")]
        public ActionResult<Server> GetById(int id)
        {
            var server = _repo.GetServerById(id);
            if (server is null) return NotFound();
            return server;
        }

        [HttpGet("search")]
        public ActionResult<List<Server>> Search([FromQuery] string? query) => _repo.SearchServers(query ?? string.Empty);

        [HttpGet("city/{city}")]
        public ActionResult<List<Server>> GetByCity(string city) => _repo.GetServersByCity(city);

        [HttpPost]
        public IActionResult Create(Server server)
        {
            _repo.AddServer(server);
            return CreatedAtAction(nameof(GetById), new { id = server.ServerId }, server);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Server server)
        {
            if (id != server.ServerId) return BadRequest();
            _repo.UpdateServer(id, server);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteServer(id);
            return NoContent();
        }
    }
}
