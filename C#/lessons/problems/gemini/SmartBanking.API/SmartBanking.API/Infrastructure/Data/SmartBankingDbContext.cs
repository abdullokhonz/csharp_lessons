using Microsoft.EntityFrameworkCore;
using SmartBanking.API.Entities;

namespace SmartBanking.API.Infrastructure.Data;

public class SmartBankingDbContext : DbContext
{
    public SmartBankingDbContext(DbContextOptions<SmartBankingDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Магия авто-регистрации всех конфигураций из текущей папки!
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartBankingDbContext).Assembly);
    }
}
