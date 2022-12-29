using ASP_API_EF.Data;
using ASP_API_EF.Interfaces;
using ASP_API_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_API_EF.Services
{
    public class LocationService : ICrud<Location>
    {
        private readonly DataContext _context;

        public LocationService(DataContext dBContext) => _context = dBContext;

        public async Task<Location> Create(Location Model)
        {
            var newLocation = _context.Locations.Add(Model);
            await _context.SaveChangesAsync();
            return newLocation.Entity;
        }

        public async Task<Location> DeleteById(int id)
        {
            Location locationSelected = (Location)await this.GetById(id);
            if (locationSelected != null)
            {
                _context.Remove(locationSelected);
                _context.SaveChanges();
                return locationSelected;
            }
            else return null;

        }

        public async Task<List<Location>> GetAll() => await _context.Locations.ToListAsync();

        public async Task<Location> GetById(int id) => await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

        public async Task<Location> Update(Location Model)
        {
            Location locationSelected = (Location)await this.GetById(Model.Id);
            if (locationSelected != null)
            {
                locationSelected.Name = Model.Name;
                locationSelected.Capital = Model.Capital;

                _context.SaveChanges();
                return locationSelected;
            }
            else return null;
        }
    }
}
