
using Microsoft.EntityFrameworkCore;
using trasua_web_mvc.Infracstructures.Entities;

namespace trasua_web_mvc.Infracstructures
{
    public class TraSuaContext : DbContext
    {
        public TraSuaContext(DbContextOptions<TraSuaContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Promotion> Promotion { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserModel(modelBuilder);
            ConfigureProductModel(modelBuilder);
            ConfigureCart(modelBuilder);
            ConfigureCartItem(modelBuilder);
            ConfigureBranch(modelBuilder);
            ConfigureOrderModel(modelBuilder);
            ConfigureOrderDetaill(modelBuilder);
        }

        private void ConfigureUserModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable(nameof(User))
                .HasKey(e => e.Id);
        }
        private void ConfigureProductModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable(nameof(Product))
                .HasKey(e => e.Id);


            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.CategoryId);

        }

        private void ConfigureOrderModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .ToTable(nameof(Order))
                .HasKey(e => e.Id);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Promotion)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.PromotionId);
        }

        private void ConfigureOrderDetaill(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .ToTable(nameof(OrderDetail))
                .HasKey(e => e.Id);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Product)
                .WithOne(x => x.OrderDetail)
                .HasForeignKey<OrderDetail>(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureCart(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .ToTable(nameof(Cart))
                .HasKey(e => e.Id);

            modelBuilder.Entity<Cart>()
                .HasOne(x => x.Customer)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>(x => x.CusIdentify);
        }

        private void ConfigureCartItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .ToTable(nameof(CartItem))
                .HasKey(e => e.Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Cart)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Product)
                .WithOne(x => x.CartItem)
                .HasForeignKey<CartItem>(x => x.ProductId);
                
        }

        public void ConfigureBranch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .ToTable(nameof(Branch))
                .HasKey(e => e.Id);
            modelBuilder.Entity<Branch>()
               .HasOne(x => x.Area)
               .WithMany(x => x.Branches)
               .HasForeignKey(x => x.AreaId);
        }



    }
}
