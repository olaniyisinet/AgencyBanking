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
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<CustomerAccountSchema> CustomerAccountSchemas { get; set; }
        public virtual DbSet<CustomerError> CustomerErrors { get; set; }
        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<UserDeviceInfo> UserDeviceInfos { get; set; }
        public virtual DbSet<UserQa> UserQas { get; set; }
        public virtual DbSet<WalletInfo> WalletInfos { get; set; }
        public virtual DbSet<WalletTransfer> WalletTransfers { get; set; }
        public virtual DbSet<WalletUser> WalletUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:kmndb.database.windows.net,1433;Initial Catalog=AgencyBanking;Persist Security Info=False;User ID=kmnadmin;Password=Okot@2020KMN;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Trusted_Connection=True;");
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AgencyBanking;Trusted_Connection=True;");
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

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("Beneficiary");

                entity.Property(e => e.BeneficiaryId).ValueGeneratedNever();

                entity.Property(e => e.BeneficiaryAccountName).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryAccountNumber).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryBankCode).HasMaxLength(20);

                entity.Property(e => e.BeneficiaryBankName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Beneficiary_WalletUsers");
            });

            modelBuilder.Entity<CustomerAccountSchema>(entity =>
            {
                entity.ToTable(" CustomerAccountSchema");

                entity.Property(e => e.AccountGroup).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerAccountSchemas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CustomerAccount_WalletUsers");
            });

            modelBuilder.Entity<CustomerError>(entity =>
            {
                entity.HasKey(e => e.Refid);

                entity.ToTable("CustomerError");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BVN");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Msg).IsUnicode(false);

                entity.Property(e => e.Screen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stage)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("CustomerProfile");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AgentCode).HasMaxLength(50);

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("BVN");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.LastLogin).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PryAccount).HasMaxLength(50);

                entity.Property(e => e.ReferralCode).HasMaxLength(50);

                entity.Property(e => e.RmdaoCode)
                    .HasMaxLength(50)
                    .HasColumnName("RMDaoCode");

                entity.Property(e => e.Rmemail)
                    .HasMaxLength(50)
                    .HasColumnName("RMEmail");

                entity.Property(e => e.Rmmobile)
                    .HasMaxLength(50)
                    .HasColumnName("RMMobile");

                entity.Property(e => e.Rmname)
                    .HasMaxLength(50)
                    .HasColumnName("RMName");

                entity.Property(e => e.Smid)
                    .HasMaxLength(50)
                    .HasColumnName("SMID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.CustomerProfiles)
                    .HasForeignKey(d => d.Smid)
                    .HasConstraintName("FK_CustomerProfile_WalletUsers");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("OTP");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Otp1)
                    .HasMaxLength(50)
                    .HasColumnName("OTP");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Question");
            });

            modelBuilder.Entity<UserDeviceInfo>(entity =>
            {
                entity.HasKey(e => e.DeviceId);

                entity.ToTable("UserDeviceInfo");

                entity.Property(e => e.DeviceId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HardwareImei)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("HardwareIMEI");

                entity.Property(e => e.Imei)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.IsCurrent).HasDefaultValueSql("((0))");

                entity.Property(e => e.Make)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Osversion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OSVersion");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDeviceInfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDeviceInfo_WalletUsers");
            });

            modelBuilder.Entity<UserQa>(entity =>
            {
                entity.ToTable("UserQA");

                entity.Property(e => e.UserQaid)
                    .ValueGeneratedNever()
                    .HasColumnName("UserQAId");

                entity.Property(e => e.Answer)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_UserQA_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserQA_WalletUsers");
            });

            modelBuilder.Entity<WalletInfo>(entity =>
            {
                entity.ToTable("WalletInfo");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(10)
                    .HasColumnName("CURRENCYCODE");

                entity.Property(e => e.Customerid).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Nuban).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WalletInfos)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_WalletInfo_WalletUsers");
            });

            modelBuilder.Entity<WalletTransfer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CurrencyCode).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromAct).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Smid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SMID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.ToAcct).HasMaxLength(50);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.WalletTransfers)
                    .HasForeignKey(d => d.Smid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletTransfers_WalletUsers");
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
