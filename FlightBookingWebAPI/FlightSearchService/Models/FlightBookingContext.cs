using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FlightSearchService.Models
{
    public partial class FlightBookingContext : DbContext
    {
        public FlightBookingContext()
        {
        }

        public FlightBookingContext(DbContextOptions<FlightBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAirlineInventory> TblAirlineInventories { get; set; }
        public virtual DbSet<TblAirlineRegistration> TblAirlineRegistrations { get; set; }
        public virtual DbSet<TblBookingDetail> TblBookingDetails { get; set; }
        public virtual DbSet<TblPassengerDetail> TblPassengerDetails { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAirlineInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId);

                entity.ToTable("tblAirlineInventory");

                entity.Property(e => e.Airline).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FromPlace).HasMaxLength(50);

                entity.Property(e => e.InstrumentUsed).HasMaxLength(50);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.ToPlace).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<TblAirlineRegistration>(entity =>
            {
                entity.ToTable("tblAirlineRegistration");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<TblBookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_tblFlightBooking");

                entity.ToTable("tblBookingDetails");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Pnr).HasColumnName("PNR");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPassengerDetail>(entity =>
            {
                entity.HasKey(e => e.PassDetailsId);

                entity.ToTable("tblPassengerDetails");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.MealOption).HasMaxLength(50);

                entity.Property(e => e.PassengerGender)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PassengerName).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.LoginType).HasMaxLength(10);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
