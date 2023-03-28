using Microsoft.EntityFrameworkCore;
using POC.GoldenRaspberryAwards.API.Domain.Entities;

namespace POC.GoldenRaspberryAwards.API.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Movie> Movies { get; set; }

}
