using Microsoft.EntityFrameworkCore;
using VoorbeeldAPI.Models;

namespace VoorbeeldAPI.Shared;

public class VoorbeeldDbContext(DbContextOptions<VoorbeeldDbContext> options) : DbContext(options)
{
    public virtual DbSet<Client> Clients { get; set; }
}
