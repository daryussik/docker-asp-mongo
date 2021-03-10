using System;
using AspNetService.Models;
using AspNetService.Mongo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspNetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IDbContext _dbContext;
        
        public MessageController(IConfiguration config)
        {
            _dbContext = new DbContext(new MongoDbConfig(config));
        }

        [HttpPost]
        public IActionResult AddMessage([FromQuery]string message)
        {
            _dbContext.Messages.InsertOne(new MessageDataModel()
            {
                Message = message,
                DateUtc = DateTime.UtcNow
            });

            return Ok();
        }
    }
}