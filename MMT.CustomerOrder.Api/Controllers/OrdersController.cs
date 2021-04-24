using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MMT.CustomerOrder.Api.Service;
using MMT.CustomerOrder.Core.Entities;
using MMT.CustomerOrder.Core.Interfaces;
using MMT.CustomerOrder.Core.User;
using MMT.CustomerOrder.Dtos;
using MMT.CustomerOrder.Infrastructure.Repositories;
using MMT.CustomerOrder.SharedKernel.Authentication;

namespace MMT.CustomerOrder.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;
        public OrdersController(IOrderService orderService, IAuthService authService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
             _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderDetail),StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDetail>> Post([FromBody] UserRequest userRequest)
        {
           var authenticate =  await _authService.AuthenticateAsync(userRequest.User, userRequest.CustomerId);
            if(!authenticate)
            {
                return Unauthorized("User and Customerid provided do not match our records.");
            }
            var orderDetail = await _orderService.CustomerLatestOrder(userRequest);
           
            return Ok(orderDetail);
        }

    }
}
