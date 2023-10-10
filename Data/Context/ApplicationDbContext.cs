using Data.Entities;
using Data.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(p => p.UserName)
                .IsRequired().HasMaxLength(256).HasAnnotation("RegularExpression", @"^[a-zA-Z0-9_]+$");
            // Configure the one-to-many relationship between ApplicationUser and UserAddress
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.UserAddresses)
                .WithOne(ua => ua.ApplicationUser)
                .HasForeignKey(ua => ua.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);  // Configures cascade delete

            builder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.ProductCategory)
                      .WithMany(pc => pc.Products)
                      .HasForeignKey(p => p.ProductCategoryId);
            });

            // Configuration for ProductCategory
            builder.Entity<ProductCategory>(entity =>
            {
                // Indexing for performance
                entity.HasIndex(e => e.Name);

                // Optionally, if you want to enforce a maximum length constraint at the database level for the Description field
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            // Configuration for ProductInventory
            builder.Entity<ProductInventory>(entity =>
            {
                // Configuration for the one-to-one relationship between Product and ProductInventory
                entity.HasOne(pi => pi.Product)
                      .WithOne(p => p.ProductInventory)
                      .HasForeignKey<ProductInventory>(pi => pi.ProductId);

                // Optionally, if you want to ensure that Quantity is always non-negative
                entity.Property(pi => pi.Quantity)
                      .HasDefaultValue(0)
                      .HasColumnType("int CHECK (Quantity >= 0)");
            });

            builder.Entity<UserAddress>(entity =>
            {
               entity.HasOne(ua => ua.ApplicationUser)
                  .WithMany(u => u.UserAddresses)
                  .HasForeignKey(ua => ua.ApplicationUserId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);  // Configures cascade delete
            });
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    ((BaseEntity)entry.Entity).Deleted = DateTime.UtcNow;
                }
                else  // EntityState.Modified
                {
                    ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
                }
            }
        }
    }
}

