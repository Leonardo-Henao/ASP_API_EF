using ASP_API_EF.Data;
using ASP_API_EF.Interfaces;
using ASP_API_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Services
{
    public class LocationService : ICrud<Location>
    {
        private readonly DataContext _context;
        public LocationService(DataContext dBContext) => _context = dBContext;

        public Task<ActionResult<object>> Create(Location Model)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<object>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Location>> GetAll() => await _context.Locations.ToListAsync();

        public async Task<ActionResult<object>> GetById(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public Task<ActionResult<Location>> Update(Location Model)
        {
            throw new NotImplementedException();
        }
    }
}
