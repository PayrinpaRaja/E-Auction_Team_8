using System.ComponentModel.DataAnnotations;

namespace E_AuctionProject.Models
{
    public class ApplyBid
    {
        [Key]
        public int BidNo { get; set; }
        public int Pt_no { get; set; }
        public string BuyerName { get; set; }
        [Display(Name = "Product")]
        public string B_Product { get; set; }
        public  int MinAmount { get; set; }
        [Display(Name = "Details")]
        public string B_Details { get; set; }
        public string Owner { get; set; }
        public int BidAmount { get; set; }
        public int CustomerID { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        public string Approval { get; set; }


    }
}
