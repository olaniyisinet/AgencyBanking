using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgencyBanking.Models
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
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<Apilogitem>(entity =>
            {
                entity.ToTable("apilogitem");

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
                entity.ToTable("beneficiary");

                entity.Property(e => e.Beneficiaryid)
                    .HasMaxLength(36)
                    .HasColumnName("beneficiaryid")
                    .IsFixedLength();

                entity.Property(e => e.Beneficiaryaccountname)
                    .HasMaxLength(50)
                    .HasColumnName("beneficiaryaccountname");

                entity.Property(e => e.Beneficiaryaccountnumber)
                    .HasMaxLength(50)
                    .HasColumnName("beneficiaryaccountnumber");

                entity.Property(e => e.Beneficiarybankcode)
                    .HasMaxLength(20)
                    .HasColumnName("beneficiarybankcode");

                entity.Property(e => e.Beneficiarybankname)
                    .HasMaxLength(50)
                    .HasColumnName("beneficiarybankname");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Customeraccountschema>(entity =>
            {
                entity.ToTable("customeraccountschema");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('customeraccountschema_seq'::regclass)");

                entity.Property(e => e.Accountgroup)
                    .HasMaxLength(50)
                    .HasColumnName("accountgroup");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(50)
                    .HasColumnName("accountnumber");

                entity.Property(e => e.Accounttype)
                    .HasMaxLength(50)
                    .HasColumnName("accounttype");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("currency");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Customererror>(entity =>
            {
                entity.HasKey(e => e.Refid)
                    .HasName("pk_customererror");

                entity.ToTable("customererror");

                entity.Property(e => e.Refid)
                    .HasColumnName("refid")
                    .HasDefaultValueSql("nextval('customererror_seq'::regclass)");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("bvn");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("datecreated");

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

            modelBuilder.Entity<Customerprofile>(entity =>
            {
                entity.HasKey(e => e.Customerid)
                    .HasName("pk_customerprofile");

                entity.ToTable("customerprofile");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasDefaultValueSql("nextval('customerprofile_seq'::regclass)");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Agentcode)
                    .HasMaxLength(50)
                    .HasColumnName("agentcode");

                entity.Property(e => e.Bvn)
                    .HasMaxLength(50)
                    .HasColumnName("bvn");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Deviceinfoexist).HasColumnName("deviceinfoexist");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Haspryaccount).HasColumnName("haspryaccount");

                entity.Property(e => e.Isagent).HasColumnName("isagent");

                entity.Property(e => e.Isdefaultpassword).HasColumnName("isdefaultpassword");

                entity.Property(e => e.Iswalletonly).HasColumnName("iswalletonly");

                entity.Property(e => e.Lastlogin)
                    .HasMaxLength(50)
                    .HasColumnName("lastlogin");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Pryaccount)
                    .HasMaxLength(50)
                    .HasColumnName("pryaccount");

                entity.Property(e => e.Questioncompleted).HasColumnName("questioncompleted");

                entity.Property(e => e.Referralcode)
                    .HasMaxLength(50)
                    .HasColumnName("referralcode");

                entity.Property(e => e.Rmdaocode)
                    .HasMaxLength(50)
                    .HasColumnName("rmdaocode");

                entity.Property(e => e.Rmemail)
                    .HasMaxLength(50)
                    .HasColumnName("rmemail");

                entity.Property(e => e.Rmmobile)
                    .HasMaxLength(50)
                    .HasColumnName("rmmobile");

                entity.Property(e => e.Rmname)
                    .HasMaxLength(50)
                    .HasColumnName("rmname");

                entity.Property(e => e.Smid)
                    .HasMaxLength(50)
                    .HasColumnName("smid");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("otp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('otp_seq'::regclass)");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Isused).HasColumnName("isused");

                entity.Property(e => e.Otp1)
                    .HasMaxLength(50)
                    .HasColumnName("otp");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Questionid)
                    .HasMaxLength(36)
                    .HasColumnName("questionid")
                    .IsFixedLength();

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Question1)
                    .HasMaxLength(1000)
                    .HasColumnName("question");
            });

            modelBuilder.Entity<Userdeviceinfo>(entity =>
            {
                entity.HasKey(e => e.Deviceid)
                    .HasName("pk_userdeviceinfo");

                entity.ToTable("userdeviceinfo");

                entity.Property(e => e.Deviceid)
                    .HasMaxLength(36)
                    .HasColumnName("deviceid")
                    .IsFixedLength();

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Hardwareimei)
                    .HasMaxLength(1000)
                    .HasColumnName("hardwareimei");

                entity.Property(e => e.Imei)
                    .HasMaxLength(100)
                    .HasColumnName("imei");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(1000)
                    .HasColumnName("ipaddress");

                entity.Property(e => e.Iscurrent).HasColumnName("iscurrent");

                entity.Property(e => e.Make)
                    .HasMaxLength(100)
                    .HasColumnName("make");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Osversion)
                    .HasMaxLength(100)
                    .HasColumnName("osversion");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Userqa>(entity =>
            {
                entity.ToTable("userqa");

                entity.Property(e => e.Userqaid)
                    .HasMaxLength(36)
                    .HasColumnName("userqaid")
                    .IsFixedLength();

                entity.Property(e => e.Answer)
                    .HasMaxLength(1000)
                    .HasColumnName("answer");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(3) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Questionid)
                    .HasMaxLength(36)
                    .HasColumnName("questionid")
                    .IsFixedLength();

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Walletinfo>(entity =>
            {
                entity.ToTable("walletinfo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('walletinfo_seq'::regclass)");

                entity.Property(e => e.Availablebalance).HasColumnName("availablebalance");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(10)
                    .HasColumnName("currencycode");

                entity.Property(e => e.Customerid)
                    .HasMaxLength(50)
                    .HasColumnName("customerid");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile");

                entity.Property(e => e.Nuban)
                    .HasMaxLength(50)
                    .HasColumnName("nuban");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Wallettransfer>(entity =>
            {
                entity.ToTable("wallettransfers");

                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .HasColumnName("id")
                    .IsFixedLength();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Balanceaftercredit).HasColumnName("balanceaftercredit");

                entity.Property(e => e.Balanceafterdebit).HasColumnName("balanceafterdebit");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(50)
                    .HasColumnName("currencycode");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("timestamp(6) without time zone")
                    .HasColumnName("datecreated");

                entity.Property(e => e.Fromact)
                    .HasMaxLength(50)
                    .HasColumnName("fromact");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .HasColumnName("remarks");

                entity.Property(e => e.Smid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("smid");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Toacct)
                    .HasMaxLength(50)
                    .HasColumnName("toacct");
            });

            modelBuilder.Entity<WalletUser_old>(entity =>
            {
                entity.ToTable("walletusers");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");

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

            modelBuilder.Entity<Walletuser>(entity =>
            {
                entity.ToTable("walletusers", "AgencyBanking");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");

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
