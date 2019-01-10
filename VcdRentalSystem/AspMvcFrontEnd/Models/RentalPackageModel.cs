using System.ComponentModel.DataAnnotations;

namespace AspMvcFrontEnd.Models
{
    public class RentalPackageModel
    {
        [Key]
        public int RentalPackageId { get; set; }
        public string PackageName { get; set; }
        public decimal CostPerMonth { get; set; }
        public int MaxVcdRental { get; set; }
    }
}