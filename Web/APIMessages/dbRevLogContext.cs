using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web.APIMessages
{
    public partial class dbRevLogContext : DbContext
    {
        public dbRevLogContext()
        {
        }

        public dbRevLogContext(DbContextOptions<dbRevLogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirCarrier> AirCarrier { get; set; }
        public virtual DbSet<AirFreightRates> AirFreightRates { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Awbinventory> Awbinventory { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingDetail> BookingDetail { get; set; }
        public virtual DbSet<CargoDetail> CargoDetail { get; set; }
        public virtual DbSet<CargoStatusList> CargoStatusList { get; set; }
        public virtual DbSet<CartonSpecs> CartonSpecs { get; set; }
        public virtual DbSet<Consignee> Consignee { get; set; }
        public virtual DbSet<CurrencyList> CurrencyList { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DestinationCharges> DestinationCharges { get; set; }
        public virtual DbSet<DestinationChargesDd> DestinationChargesDd { get; set; }
        public virtual DbSet<EmailContents> EmailContents { get; set; }
        public virtual DbSet<GlobalAirports> GlobalAirports { get; set; }
        public virtual DbSet<IncoTerms> IncoTerms { get; set; }
        public virtual DbSet<InstructionsForm> InstructionsForm { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<OriginCharges> OriginCharges { get; set; }
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<RevLogUser> RevLogUser { get; set; }
        public virtual DbSet<SuperAdmin> SuperAdmin { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=dbRevLog;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AirCarrier>(entity =>
            {
                entity.Property(e => e.AirCarrierId).ValueGeneratedNever();

                entity.Property(e => e.CarrierName).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepEmail).IsUnicode(false);
            });

            modelBuilder.Entity<AirFreightRates>(entity =>
            {
                entity.HasKey(e => e.AirFreightRateId);

                entity.HasIndex(e => e.AirCarrierId)
                    .HasName("IX_FK_AirFreightRates_AirCarriers");

                entity.Property(e => e.AirFreightRateId).ValueGeneratedNever();

                entity.Property(e => e.Commodity).IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AirCarrier)
                    .WithMany(p => p.AirFreightRates)
                    .HasForeignKey(d => d.AirCarrierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AirFreightRates_AirCarriers");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspNetUserRoles)
                    .HasForeignKey<AspNetUserRoles>(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Awbinventory>(entity =>
            {
                entity.ToTable("AWBInventory");

                entity.Property(e => e.Awbnumber)
                    .HasColumnName("AWBNumber")
                    .IsUnicode(false);

                entity.Property(e => e.DateAcquired).HasColumnType("datetime");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasIndex(e => e.QuotationId)
                    .HasName("IX_FK_Booking_Quotation");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.Awbnumber)
                    .HasColumnName("AWBNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBooking).HasColumnType("datetime");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Booking_Quotation");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasIndex(e => e.BookingId)
                    .HasName("IX_FK_BookingDetail_Booking");

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Etd)
                    .HasColumnName("ETD")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransShipmentPort1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransShipmentPort2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetail)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BookingDetail_Booking");
            });

            modelBuilder.Entity<CargoDetail>(entity =>
            {
                entity.HasIndex(e => e.DestinationId)
                    .HasName("IX_FK_CargoDetails_GlobalAirports1");

                entity.HasIndex(e => e.IncoTermsId)
                    .HasName("IX_FK_CargoDetails_IncoTerms");

                entity.HasIndex(e => e.OriginId)
                    .HasName("IX_FK_CargoDetails_GlobalAirports");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("IX_FK_CargoDetails_Quotation");

                entity.Property(e => e.CargoDetailId).ValueGeneratedNever();

                entity.Property(e => e.CargoDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.Commodity).IsUnicode(false);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.CargoDetailDestination)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK_CargoDetails_GlobalAirports1");

                entity.HasOne(d => d.IncoTerms)
                    .WithMany(p => p.CargoDetail)
                    .HasForeignKey(d => d.IncoTermsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CargoDetails_IncoTerms");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.CargoDetailOrigin)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_CargoDetails_GlobalAirports");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.CargoDetail)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CargoDetails_Quotation");
            });

            modelBuilder.Entity<CargoStatusList>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_CargoStatusLists");

                entity.Property(e => e.StatusDescription).IsUnicode(false);
            });

            modelBuilder.Entity<CartonSpecs>(entity =>
            {
                entity.HasIndex(e => e.CargoDetailId)
                    .HasName("IX_FK_CartonSpecs_CargoDetails");

                entity.HasOne(d => d.CargoDetail)
                    .WithMany(p => p.CartonSpecs)
                    .HasForeignKey(d => d.CargoDetailId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CartonSpecs_CargoDetails");
            });

            modelBuilder.Entity<Consignee>(entity =>
            {
                entity.HasIndex(e => e.ConsigneeOf)
                    .HasName("IX_FK_Consignee_Customer");

                entity.HasIndex(e => e.OperatorId)
                    .HasName("IX_FK_Consignee_Operator");

                entity.HasIndex(e => e.RevLogUserId)
                    .HasName("IX_FK_Consignee_RevLogUser");

                entity.Property(e => e.ConsigneeSince).HasColumnType("datetime");

                entity.HasOne(d => d.ConsigneeOfNavigation)
                    .WithMany(p => p.Consignee)
                    .HasForeignKey(d => d.ConsigneeOf)
                    .HasConstraintName("FK_Consignee_Customer");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Consignee)
                    .HasForeignKey(d => d.OperatorId)
                    .HasConstraintName("FK_Consignee_Operator");

                entity.HasOne(d => d.RevLogUser)
                    .WithMany(p => p.Consignee)
                    .HasForeignKey(d => d.RevLogUserId)
                    .HasConstraintName("FK_Consignee_RevLogUser");
            });

            modelBuilder.Entity<CurrencyList>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK_CurrencyLists");

                entity.Property(e => e.CurrencyId).ValueGeneratedNever();

                entity.Property(e => e.CurrencyAbbr).HasMaxLength(10);

                entity.Property(e => e.CurrencyName).HasMaxLength(10);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.RevLogUserId)
                    .HasName("IX_FK_Customer_RevLogUser");

                entity.Property(e => e.CustomerSince).HasColumnType("datetime");

                entity.HasOne(d => d.RevLogUser)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.RevLogUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_RevLogUser");
            });

            modelBuilder.Entity<DestinationCharges>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.DestinationCharges)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("FK_DestinationCharges_Quotation");
            });

            modelBuilder.Entity<DestinationChargesDd>(entity =>
            {
                entity.ToTable("DestinationChargesDD");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("IX_FK_DestinationChargesDD_Quotation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.DestinationChargesDd)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DestinationChargesDD_Quotation");
            });

            modelBuilder.Entity<EmailContents>(entity =>
            {
                entity.HasKey(e => e.FormatId);

                entity.HasIndex(e => e.OperatorId)
                    .HasName("IX_FK_EmailContent_Operator");

                entity.Property(e => e.FormatId).ValueGeneratedNever();

                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.SenderEmail).IsUnicode(false);

                entity.Property(e => e.Signature).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.EmailContents)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailContent_Operator");
            });

            modelBuilder.Entity<GlobalAirports>(entity =>
            {
                entity.HasKey(e => e.AirportId);

                entity.Property(e => e.Altitude).HasColumnName("altitude");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IataCode)
                    .HasColumnName("iata_code")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IcaoCode)
                    .HasColumnName("icao_code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LatDecimal).HasColumnName("lat_decimal");

                entity.Property(e => e.LatDeg).HasColumnName("lat_deg");

                entity.Property(e => e.LatDir)
                    .HasColumnName("lat_dir")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LatMin).HasColumnName("lat_min");

                entity.Property(e => e.LatSec).HasColumnName("lat_sec");

                entity.Property(e => e.LonDecimal).HasColumnName("lon_decimal");

                entity.Property(e => e.LonDeg).HasColumnName("lon_deg");

                entity.Property(e => e.LonDir)
                    .HasColumnName("lon_dir")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LonMin).HasColumnName("lon_min");

                entity.Property(e => e.LonSec).HasColumnName("lon_sec");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IncoTerms>(entity =>
            {
                entity.Property(e => e.IncoTermsId).ValueGeneratedNever();

                entity.Property(e => e.IncoTermsAbbr)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IncoTermsDescription).IsUnicode(false);
            });

            modelBuilder.Entity<InstructionsForm>(entity =>
            {
                entity.HasIndex(e => e.QuotationId)
                    .HasName("IX_FK_InstructionsForm_Quotation");

                entity.Property(e => e.InstructionsFormId).ValueGeneratedNever();

                entity.Property(e => e.ApproxWeight).HasMaxLength(10);

                entity.Property(e => e.Commodity).HasMaxLength(10);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(10);

                entity.Property(e => e.FormEnumber)
                    .HasColumnName("FormENumber")
                    .HasMaxLength(10);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(10);

                entity.Property(e => e.MarksAndNumber).HasMaxLength(10);

                entity.Property(e => e.NotifyParty).HasMaxLength(10);

                entity.Property(e => e.ShipperAddress).IsUnicode(false);

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.InstructionsForm)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_InstructionsForm_Quotation");
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasIndex(e => e.RevLogUserId)
                    .HasName("IX_FK_Operator_RevLogUser");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ntn)
                    .IsRequired()
                    .HasColumnName("NTN")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.RevLogUser)
                    .WithMany(p => p.Operator)
                    .HasForeignKey(d => d.RevLogUserId)
                    .HasConstraintName("FK_Operator_RevLogUser");
            });

            modelBuilder.Entity<OriginCharges>(entity =>
            {
                entity.HasIndex(e => e.CarrierId)
                    .HasName("IX_FK_OriginCharges_AirCarriers1");

                entity.HasIndex(e => e.QuotationId)
                    .HasName("IX_FK_OriginCharges_Quotation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.OriginCharges)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OriginCharges_AirCarriers1");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.OriginCharges)
                    .HasForeignKey(d => d.QuotationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_OriginCharges_Quotation");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.HasIndex(e => e.OperatorId)
                    .HasName("IX_FK_Quotation_Operator");

                entity.HasIndex(e => e.StatusId)
                    .HasName("IX_FK_Quotation_CargoStatusList");

                entity.Property(e => e.QuotationId).ValueGeneratedNever();

                entity.Property(e => e.DateOfInquiry).HasColumnType("datetime");

                entity.Property(e => e.TypeOfTransport)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Quotation)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quotation_Customer");

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Quotation)
                    .HasForeignKey(d => d.OperatorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quotation_Operator");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Quotation)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Quotation_CargoStatusList");
            });

            modelBuilder.Entity<RevLogUser>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberSince).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SuperAdmin>(entity =>
            {
                entity.HasIndex(e => e.RevLogUserId)
                    .HasName("IX_FK_SuperAdmin_RevLogUser");

                entity.Property(e => e.AdminSince).HasColumnType("date");
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId);

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });
        }
    }
}
