using ASP.NET_Web_API.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System;
using AutoMapper;
using ASP.NET_Web_API.Contracts.Home;

namespace ASP.NET_Web_API.Controllers
{
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("info")] 
        public IActionResult Info()
        {                                        
            var infoResponse = _mapper.Map<HomeOptions,InfoResponse>(_options.Value);
                        
            return StatusCode(200, infoResponse);
        }
    }
}
