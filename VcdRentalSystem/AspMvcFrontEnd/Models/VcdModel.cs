using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcFrontEnd.Models
{
    public class VcdModel
    {
        [Key]
        public int VcdId { get; set; }
        [Display(Name = "Title")]
        public string VcdTitle { get; set; }
        [Display(Name = "Bought Date")]
        public DateTime? VcdBoughtDate { get; set; }
    }
}
