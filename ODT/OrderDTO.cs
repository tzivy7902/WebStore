using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODT
{
    public class OrderDTO
    {
  
        public DateTime OrderDate { get; set; }

        public int OrderSum { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();


    }
}
