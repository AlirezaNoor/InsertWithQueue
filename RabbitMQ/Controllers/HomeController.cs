using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Context;
using RabbitMQ.Entity;
using RabbitMQ.Services;

namespace RabbitMQ.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class HomeController:ControllerBase
{
    private readonly DbContexts _dbContexts;
    private readonly QueueProcessor _queueProcessor;

    public HomeController(DbContexts dbContexts, QueueProcessor queueProcessor)
    {
        _dbContexts = dbContexts;
        _queueProcessor = queueProcessor;
    }

    [HttpGet]
    public IActionResult Home()
    {
        return null;
    }

[HttpPost]
    public IActionResult senddata(Senddata pc)
    {
 _queueProcessor.create(pc);
        return Ok();
    }
}