using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class TenantContactModel
    {
        public int TenantContactId { get; set; }
        public int ContactId { get; set; }
        public int TenantId { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Confirmed { get; set; }
        
    }
}
