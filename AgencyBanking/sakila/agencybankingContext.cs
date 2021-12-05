using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgencyBanking.sakila
{
    public partial class agencybankingContext : DbContext
    {
        public agencybankingContext()
        {
        }

        public agencybankingContext(DbContextOptions<agencybankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apilogitem> Apilogitems { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<Customeraccountschema> Customeraccountschemas { get; set; }
        public virtual DbSet<Customererror> Customererrors { get; set; }
        public virtual DbSet<Customerprofile> Customerprofiles { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Userdeviceinfo> Userdeviceinfos { get; set; }
        public virtual DbSet<Userqa> Userqas { get; set; }
        public virtual DbSet<Walletinfo> Walletinfos { get; set; }
        public virtual DbSet<Wallettransfer> Wallettransfers { get; set; }
        public virtual DbSet<Walletuser> Walletusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=agencybanking;user=root;password=mysql");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apilogitem>(entity =>
            {
                entity.ToTable("apilogitem");

                entity.Property(e => e.Method).HasMaxLength(100);

                entity.Property(e => e.Path).HasColumnType("longtext");

                entity.Property(e => e.QueryString).HasColumnType("longtext");

                entity.Property(e => e.RequestBody).HasColumnType("longtext");

                entity.Property(e => e.ResponseBody).HasColumnType("longtext");

                entity.Property(e => e.ResponseMillis).HasColumnType("decimal(18,0)");
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("beneficiary");

                entity.HasIndex(e => e.UserId, "FK_Beneficiary_WalletUsers");

                entity.Property(e => e.BeneficiaryId)
                    .HasMaxLength(36)
                    .IsFixedLength(true);

                entity.Property(e => e.BeneficiaryAccountName).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryAccountNumber).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryBankCode).HasMaxLength(20);

                entity.Property(e => e.BeneficiaryBankName).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Beneficiary_WalletUsers");
            });

            modelBuilder.Entity<Customeraccountschema>(entity =>
            {
                entity.ToTable("customeraccountschema");

                entity.HasIndex(e => e.UserId, "FK_CustomerAccount_WalletUsers");

                entity.Property(e => e.AccountGroup).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customeraccountschemas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CustomerAccount_WalletUsers");
            });

            modelBuilder.Entity<Customererror>(entity =>
            {
                entity.HasKey(e => e.Refid)
                    .HasName("PRIMARY");

                entity.ToTable("customererror");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("BVN");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MobileNum).HasMaxLength(50);

                entity.Property(e => e.Msg).HasColumnType("longtext");

                entity.Property(e => e.Screen).HasMaxLength(50);

                entity.Property(e => e.Stage).HasMaxLength(50);
            });

            modelBuilder.Entity<Customerprofile>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PRIMARY");

                entity.ToTable("customerprofile");

                entity.HasIndex(e => e.Smid, "FK_CustomerProfile_WalletUsers");

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
                    .WithMany(p => p.Customerprofiles)
                    .HasForeignKey(d => d.Smid)
                    .HasConstraintName("FK_CustomerProfile_WalletUsers");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("otp");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Otp1)
                    .HasMaxLength(50)
                    .HasColumnName("OTP");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.QuestionId)
                    .HasMaxLength(36)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .HasColumnName("Question");
            });

            modelBuilder.Entity<Userdeviceinfo>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("PRIMARY");

                entity.ToTable("userdeviceinfo");

                entity.HasIndex(e => e.UserId, "FK_UserDeviceInfo_WalletUsers");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(36)
                    .IsFixedLength(true);

                entity.Property(e => e.HardwareImei)
                    .HasMaxLength(1000)
                    .HasColumnName("HardwareIMEI");

                entity.Property(e => e.Imei)
                    .HasMaxLength(100)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(1000)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.IsCurrent).HasDefaultValueSql("'0'");

                entity.Property(e => e.Make).HasMaxLength(100);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Osversion)
                    .HasMaxLength(100)
                    .HasColumnName("OSVersion");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userdeviceinfos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDeviceInfo_WalletUsers");
            });

            modelBuilder.Entity<Userqa>(entity =>
            {
                entity.ToTable("userqa");

                entity.HasIndex(e => e.QuestionId, "FK_UserQA_Question");

                entity.HasIndex(e => e.UserId, "FK_UserQA_WalletUsers");

                entity.Property(e => e.UserQaid)
                    .HasMaxLength(36)
                    .HasColumnName("UserQAId")
                    .IsFixedLength(true);

                entity.Property(e => e.Answer).HasMaxLength(1000);

                entity.Property(e => e.QuestionId)
                    .HasMaxLength(36)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Userqas)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_UserQA_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userqas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserQA_WalletUsers");
            });

            modelBuilder.Entity<Walletinfo>(entity =>
            {
                entity.ToTable("walletinfo");

                entity.HasIndex(e => e.Customerid, "FK_WalletInfo_WalletUsers");

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
                    .WithMany(p => p.Walletinfos)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("FK_WalletInfo_WalletUsers");
            });

            modelBuilder.Entity<Wallettransfer>(entity =>
            {
                entity.ToTable("wallettransfers");

                entity.HasIndex(e => e.Smid, "FK_WalletTransfers_WalletUsers");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsFixedLength(true);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CurrencyCode).HasMaxLength(50);

                entity.Property(e => e.FromAct).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Smid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SMID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.ToAcct).HasMaxLength(50);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.Wallettransfers)
                    .HasForeignKey(d => d.Smid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletTransfers_WalletUsers");
            });

            modelBuilder.Entity<Walletuser>(entity =>
            {
                entity.ToTable("walletusers");

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

                entity.Property(e => e.PasswordHash).HasColumnType("longblob");

                entity.Property(e => e.PasswordSalt).HasColumnType("longblob");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.Referralcode).HasMaxLength(50);

                entity.Property(e => e.TransPin).HasMaxLength(1000);

                entity.Property(e => e.Transactionpin).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
