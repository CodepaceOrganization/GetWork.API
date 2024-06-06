using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;
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

        builder.Entity<TechnicalTest>().HasKey(t => t.Id);
        builder.Entity<TechnicalTest>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalTest>().Property(t => t.Title).IsRequired().HasMaxLength(30);
        builder.Entity<TechnicalTest>().Property(t => t.Description).IsRequired().HasMaxLength(200);
        builder.Entity<TechnicalTest>().Property(t => t.ImageUrl).IsRequired().HasMaxLength(100);
        
        builder.Entity<TechnicalTask>().HasKey(t => t.Id);
        builder.Entity<TechnicalTask>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalTask>().Property(t => t.Description).IsRequired().HasMaxLength(200);
        builder.Entity<TechnicalTask>().Property(t => t.Difficulty).IsRequired();
        builder.Entity<TechnicalTask>().Property(t => t.Progress).IsRequired();
        
        builder.Entity<TechnicalTask>()
            .Property(t => t.UserId)
            .HasConversion(
                v => v.userId, 
                v => new UserId(v));
        
        builder.Entity<TechnicalTask>()
            .HasOne<TechnicalTest>()
            .WithMany(t => t.TechnicalTasks)
            .HasForeignKey(t => t.TechnicalTestId);        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}

