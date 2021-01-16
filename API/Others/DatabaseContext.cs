using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Others
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<User> User { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<UserProperty> UserProperty { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProperty>()
                .HasKey(x => new { x.PropertyId, x.UserId });
                
            builder.Entity<User>()
                .HasMany(x => x.UserProperties)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.Entity<Property>()
                .HasMany(x => x.UserProperties)
                .WithOne(x => x.Property)
                .HasForeignKey(x => x.PropertyId)
                .IsRequired();

            builder.Entity<Property>()
                .HasOne(x => x.District)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}