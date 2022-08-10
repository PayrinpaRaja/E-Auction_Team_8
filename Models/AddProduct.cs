using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_AuctionProject.Models
{
    public class AddProduct
    {
        [Key]
        public int Sno { get; set; }
        [Required]
        public string Username { get; set; }
        [Required(ErrorMessage ="Product is Mandatory")]
        public string Product { get; set; }
        [Required(ErrorMessage = "Details is Mandatory")]
        public string Details { get; set; }
        [Required(ErrorMessage = "Amount is Mandatory")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Bid Opening Date is Mandatory")]
        [Display(Name ="Opening Date")]
        public DateTime O_date { get; set; }
        [Required(ErrorMessage = "Bid Closing Date is Mandatory")]
        [Display(Name = "Closing Date")]
        public DateTime L_date { get; set; }
        
        [Required(ErrorMessage = "Email Address is Mandatory")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "MobileNumber is Mandatory")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [ForeignKey("UserMaster")]
        public int CustomerID { get; set; }
    }
}
