using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Phone No.")]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        [Display(Name = "Identity Number")]
        public string IdentityNumber { get; set; }
    }
}
