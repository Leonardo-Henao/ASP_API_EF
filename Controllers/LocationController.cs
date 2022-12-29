using Microsoft.AspNetCore.Mvc;
using ASP_API_EF.Models;
using ASP_API_EF.Interfaces;
using Azure;

namespace ASP_API_EF.Controllers
{
    [Route("api/v1/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ICrud<Location> Gateway;

        public LocationController(ICrud<Location> gateway) => this.Gateway = gateway;

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAllLocations() => await Gateway.GetAll();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<object>> GetLocationById(int id) => await Gateway.GetById(id);

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Location>> AddNewLocation([FromBody] Location Model)
        {
            var location = await Gateway.Create(Model);
            return Ok(location);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<object>> UpdateLocation([FromBody] Location Model)
        {
            var locationUpdated = await Gateway.Update(Model);
            if (locationUpdated != null) return Ok(locationUpdated);
            else return NotFound("Location no found");
        }

        [HttpDelete]
        [Route("del")]
        public async Task<ActionResult<object>> DeleteLocation(int idLocation)
        {
            var response = await Gateway.DeleteById(idLocation);
            if (response != null) return Ok("Location deleted " + response.Name);
            else return NotFound("Location no found");
        }
    }
}
