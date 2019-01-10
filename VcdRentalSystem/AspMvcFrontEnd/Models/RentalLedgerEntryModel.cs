using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class RentalLedgerEntryModel
    {
        [Key]
        public int EntryNo { get; set; }
        public int VcdId { get; set; }
        public int TenantId { get; set; }
        public int RentalOrderId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Quantity { get; set; }
        
    }
}
