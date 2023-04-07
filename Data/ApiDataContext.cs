using ControleFinanceiroApi.Data.Mappings;
using ControleFinanceiroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroApi.Data;

public class ApiDataContext : DbContext
{
    public ApiDataContext(DbContextOptions<ApiDataContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Gasto>? Gastos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GastosMap());
    }
}