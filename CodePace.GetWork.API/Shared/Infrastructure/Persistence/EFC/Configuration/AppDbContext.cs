using CodePace.GetWork.API.Plans.Domain.Model.Aggregates;
using CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CodePace.GetWork.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }

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
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}