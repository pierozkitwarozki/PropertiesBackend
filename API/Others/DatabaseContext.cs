using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Others
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<UserDistrict> UserDistricts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserDistrict>()
                .HasKey(x => new { x.DistrctId, x.UserId });
                
            builder.Entity<User>()
                .HasMany(x => x.UserDistricts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.Entity<District>()
                .HasMany(x => x.UserDistricts)
                .WithOne(x => x.District)
                .HasForeignKey(x => x.DistrctId)
                .IsRequired();

            builder.Entity<Property>()
                .HasOne(x => x.District)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}