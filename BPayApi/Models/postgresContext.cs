using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BPayApi.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
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
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<ApiLogItem>(entity =>
            {
                entity.ToTable("ApiLogItem");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('apilogitem_seq'::regclass)");

                entity.Property(e => e.Method)
                    .HasMaxLength(100)
                    .HasColumnName("method");

                entity.Property(e => e.Path).HasColumnName("path");

                entity.Property(e => e.Querystring).HasColumnName("querystring");

                entity.Property(e => e.Requestbody).HasColumnName("requestbody");

                entity.Property(e => e.Requesttime)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("requesttime");

                entity.Property(e => e.Responsebody).HasColumnName("responsebody");

                entity.Property(e => e.Responsemillis)
                    .HasPrecision(18)
                    .HasColumnName("responsemillis");

                entity.Property(e => e.Statuscode).HasColumnName("statuscode");
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("Beneficiary");

                entity.Property(e => e.BeneficiaryId).ValueGeneratedNever();

                entity.Property(e => e.BeneficiaryAccountName).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryAccountNumber).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryBankCode).HasMaxLength(50);

                entity.Property(e => e.BeneficiaryBankName).HasMaxLength(50);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("userIdFK");
            });

            modelBuilder.Entity<CustomerAccountSchema>(entity =>
            {
                entity.ToTable("CustomerAccountSchema");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.AccountGroup).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerAccountSchemas)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("wallteruserFK");
            });

            modelBuilder.Entity<CustomerError>(entity =>
            {
                entity.HasKey(e => e.Refid)
                    .HasName("pk_customererror");

                entity.ToTable("CustomerError");

                entity.Property(e => e.Refid)
                    .HasColumnName("refid")
                    .HasDefaultValueSql("nextval('customererror_seq'::regclass)");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("bvn");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("datecreated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Mobilenum)
                    .HasMaxLength(50)
                    .HasColumnName("mobilenum");

                entity.Property(e => e.Msg).HasColumnName("msg");

                entity.Property(e => e.Screen)
                    .HasMaxLength(50)
                    .HasColumnName("screen");

                entity.Property(e => e.Stage)
                    .HasMaxLength(50)
                    .HasColumnName("stage");
            });

            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("CustomerProfile_pkey");

                entity.ToTable("CustomerProfile");

                entity.Property(e => e.Customerid).UseIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.AgentCode).HasMaxLength(50);

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("BVN");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.LastLogin).HasMaxLength(50);

                entity.Property(e => e.Phonenumber).HasMaxLength(50);

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
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SMID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.CustomerProfiles)
                    .HasForeignKey(d => d.Smid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SMID");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("OTP");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Otp1)
                    .HasMaxLength(50)
                    .HasColumnName("OTP");

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Questionid)
                    .ValueGeneratedNever()
                    .HasColumnName("questionid");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("datecreated")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .HasColumnName("question");
            });

            modelBuilder.Entity<UserDeviceInfo>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("UserDeviceInfo_pkey");

                entity.ToTable("UserDeviceInfo");

                entity.Property(e => e.DeviceId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.HardwareImei)
                    .HasMaxLength(1000)
                    .HasColumnName("HardwareIMEI");

                entity.Property(e => e.Imei)
                    .HasMaxLength(100)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(1000)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.IsCurrent).HasDefaultValueSql("true");

                entity.Property(e => e.Make).HasMaxLength(100);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Osversion)
                    .HasMaxLength(100)
                    .HasColumnName("OSVersion");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDeviceInfos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_walletuser");
            });

            modelBuilder.Entity<UserQa>(entity =>
            {
                entity.ToTable("UserQA");

                entity.Property(e => e.UserQaid)
                    .ValueGeneratedNever()
                    .HasColumnName("UserQAId");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users");
            });

            modelBuilder.Entity<WalletInfo>(entity =>
            {
                entity.ToTable("WalletInfo");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Availablebalance).HasColumnType("money");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(10)
                    .HasColumnName("CURRENCYCODE");

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Nuban).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.WalletInfos)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users");
            });

            modelBuilder.Entity<WalletTransfer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.BalanceAfterCredit).HasColumnType("money");

                entity.Property(e => e.BalanceAfterDebit).HasColumnType("money");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CurrencyCode).HasMaxLength(20);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

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
                    .HasConstraintName("FK_User");
            });

            modelBuilder.Entity<WalletUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Deviceimei)
                    .HasMaxLength(50)
                    .HasColumnName("deviceimei");

                entity.Property(e => e.Devicemake)
                    .HasMaxLength(50)
                    .HasColumnName("devicemake");

                entity.Property(e => e.Devicemodel)
                    .HasMaxLength(50)
                    .HasColumnName("devicemodel");

                entity.Property(e => e.Deviceos)
                    .HasMaxLength(50)
                    .HasColumnName("deviceos");

                entity.Property(e => e.Emailaddress)
                    .HasMaxLength(50)
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .HasColumnName("gender");

                entity.Property(e => e.Hardwareimei)
                    .HasMaxLength(50)
                    .HasColumnName("hardwareimei");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .HasColumnName("ipaddress");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

                entity.Property(e => e.Passwordsalt).HasColumnName("passwordsalt");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Referralcode)
                    .HasMaxLength(50)
                    .HasColumnName("referralcode");

                entity.Property(e => e.Transactionpin)
                    .HasMaxLength(10)
                    .HasColumnName("transactionpin");

                entity.Property(e => e.Transpin)
                    .HasMaxLength(1000)
                    .HasColumnName("transpin");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.HasSequence("apilogitem_seq");

            modelBuilder.HasSequence("customeraccountschema_seq");

            modelBuilder.HasSequence("customererror_seq");

            modelBuilder.HasSequence("customerprofile_seq");

            modelBuilder.HasSequence("otp_seq");

            modelBuilder.HasSequence("walletinfo_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
