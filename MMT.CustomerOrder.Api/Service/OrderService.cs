using Microsoft.EntityFrameworkCore;
using MMT.CustomerOrder.Core.Entities;
using MMT.CustomerOrder.Core.Interfaces;
using MMT.CustomerOrder.Core.User;
using MMT.CustomerOrder.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MMT.CustomerOrder.Api.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IUserApiGateway _userApiGateway;
        public OrderService(IOrdersRepository orderRepository, IUserApiGateway userApiGateway)
        {
            _orderRepository = orderRepository;
            _userApiGateway = userApiGateway;
        }
        public async Task<OrderDetail> CustomerLatestOrder(UserRequest userRequest)
        {
            var user = await _userApiGateway.GetAsync(userRequest.User);

            var allCustomerOrders = await _orderRepository.GetAllLazyLoadAsync(x => x.CustomerId == userRequest.CustomerId, includes: source => source.Include(x => x.OrderItems).ThenInclude(x => x.Product));

            var latestOrder = allCustomerOrders.OrderByDescending(x => x.OrderDate).FirstOrDefault();

            return OrderDetail(latestOrder,user.Data);

        }

        private OrderDetail OrderDetail(Orders? order, User user)
        {
            return (order == null)
            ? new OrderDetail
            {
                Customer = new Customer
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }
            }
            : new OrderDetail
            {
                Customer = new Customer
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName
                },
                Order = new Order
                {
                    orderNumber = order.OrderId,
                    orderDate = order.OrderDate.ToString("D", DateTimeFormatInfo.InvariantInfo),
                    DeliveryAddress = $"{user.HouseNumber} {user.Street} {user.Town} {user.Postcode}",
                    OrderItems = OrderItems(order.OrderItems,order.ContainsGift),
                    DeliveryExpected = order.DeliveryExpected
                }
            };

        }

        private List<OrderItem> OrderItems(List<OrderItems> orderitems,bool containsGift)
        {
            List<OrderItem> items = new List<OrderItem>();
            orderitems.ForEach(x => items.Add(new OrderItem
            {
                Product = containsGift ? "Gift" : x.Product?.ProductName?.ToString(),
                Quantity = x.Quantity ,
                PriceEach = x.Price 
            }));

            return items;
        }
    }
}
