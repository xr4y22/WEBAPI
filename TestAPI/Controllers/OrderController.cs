﻿using Microsoft.AspNetCore.Mvc;
using TestAPI.Interface;
using TestAPI.TestAPIEntity;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDataAccess _orderDataAccess;

        public OrderController(IOrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }
         
        [HttpPost]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {
            _orderDataAccess.SaveOrder(orderModel);

            return Ok("Success");
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_orderDataAccess.GetAllOrder());
        }
    }
}
