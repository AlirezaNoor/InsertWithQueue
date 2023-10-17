using Microsoft.EntityFrameworkCore;
using RabbitMQ.Context;
using RabbitMQ.Entity;

namespace RabbitMQ.Services;

public class QueueProcessor
{
    private readonly DbContexts context;

    public QueueProcessor(DbContexts contexts)
    {
        context = contexts;
    }

    public void create(Senddata pc)
    {
        Queue<Object> myQueue = new Queue<Object>();


        // اضافه کردن اشیاء به صف
        var newItem1 = new Products
        {
            name = pc.Products.name,
            description = pc.Products.description
        };
        myQueue.Enqueue(newItem1);

        var newItem2 = new Category
        {
            name = pc.Category.description,
            description = pc.Category.description
        };
        myQueue.Enqueue(newItem2);

        // ذخیره اشیاء از صف به دیتابیس

        while (myQueue.Count > 0)
        {
            var item = myQueue.Dequeue();
            if (item is Products products)
            {
                context.products.Add(products);
            }

            var item2 = myQueue.Dequeue();
            if (item2 is Category category)
            {
                context.category.Add(category);
            }
        }


        context.SaveChanges();
    }
}