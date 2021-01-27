using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgencyBanking.Models
{
    public partial class AgencyBankingContext : DbContext
    {
        public AgencyBankingContext()
        {
        }

        public AgencyBankingContext(DbContextOptions<AgencyBankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiLogItem> ApiLogItems { get; set; }
        public virtual DbSet<WalletUser> WalletUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AgencyBanking;Trusted_Connection=True;");
                   optionsBuilder.UseSqlServer("Server=tcp:kmndb.database.windows.net,1433;Initial Catalog=AgencyBanking;Persist Security Info=False;User ID=kmnadmin;Password=Okot@2020KMN;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApiLogItem>(entity =>
            {
                entity.ToTable("ApiLogItem");

                entity.Property(e => e.Method).HasMaxLength(100);

                entity.Property(e => e.ResponseMillis).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<WalletUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Deviceimei).HasMaxLength(50);

                entity.Property(e => e.Devicemake).HasMaxLength(50);

                entity.Property(e => e.Devicemodel).HasMaxLength(50);

                entity.Property(e => e.Deviceos).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.HardwareImei)
                    .HasMaxLength(50)
                    .HasColumnName("HardwareIMEI");

                entity.Property(e => e.Ipaddress).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Referralcode).HasMaxLength(50);

                entity.Property(e => e.Transactionpin).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
