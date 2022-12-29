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

        public async Task<List<Client>> GetAll() => await this._context.Clients.Include(x => x.City).ToListAsync();

        public async Task<Client> GetById(int id) => await _context.Clients.FindAsync(id);

        public async Task<Client> Create(Client Model)
        {
            var newClient = _context.Clients.Add(Model);
            await _context.SaveChangesAsync();

            return newClient.Entity;
        }

        public async Task<Client> DeleteById(int id)
        {
            Client clientSelected = (Client)await this.GetById(id);
            if (clientSelected != null)
            {
                _context.Remove(clientSelected);
                _context.SaveChanges();
                return clientSelected;
            }
            else return null;
        }

        public async Task<Client> Update(Client Model)
        {
            Client clientSelected = (Client)await this.GetById(Model.Id);
            if (clientSelected != null)
            {
                clientSelected.Name = Model.Name;
                clientSelected.Email = Model.Email;
                clientSelected.CityId = Model.CityId;

                _context.SaveChanges();
                return clientSelected;
            }
            else return null;
        }
    }
}
