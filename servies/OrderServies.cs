using Entytess;
using Microsoft.Extensions.Logging;
using repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace servies
{
    public class OrderServies:IOrderServies
    {
        private readonly ILogger<OrderServies> _logger;
        IOrderRepository _orderRepository;
        public OrderServies(IOrderRepository _OrderRepository,ILogger<OrderServies> logger)
        {
            _logger = logger;
            _orderRepository = _OrderRepository;
        }



        public async Task<Order> CreateNewOrder(Order order)
        {
            double order_sum = 0;
            var o = order.OrderItems;
            foreach (OrderItem i in o)
            {
                double sum =await _orderRepository.getprice(i);
                sum =sum* (i.Quantity+1);
                order_sum += sum;

            }
            if (order_sum != order.OrderSum)

            {
                _logger.LogInformation("{1} try to still!!!!!!!!!!! ", order.UserId);
                _logger.LogError($"try to still: {order.UserId}");
            }

            return await _orderRepository.CreateNewOrder(order);





        }

    }
}
