using System.ComponentModel.DataAnnotations;

namespace E_AuctionProject.Models
{
    public class UserMaster
    {

        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Exceeded the given Range")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Should be Same")]
        public string CPassword { get; set; }
        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        public string Email { get; set; }
        [Required(ErrorMessage = "DOB is Required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        public int RoleId { get; set; }
    }
}
