using ASP_API_EF.Data;
using ASP_API_EF.Interfaces;
using ASP_API_EF.Models;
using ASP_API_EF.Services;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : ControllerBase
    {
        private readonly ICrud<Client> GatewayClient;

        public ClientController(ICrud<Client> gateway) => this.GatewayClient = gateway;

        [HttpGet]
        public async Task<List<Client>> GetClients() => await GatewayClient.GetAll();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<object>> GetClientById(int id) => await GatewayClient.GetById(id);

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Client>> AddNewClient([FromBody] Client Model)
        {
            var client = await GatewayClient.Create(Model);
            return Ok(client);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<object>> UpdateClient([FromBody] Client Model)
        {
            var clientUpdated = await GatewayClient.Update(Model);
            if (clientUpdated != null) return Ok(clientUpdated);
            else return NotFound("Client no found");
        }

        [HttpDelete]
        [Route("del")]
        public async Task<ActionResult<object>> DeleteClient(int idClient)
        {
            var response = await GatewayClient.DeleteById(idClient);
            if (response != null) return Ok(response);
            else return NotFound("Client no found");
        }
    }
}
