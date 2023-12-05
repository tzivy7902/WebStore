using AutoMapper;
using Entytess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODT;
using servies;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
       
       
        private readonly IOrderServies _order;
        private readonly IMapper _mapper;

            public OrderController(IOrderServies _Oreder,IMapper mapper)
            {
            _mapper = mapper;
            _order = _Oreder;
            }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post( [FromBody]OrderDTO order)
        {
            Order order1 = _mapper.Map<OrderDTO, Order>(order);

            Order order2 = await _order.CreateNewOrder(order1);

            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order2);

            if (orderDTO == null)
            {
                return NoContent();
            }
           
            return Ok(orderDTO);
        }








    }
}
