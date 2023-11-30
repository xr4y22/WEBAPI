using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Interface;
using TestAPI.Models;
using TestAPI.Models.Request;

namespace TestAPI.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _item;
        public ItemController(IItem item)
        {
            _item = item;
        }

        [Route("api/item")]
        [HttpGet]
        public async Task<IActionResult> GetItem([FromQuery]PagingRequest paging)
        {

            return Ok(_item.GetItem(paging));
        }


        [Route("api/item/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetItemById(int id)
        {
            return Ok(_item.GetItemById(id));
        }

        [Route("api/item")]
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemRequest item)
        {
            return Ok(_item.AddItem(item));
        }

        [Route("api/item")]
        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] MItem item)
        {
            return Ok(_item.UpdateItem(item));
        }

        [Route("api/item/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(_item.DeleteItem(id));
        }
    }
}
