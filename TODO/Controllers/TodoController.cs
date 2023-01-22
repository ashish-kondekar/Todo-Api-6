using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TODO.BLL.IServices;
using TODO.BLL.Models.Request;
using TODO.Domain.Entities;

namespace TODO.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            this._todoService = todoService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get all todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await this._todoService.GetAll();
            return Ok(todos);
        }

        /// <summary>
        /// Get single todo item by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var todo = await _todoService.GetById(id);

            if (todo is null)
                return NotFound();

            return Ok(todo);
        }

        /// <summary>
        /// Add todo item
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TodoAddRequest todo)
        {
            var item = _mapper.Map<Todo>(todo);
            await _todoService.Add(item);
            return CreatedAtAction(nameof(Get), routeValues: new { id = item.Id }, item);
        }

        /// <summary>
        /// Update todo item
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TodoUpdateRequest todo)
        {
            var item = _mapper.Map<Todo>(todo);
            await _todoService.Update(item);
            return NoContent();
        }
    }
}
