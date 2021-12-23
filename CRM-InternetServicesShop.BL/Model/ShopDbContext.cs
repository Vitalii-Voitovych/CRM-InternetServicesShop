using System.Data.Entity;

namespace CRM_InternetServicesShop.BL.Model
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopDbConnection")
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}
