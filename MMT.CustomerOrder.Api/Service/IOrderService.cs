using MMT.CustomerOrder.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.Api.Service
{
   public interface IOrderService
    {
        public Task<OrderDetail> CustomerLatestOrder(UserRequest userRequest);
    }
}
