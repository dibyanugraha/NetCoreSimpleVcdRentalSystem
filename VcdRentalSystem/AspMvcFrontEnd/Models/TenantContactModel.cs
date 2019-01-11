using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class TenantContactModel
    {
        public TenantModel Tenant { get; set; }
        public ContactModel Contact { get; set; }
    }
}
