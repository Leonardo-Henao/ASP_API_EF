﻿using ASP_API_EF.Data;
using ASP_API_EF.Interfaces;
using ASP_API_EF.Models;
using ASP_API_EF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : ControllerBase
    {
        private readonly ICrud<Client> GatewayClient;

        //private readonly ICrud<Location> GateWayLocation;

        public ClientController(ICrud<Client> gateway) => this.GatewayClient = gateway;

        [HttpGet]
        public async Task<List<Client>> GetClients() => await GatewayClient.GetAll();

        [HttpPost]
        public async Task<object> CreateClient(Client client) {

            return await GatewayClient.Create(client);
        }


        //// GET: api/Clients/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Client>> GetClient(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);

        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return client;
        //}

        //// PUT: api/Clients/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(int id, Client client)
        //{
        //    if (id != client.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Clients
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Client>> PostClient(Client client)
        //{
        //    _context.Clients.Add(client);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetClient", new { id = client.Id }, client);
        //}

        //// DELETE: api/Clients/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClient(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clients.Remove(client);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ClientExists(int id)
        //{
        //    return _context.Clients.Any(e => e.Id == id);
        //}
    }
}
