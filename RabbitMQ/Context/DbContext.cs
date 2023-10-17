using Microsoft.EntityFrameworkCore;
using RabbitMQ.Entity;

namespace RabbitMQ.Context;

public class DbContexts:DbContext
{
    public DbContexts(DbContextOptions<DbContexts> options) : base(options)
    {
    }

    public DbSet<Products> products { get; set; }
    public DbSet<Category> category { get; set; }
}