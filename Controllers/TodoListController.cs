using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Services.Interfaces;

namespace RepositoryDesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;
        private readonly ITodoService _todoService;

        public TodoListController(ILogger<TodoListController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Todo> GetAll()
        {
            return _todoService.Get();
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var todo = _todoService.GetById(id);
                return Ok(todo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost(Name = "Add")]
        public IActionResult Add(Todo todo)
        {
            _todoService.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}", Name = "Update")]
        public IActionResult Update(int id, Todo todo)
        {
            todo.Id = id;
            try
            {
                _todoService.Update(todo);
                return Ok(todo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _todoService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting todo.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPatch("{id}/complete", Name = "MarkComplete")]
        public IActionResult MarkComplete(int id)
        {
            try
            {
                _todoService.MarkComplete(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking todo as complete.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
