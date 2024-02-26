using ASP.NET_Web_API.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using AutoMapper;
using ASP.NET_Web_API.Contracts.Devices;


namespace ASP.NET_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] AddDeviceRequest request)
        {
            return StatusCode(200, $"Устройство {request.Name} добавлено");
        }
    }
}
