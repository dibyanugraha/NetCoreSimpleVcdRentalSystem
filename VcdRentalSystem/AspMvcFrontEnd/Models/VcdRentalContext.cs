using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspMvcFrontEnd.Models
{
    public class VcdRentalContext : DbContext
    {
        public VcdRentalContext(DbContextOptions<VcdRentalContext> options) : base(options)
        { }

        public DbSet<TenantModel> Tenants { get; set; }
    }
}
