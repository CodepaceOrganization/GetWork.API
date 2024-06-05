using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Technical Test Context

        builder.Entity<TechnicalTest>().HasKey(c => c.Id);
        builder.Entity<TechnicalTest>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalTest>().Property(c => c.Title).IsRequired().HasMaxLength(30);
        builder.Entity<TechnicalTest>().Property(c => c.Description).IsRequired().HasMaxLength(200);
        builder.Entity<TechnicalTest>().Property(c => c.ImageUrl).IsRequired().HasMaxLength(100);
        
        builder.Entity<TechnicalTask>().HasDiscriminator(u => u.Difficulty);
        builder.Entity<TechnicalTask>().HasKey(p => p.Id);
        builder.Entity<TechnicalTask>().HasDiscriminator<string>("task_difficulty")
            .HasValue<TechnicalTask>("task_base");
        
        builder.Entity<TechnicalTask>().OwnsOne(i => i.UserId,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Id).HasColumnName("UserId");
            });
        
        builder.Entity<TechnicalTest>().HasMany(t => t.TechnicalTasks);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}

