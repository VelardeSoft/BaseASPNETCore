using BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BaseASPNETCore.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor(); 
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User.Domain.Model.Aggregates.User>().HasKey(x => x.Id);
        builder.Entity<User.Domain.Model.Aggregates.User>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<User.Domain.Model.Aggregates.User>().Property(x => x.Email).IsRequired().HasMaxLength(256);
        builder.Entity<User.Domain.Model.Aggregates.User>().Property(x => x.Name).IsRequired().HasMaxLength(256);
        
        builder.UseSnakeCaseNamingConvention();
    }
}