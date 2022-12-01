using Database.Controllers.Contracts;
using Database.Core;
using Database.Core.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Controllers.Infrastructure.Logs
{
    [Route("api/database/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public LogsController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Log> Get()
        {
            return _dbContext.Logs.ToList();
        }

        [HttpGet("{id}")]
        public Log Get(int id)
        {
            var log = _dbContext.Logs.FirstOrDefault(log => log.Id == id);

            if (log == null)
            {
                throw new Exception("NotFound");
            }

            return log;
        }

        [HttpPost]
        public void Post([FromBody] LogRequest request)
        {
            _dbContext.Logs.Add(request);
            _dbContext.SaveChanges();
        }
    }
}
