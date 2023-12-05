using Entytess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateNewOrder(Order order);
        Task<double> getprice(OrderItem order);
    }
}
