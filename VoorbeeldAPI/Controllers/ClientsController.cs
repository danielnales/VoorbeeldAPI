using Microsoft.AspNetCore.Mvc;
using VoorbeeldAPI.Models;
using VoorbeeldAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoorbeeldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientsService clientsService) : ControllerBase
    {
        private readonly IClientsService _clientsService = clientsService;

        // GET: api/<ClientsController>
        [ProducesResponseType(statusCode: 200)]
        [HttpGet(Name = "GetClients")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clientsService.GetAllClients());
        }

        // GET api/<ClientsController>/5
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 404)]
        [HttpGet("{clientId:guid}", Name = "GetClientById")]
        public async Task<IActionResult> Get(Guid clientId)
        {
            var client = await _clientsService.GetClientById(clientId);
            return client is null ? Ok(client) : NotFound();
        }

        // POST api/<ClientsController>
        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 400)]
        [HttpPost(Name = "CreateClient")]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _clientsService.CreateClient(client) ? CreatedAtRoute("GetClientById", new { clientId = client.Id }, client.Dto) : BadRequest();
        }
    }
}
