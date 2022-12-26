using ASP_API_EF.Data;
using ASP_API_EF.Interfaces;
using ASP_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Services
{
    public class ClientService : ICrud<Client>
    {
        private readonly DataContext _context;
        public ClientService(DataContext dBContext) => _context = dBContext;

        public async Task<List<Client>> GetAll() => await this._context.Clients.ToListAsync();

        public async Task<ActionResult<object>> GetById(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return FailResponse("Not found");
            else return client;
        }

        public async Task<ActionResult<object>> Create(Client Model)
        {
            var newClient = _context.Clients.Add(Model);
            await _context.SaveChangesAsync();

            return newClient;
        }

        public Task<ActionResult<object>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Client>> Update(Client Model)
        {
            throw new NotImplementedException();
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Client>> GetClient(int id)
        //{
        //  
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

        private object FailResponse(string msj) => new { success = "ok", message = msj };
    }
}
