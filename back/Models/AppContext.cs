using BACK.Models;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<Servicos> Servicos { get; set; }
    public DbSet<Ongs> Ongs { get; set; }
    public DbSet<Cuidadores> Cuidadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=amor_pet.db");
    }
}