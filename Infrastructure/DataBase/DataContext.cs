using Domain.Model;
using Domain.Model.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Infrastructure.DataBase;

public class DataContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<Role> Roles { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.CreatedBy = _httpContextAccessor.HttpContext?.User
                        .FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
                    entity.Entity.CreatedDate = DateTime.UtcNow;
                    entity.Entity.IsActive = true;
                    entity.Entity.UpdatedBy = string.Empty;
                    break;

                case EntityState.Deleted:
                    entity.State = EntityState.Modified;
                    entity.Entity.IsActive = false;
                    break;

                case EntityState.Modified:
                    entity.Entity.UpdatedBy = _httpContextAccessor.HttpContext?.User
                        .FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
                    entity.Entity.UpdatedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql()
         .UseSnakeCaseNamingConvention();
    }
}
