using System.ComponentModel.DataAnnotations;

namespace ODT
{
    public class UserDTO
    {
 
        public int UserId { get; set; }

        [EmailAddress]
        public string Email { get; set; } = null!;

        
        public string Password{get; set;  } = null!;

        [MaxLength(10)]
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderSum { get; set; }


    }
}