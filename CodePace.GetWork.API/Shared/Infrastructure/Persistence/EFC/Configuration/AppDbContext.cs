using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Model.ValueObjects;
using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<CourseDetail> CourseDetails { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<WeeklyContest> WeeklyContests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
