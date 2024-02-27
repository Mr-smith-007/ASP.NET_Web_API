using ASP.NET_Web_API.Data.Models;
using ASP.NET_Web_API.Data.Repos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ASP.NET_Web_API.Contracts.Models.Rooms;

namespace ASP.NET_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;

        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }

            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] EditRoomRequest request)
        {
            var roomForEdit = await _repository.GetRoomById(id);
            if (roomForEdit == null)
            {
                return StatusCode(400, $"Комната с id: {id} не найдена");
            }

            Room roomWithEdit = new Room
            {
                Id = id,
                AddDate = roomForEdit.AddDate,
                Area = request.NewArea,
                GasConnected = request.NewGasConnected,
                Name = request.NewName,
                Voltage = request.NewVoltage
            };
            await _repository.UpdateRoom(roomWithEdit);
            return StatusCode(200, $"Комната с id: {id} успешно обновлена " +
                $"{Environment.NewLine} Новые значения комнаты:" +
                $"{Environment.NewLine} Площадь = {roomWithEdit.Area}" +
                $"{Environment.NewLine} Есть газ? = {roomWithEdit.GasConnected}" +
                $"{Environment.NewLine} Название = {roomWithEdit.Name}" +
                $"{Environment.NewLine} Напряжение = {roomWithEdit.Voltage}");
        }
    }
}
