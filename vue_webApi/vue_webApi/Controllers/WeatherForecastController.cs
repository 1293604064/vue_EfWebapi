using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vue_webApi.Entities;

namespace vue_webApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("any")]  //跨域中间件
    [ApiController]
    [Route("[controller]")]
    
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AskquestionsContext _context;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, AskquestionsContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IEnumerable<User> Get()
        {
            return _context.User;
        }
        /// <summary>
        /// 获取id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public int Get(int id)
        {
            return id;
        }
    }
}
