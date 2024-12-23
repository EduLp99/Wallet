using WalletProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WalletProject.Infrastructure.Persistence;

public class WalletDbContext : DbContext
{
    public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<WalletUser> Wallets { get; set; }
}