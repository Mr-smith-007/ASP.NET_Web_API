using ASP.NET_Web_API.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System;

namespace ASP.NET_Web_API.Controllers
{
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        public HomeController(IOptions<HomeOptions> options)
        {
            _options = options;
        }

        [HttpGet]
        [Route("info")] 
        public IActionResult Info()
        {            
            var pageResult = new StringBuilder();
                       
            pageResult.Append($"Добро пожаловать в API вашего дома!{Environment.NewLine}");
            pageResult.Append($"Здесь вы можете посмотреть основную информацию.{Environment.NewLine}"); 
            pageResult.Append($"{Environment.NewLine}"); 
            pageResult.Append($"Количество этажей: {_options.Value.FloorAmount}{Environment.NewLine}");
            pageResult.Append($"Стационарный телефон: {_options.Value.Telephone}{Environment.NewLine}"); 
            pageResult.Append($"Тип отопления: {_options.Value.Heating}{Environment.NewLine}"); 
            pageResult.Append($"Напряжение электросети: {_options.Value.CurrentVolts}{Environment.NewLine}"); 
            pageResult.Append($"Подключен к газовой сети: {_options.Value.GasConnected}{Environment.NewLine}"); 
            pageResult.Append($"Жилая площадь: {_options.Value.Area} м2{Environment.NewLine}"); 
            pageResult.Append($"Материал: {_options.Value.Material}{Environment.NewLine}"); 
            pageResult.Append($"{Environment.NewLine}"); 
            pageResult.Append($"Адрес: {_options.Value.Address.Street} {_options.Value.Address.House}/{_options.Value.Address.Building}{Environment.NewLine}");

            
            return StatusCode(200, pageResult.ToString());
        }
    }
}
