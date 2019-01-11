using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspMvcFrontEnd.Models
{
    public class TenantModel
    {
        [Key]
        public int TenantId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string IdentityNumber { get; set; }
        public bool IsMemberOfAnotherRental { get; set; }
        public ReferenceEnum Reference { get; set; }
        public RentalPackageModel SubscribePackage { get; set; }
    }
}