using CodePace.GetWork.API.IAM.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Profiles.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
<<<<<<< HEAD
=======
using CodePace.GetWork.API.contest.Domain.Model.ValueObjects;
using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
>>>>>>> 008aada5d1ab8e8a495172e98297634b108b9ffb
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using DefaultNamespace;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<WeeklyContest> WeeklyContests { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
             // Configuración para Contest
            builder.Entity<Contest>()
                .HasKey(p => p.Id);
            builder.Entity<Contest>()
                .HasMany(c => c.WeeklyContests)
                .WithOne(wc => wc.Contest)
                .HasForeignKey(wc => wc.ContestId);


            // Configuración para WeeklyContest
            builder.Entity<WeeklyContest>()
                .HasOne(wc => wc.Contest)
                .WithMany(c => c.WeeklyContests)
                .HasForeignKey(wc => wc.ContestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para CourseDetail

            builder.Entity<CourseDetail>()
                .ToTable("CourseDetail");
            builder.Entity<CourseDetail>().HasKey(cd => cd.Id);
            builder.Entity<CourseDetail>().Property(cd => cd.Id).ValueGeneratedOnAdd();
            
            builder.Entity<CourseDetail>()
                .HasMany(c => c.Goals)
                .WithOne(g => g.CourseDetail)
                .HasForeignKey(g => g.CourseDetailId);
            
            // Configuración para Asset
            builder.Entity<Asset>().HasDiscriminator(a => a.Type);
            builder.Entity<Asset>().HasKey(p => p.Id);
            builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
                .HasValue<Asset>("asset_base")
                .HasValue<ImageAssetContest>("asset_image");

            builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier, ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
            
            
            builder.Entity<ImageAssetContest>().Property(p => p.ImageUri).IsRequired();
            
            
            // Subscription Context
            
            builder.Entity<Subscription>().HasKey(s => s.Id);
            builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Subscription>().Property(s => s.Name).IsRequired().HasMaxLength(50);
            

            // Technical Test Context

            builder.Entity<TechnicalTest>().HasKey(t => t.Id);
            builder.Entity<TechnicalTest>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TechnicalTest>().Property(t => t.Title).IsRequired().HasMaxLength(30);
            builder.Entity<TechnicalTest>().Property(t => t.Description).IsRequired().HasMaxLength(200);
            builder.Entity<TechnicalTest>().Property(t => t.ImageUrl).IsRequired().HasMaxLength(512);
            builder.Entity<TechnicalTest>().Property(t => t.TestType).IsRequired().HasMaxLength(50).HasConversion<String>();

            builder.Entity<TechnicalTask>().HasKey(t => t.Id);
            builder.Entity<TechnicalTask>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TechnicalTask>().Property(t => t.Description).IsRequired().HasMaxLength(200);
            builder.Entity<TechnicalTask>().Property(t => t.Difficulty).IsRequired().HasMaxLength(50).HasConversion<String>();

            builder.Entity<TaskProgress>()
                .HasKey(tp => new { tp.TechnicalTaskId, tp.UserId });

            builder.Entity<TaskProgress>().Property(t => t.Progress).IsRequired().HasMaxLength(50).HasConversion<String>();
            builder.Entity<TechnicalTest>()
                .HasMany(t => t.TechnicalTasks)
                .WithOne()
                .HasForeignKey(t => t.TechnicalTestId);

            builder.Entity<TaskProgress>()
                .HasOne(tp => tp.TechnicalTask)
                .WithOne(tt => tt.TaskProgress)
                .HasForeignKey<TaskProgress>(tp => tp.TechnicalTaskId);
            builder.Entity<TaskProgress>()
                .HasIndex(tp => tp.TechnicalTaskId) 
                .IsUnique(false); 
           
            // Profiles Context
        
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().OwnsOne(p => p.Name,
                n =>
                {
                    n.WithOwner().HasForeignKey("Id");
                    n.Property(p => p.FirstName).HasColumnName("FirstName");
                    n.Property(p => p.LastName).HasColumnName("LastName");
                });

            builder.Entity<Profile>().OwnsOne(p => p.Email,
                e =>
                {
                    e.WithOwner().HasForeignKey("Id");
                    e.Property(a => a.Address).HasColumnName("EmailAddress");
                });

            builder.Entity<Profile>().OwnsOne(p => p.Address,
                a =>
                {
                    a.WithOwner().HasForeignKey("Id");
                    a.Property(s => s.Street).HasColumnName("AddressStreet");
                    a.Property(s => s.Number).HasColumnName("AddressNumber");
                    a.Property(s => s.City).HasColumnName("AddressCity");
                    a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                    a.Property(s => s.Country).HasColumnName("AddressCountry");
                });

            
            // IAM Context
        
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
