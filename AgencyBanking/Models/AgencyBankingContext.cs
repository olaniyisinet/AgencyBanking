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

        public virtual DbSet<Apilogitem> ApiLogItems { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<Customeraccountschema> CustomerAccountSchemas { get; set; }
        public virtual DbSet<Customererror> CustomerErrors { get; set; }
        public virtual DbSet<Customerprofile> CustomerProfiles { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Userdeviceinfo> UserDeviceInfos { get; set; }
        public virtual DbSet<Userqa> UserQas { get; set; }
        public virtual DbSet<Walletinfo> WalletInfos { get; set; }
        public virtual DbSet<Wallettransfer> WalletTransfers { get; set; }
        public virtual DbSet<Walletuser> WalletUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             //   optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AgencyBanking;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=tcp:kmndb.database.windows.net,1433;Initial Catalog=AgencyBanking;Persist Security Info=False;User ID=kmnadmin;Password=Okot@2020KMN;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Apilogitem>(entity =>
            {
                entity.ToTable("ApiLogItem");

                entity.Property(e => e.Method).HasMaxLength(100);

                entity.Property(e => e.Responsemillis).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("Beneficiary");

                entity.Property(e => e.Beneficiaryid).ValueGeneratedNever();

                entity.Property(e => e.Beneficiaryaccountname).HasMaxLength(50);

                entity.Property(e => e.Beneficiaryaccountnumber).HasMaxLength(50);

                entity.Property(e => e.Beneficiarybankcode).HasMaxLength(20);

                entity.Property(e => e.Beneficiarybankname).HasMaxLength(50);

                entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Userid).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Beneficiaries)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_Beneficiary_WalletUsers");
            });

            modelBuilder.Entity<Customeraccountschema>(entity =>
            {
                entity.ToTable(" CustomerAccountSchema");

                entity.Property(e => e.Accountgroup).HasMaxLength(50);

                entity.Property(e => e.Accountnumber).HasMaxLength(50);

                entity.Property(e => e.Accounttype).HasMaxLength(50);

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Userid).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerAccountSchemas)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_CustomerAccount_WalletUsers");
            });

            modelBuilder.Entity<Customererror>(entity =>
            {
                entity.HasKey(e => e.Refid);

                entity.ToTable("CustomerError");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BVN");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenum)
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

            modelBuilder.Entity<Customerprofile>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.ToTable("CustomerProfile");

                entity.Property(e => e.Customerid).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Agentcode).HasMaxLength(50);

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("BVN");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(100);

                entity.Property(e => e.Lastlogin).HasMaxLength(50);

                entity.Property(e => e.Phonenumber).HasMaxLength(50);

                entity.Property(e => e.Pryaccount).HasMaxLength(50);

                entity.Property(e => e.Referralcode).HasMaxLength(50);

                entity.Property(e => e.Rmdaocode)
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

                entity.Property(e => e.Questionid).ValueGeneratedNever();

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Question");
            });

            modelBuilder.Entity<Userdeviceinfo>(entity =>
            {
                entity.HasKey(e => e.Deviceid);

                entity.ToTable("UserDeviceInfo");

                entity.Property(e => e.Deviceid).ValueGeneratedNever();

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Hardwareimei)
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

                entity.Property(e => e.Iscurrent).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Userid).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDeviceInfos)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_UserDeviceInfo_WalletUsers");
            });

            modelBuilder.Entity<Userqa>(entity =>
            {
                entity.ToTable("UserQA");

                entity.Property(e => e.Userqaid)
                    .ValueGeneratedNever()
                    .HasColumnName("UserQAId");

                entity.Property(e => e.Answer)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Datecreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Userid).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.Questionid)
                    .HasConstraintName("FK_UserQA_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserQas)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_UserQA_WalletUsers");
            });

            modelBuilder.Entity<Walletinfo>(entity =>
            {
                entity.ToTable("WalletInfo");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(10)
                    .HasColumnName("CURRENCYCODE");

                entity.Property(e => e.Customerid).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

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

            modelBuilder.Entity<Wallettransfer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Currencycode).HasMaxLength(50);

                entity.Property(e => e.Datecreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fromact).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.Smid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SMID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Toacct).HasMaxLength(50);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.WalletTransfers)
                    .HasForeignKey(d => d.Smid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletTransfers_WalletUsers");
            });

            modelBuilder.Entity<Walletuser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Dateofbirth).HasColumnType("date");

                entity.Property(e => e.Deviceimei).HasMaxLength(50);

                entity.Property(e => e.Devicemake).HasMaxLength(50);

                entity.Property(e => e.Devicemodel).HasMaxLength(50);

                entity.Property(e => e.Deviceos).HasMaxLength(50);

                entity.Property(e => e.Emailaddress).HasMaxLength(50);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.Hardwareimei)
                    .HasMaxLength(50)
                    .HasColumnName("HardwareIMEI");

                entity.Property(e => e.Ipaddress).HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Referralcode).HasMaxLength(50);

                entity.Property(e => e.Transpin).HasMaxLength(1000);

                entity.Property(e => e.Transactionpin).HasMaxLength(10);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
