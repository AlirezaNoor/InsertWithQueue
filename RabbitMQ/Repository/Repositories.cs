using Microsoft.EntityFrameworkCore;
using RabbitMQ.Context;
using RabbitMQ.Entity;

namespace RabbitMQ.Repository;

public class Repositories
{
    private readonly DbContexts _dbContexts;

    public Repositories(DbContexts dbContexts)
    {
        _dbContexts = dbContexts;
    }

    public void CreateProducts(Products product)
    {
        _dbContexts.Add(product);
        _dbContexts.SaveChanges();
    }
    public void CreateCategories(Category category)
    {
        _dbContexts.Add(category);
        _dbContexts.SaveChanges();
    }
}