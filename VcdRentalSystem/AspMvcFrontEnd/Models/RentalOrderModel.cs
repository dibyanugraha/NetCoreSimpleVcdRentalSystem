using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class RentalOrderModel
    {
        [Key]
        public int RentalOrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public TenantModel BillToTenant { get; set; }
        public DateTime DueDate { get; set; }
        public List<VcdModel> Vcds { get; set; }
        public decimal TotalCost { get; set; }
    }
}
