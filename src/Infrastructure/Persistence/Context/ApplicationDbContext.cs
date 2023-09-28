using Domain.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employer> Employers { get; set; }
    public DbSet<JobPosting> JobPostings { get; set; }
    public DbSet<ForbiddenWord> ForbiddenWords { get; set; }

    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=kariyernet;Username=root;Password=root");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employer>()
            .HasMany(jp => jp.JobPostings)
            .WithOne(e => e.Employer)
            .HasForeignKey(jp => jp.EmployerId);

        modelBuilder.Entity<Employer>().HasData(
            new Employer
            {
                Id = 1000000,
                CompanyName = "Kariyer Net",
                TelephoneNumber = "1234567890",
                Address = "Bursa",
                NumberOfJobPostings = 1,
            },
            new Employer
            {
                Id = 1000001,
                CompanyName = "Definex",
                TelephoneNumber = "9876543210",
                Address = "İstanbul",
                NumberOfJobPostings = 1,
            }
        );

        modelBuilder.Entity<JobPosting>().HasData(
            new JobPosting
            {
                Id = 1000000,
                Position = "Yazılım Uzmanı,",
                Description = "Açıklama",
                ExpirationDate = DateTime.UtcNow.AddMonths(1),
                Quality = 5,
                Type = EmploymentType.FullTime,
                Salary = 5000,
                EmployerId = 1000000,
            },
            new JobPosting
            {
                Id = 1000001,
                Position = "Yazılım Uzmanı",
                Description = "Açıklama",
                ExpirationDate = DateTime.UtcNow.AddMonths(2),
                Quality = 4,
                Type = EmploymentType.PartTime,
                Salary = 3000,
                EmployerId = 1000001,
            }
        );

        modelBuilder.Entity<ForbiddenWord>().HasData(
            new ForbiddenWord
            {
                Id = 1,
                Word = "Çirkin",
            },
            new ForbiddenWord
            {
                Id = 2,
                Word = "Pislik",
            }
        );
    }
}