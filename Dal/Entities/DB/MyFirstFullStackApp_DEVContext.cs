using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Dal.Entities.DB
{
    public partial class MyFirstFullStackApp_DEVContext : DbContext, IMyFirstFullStackApp_DEVContext
    {
        public MyFirstFullStackApp_DEVContext()
        {
        }

        public MyFirstFullStackApp_DEVContext(DbContextOptions<MyFirstFullStackApp_DEVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            string connStr = config.GetConnectionString("MyFirstFullStackAppConnectionString");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answer__Question__7A672E12");
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__TestI__73BA3083");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Statement)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK__Result__AnswerId__7E37BEF6");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Result__Candidat__7D439ABD");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestQuestion>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TestQuest__Quest__778AC167");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestQuestion)
                    .HasForeignKey(d => d.TestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TestQuest__TestI__76969D2E");
            });
        }
    }
}
