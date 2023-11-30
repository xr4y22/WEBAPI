using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Interface;
using TestAPI.Models.Response;
using TestAPI.Models;
using TestAPI.Models.Request;

namespace TestAPI.Controllers
{
  
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly ISupplier _supplier;
        
        public SupplierController(ISupplier supplier)
        {
            _supplier = supplier;
        }

        [Route("api/supplier")]
        [HttpGet]
        public async Task<IActionResult> GetSupplier([FromQuery] PagingRequest paging)
        {
           
            return Ok(_supplier.GetSupplier(paging));
        }

        [Route("api/supplier/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            return Ok(_supplier.GetSupplierById(id));
        }

        [Route("api/supplier")]
        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierRequest supplier)
        {
            return Ok(_supplier.AddSupplier(supplier));
        }

        [Route("api/supplier")]
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] MSupplier supplier)
        {
            return Ok(_supplier.UpdateSupplier(supplier));
        }

        [Route("api/supplier/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            return Ok(_supplier.DeleteSupplier(id));
        }
 
        [Route("api/supplier/{id}/item")]
        [HttpGet]
        public async Task<IActionResult> GetItemSupplier(int id)
        {
            return Ok(_supplier.GetItemSupplier(id));
        }

        [Route("api/supplier/{id}/item")]
        [HttpPost]
        public async Task<IActionResult> AddSupplierItem([FromBody] SupplierItemRequest item,int id)
        {
            return Ok(_supplier.AddSupplierItem(item,id));
        }

        [Route("api/supplier/{id}/item")]
        [HttpPatch]
        public async Task<IActionResult> UpdateSupplierItem(int id, [FromBody] SupplierItemRequest item)
        {
            return Ok(_supplier.UpdateSupplierItem(item,id));
        }
 
    }
}
