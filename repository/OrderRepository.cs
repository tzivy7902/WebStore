using Entytess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly StoreDatabaseContext _dbContext;
        public OrderRepository(StoreDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreateNewOrder(Order order)
        {
     
           await _dbContext.AddAsync(order);
           await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<double> getprice(OrderItem order)
        {
            Product product = _dbContext.Products.Where(item => item.ProductId == order.ProductId).FirstOrDefault();
            return (double) product.Price;
        }
      
    }
}
