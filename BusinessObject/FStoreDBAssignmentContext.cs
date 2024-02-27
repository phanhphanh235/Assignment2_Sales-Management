using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class FStoreDBAssignmentContext : DbContext
    {
        public FStoreDBAssignmentContext() { }
        public FStoreDBAssignmentContext(DbContextOptions<FStoreDBAssignmentContext> options) : base(options)
        {

        }
        public virtual DbSet<MemberObject> Members { get; set; }
        public virtual DbSet<OrderObject> Orders { get; set; }
        public virtual DbSet<OrderDetailObject> OrderDetails { get; set; }
        public virtual DbSet<ProductObject> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FStoreDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<MemberObject>(entity =>
            {
                entity.ToTable("Member");
                entity.Property(e => e.MemberId).ValueGeneratedNever();
            })
        }
    }
}
