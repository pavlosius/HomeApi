using System;
using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Devices;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
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

        //TODO: Задание - добавить метод на получение всех существующих комнат
        /// <summary>
        /// Получение всех существующих комнат
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRooms()
        {
            var existingRooms = await _repository.GetAllRooms();

            var resp = new GetRoomsResponse
            {
                RoomAmount = existingRooms.Length,
                Rooms = _mapper.Map<Room[], RoomView[]>(existingRooms)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Добавление комнаты
        /// </summary>
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

        /// <summary>
        /// Удаление существующей комнаты
        /// </summary>
        [HttpPost]
        [Route("{name}")]
        public async Task<IActionResult> Delete(
            [FromRoute] String name)
        {
            var room = await _repository.GetRoomByName(name);
            if (room == null)
                return StatusCode(400, $"Ошибка: Комнаты с именем {room} не существует.");

            await _repository.DeleteRoom(room);

            return StatusCode(200, $"Комната {room.Name} удалена!");
        }
    }
}