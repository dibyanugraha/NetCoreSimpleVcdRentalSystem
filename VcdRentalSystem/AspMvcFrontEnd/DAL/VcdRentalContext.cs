using Microsoft.EntityFrameworkCore;
using AspMvcFrontEnd.Models;

namespace AspMvcFrontEnd.DAL
{
    public class VcdRentalContext : DbContext
    {
        public VcdRentalContext(DbContextOptions<VcdRentalContext> options) : base(options)
        { }

        public DbSet<TenantModel> Tenants { get; set; }
        public DbSet<VcdModel> Vcds { get; set; }
        public DbSet<RentalOrderModel> RentalOrders { get; set; }
        public DbSet<RentalLedgerEntryModel> RentalLedgerEntries { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<AspMvcFrontEnd.Models.RentalPackageModel> RentalPackageModel { get; set; }

    }
}
