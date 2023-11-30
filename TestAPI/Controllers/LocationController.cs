using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Interface;
using TestAPI.Models;
using TestAPI.Models.Request;

namespace TestAPI.Controllers
{
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _location;
        public LocationController(ILocation location)
        {
           _location = location;
        }

        [Route("api/location")]
        [HttpGet]
        public async Task<IActionResult> GetLocation([FromQuery] PagingRequest paging)
        {

            return Ok(_location.GetLocation(paging));
        }


        [Route("api/location/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(_location.GetLocationById(id));
        }

        [Route("api/location")]
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationRequest item)
        {
            return Ok(_location.AddLocation(item));
        }

        [Route("api/location")]
        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] MLocation item)
        {
            return Ok(_location.UpdateLocation(item));
        }

        [Route("api/location/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            return Ok(_location.DeleteLocation(id));
        }

        [Route("api/item/{id}/location")]
        [HttpGet]
        public async Task<IActionResult> GetItemLocation(int id)
        {
            return Ok(_location.GetItemLocation(id));
        }

        [Route("api/item/{id}/location")]
        [HttpPost]
        public async Task<IActionResult> AddItemLocation([FromBody] ItemLocationRequest item, int id)
        {
            return Ok(_location.AddItemLocation(id, item));
        }

        [Route("api/item/{id}/location")]
        [HttpPatch]
        public async Task<IActionResult> UpdateItemLocation([FromBody] ItemLocationRequest item, int id)
        {
            return Ok(_location.UpdateItemLocation(id, item));
        }

    }
}
