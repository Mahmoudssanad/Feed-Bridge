using FeedBridge_00.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace FeedBridge_00.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<InventoryEmployee> InventoryEmployees { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserPhone> UserPhones { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Inject ده عشان وانا بعمل constructor محتاج ال  
            // inject the object in constructor
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            //var connection = new SqlConnection(configuration.GetSection("constr").Value);

            //optionsBuilder.UseSqlServer(connection);
            optionsBuilder.UseSqlServer
                ("Server = NV_PC; Database = FeedBridge ; Integrated Security = SSPI; TrustServerCertificate = True;MultipleActiveResultSets=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
