using System.ComponentModel.DataAnnotations;

namespace E_AuctionProject.Models
{
    public class Login
    {
        [Required(ErrorMessage ="CustomerID is Mandatory")]
        public int CustomerID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
