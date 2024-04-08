using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BusinessObject.Models
{
    public partial class AuthorInstitution2023DBContext : DbContext
    {
        public AuthorInstitution2023DBContext()
        {
        }

        public AuthorInstitution2023DBContext(DbContextOptions<AuthorInstitution2023DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CorrespondingAuthor> CorrespondingAuthors { get; set; }
        public virtual DbSet<InstitutionInformation> InstitutionInformations { get; set; }
        public virtual DbSet<MemberAccount> MemberAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfiguration configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CorrespondingAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__Correspo__70DAFC14E0455C73");

                entity.ToTable("CorrespondingAuthor");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(20)
                    .HasColumnName("AuthorID");

                entity.Property(e => e.AuthorBirthday).HasColumnType("datetime");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Skills).HasMaxLength(200);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.CorrespondingAuthors)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Correspon__Insti__3B75D760");
            });

            modelBuilder.Entity<InstitutionInformation>(entity =>
            {
                entity.HasKey(e => e.InstitutionId)
                    .HasName("PK__Institut__8DF6B94DB70E41B6");

                entity.ToTable("InstitutionInformation");

                entity.Property(e => e.InstitutionId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstitutionID");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InstitutionDescription).HasMaxLength(250);

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<MemberAccount>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__MemberAc__0CF04B38FB253C5A");

                entity.ToTable("MemberAccount");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemberPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
