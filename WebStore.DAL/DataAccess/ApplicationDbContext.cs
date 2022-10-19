using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModel;


namespace WebStore.DAL.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<Address> Addresses { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Invoice> Invoices { get; set; } = default!;
        public virtual DbSet<StationaryStore> StationaryStores { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>(0)
                .HasValue<Customer>(1)
                .HasValue<Supplier>(2)
                .HasValue<StationaryStoreEmployee>(3);

            builder.Entity<OrderProduct>()
                 .HasOne(o => o.Order)
                 .WithMany(op => op.OrderProducts)
                 .HasForeignKey(ord => ord.OrderId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}