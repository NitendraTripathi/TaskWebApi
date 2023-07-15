using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebApiCore.Model;
using TaskWebApiCore.Services;

namespace TaskWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        readonly IToDoListRepo _obj;


        public TodoListController(IToDoListRepo obj)
        {

            _obj = obj;


        }

        [HttpPost()]
        public IActionResult AddToDoList(TodoList item)
        {
            var Result = _obj.AddToDoList(item);
            return Ok(Result);
        }

        [HttpPut("")]
        public IActionResult UpdateToDoList([FromBody] TodoList item)
        {
            var result = _obj.UpdateToDoItem(item);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetToDoListItems()
        {
            var result = _obj.GetTodoItems();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetToDoListId(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo todo id id");
            }
            else
            {
                return Ok(_obj.GetToDoListId(id));
            }

        }
        //delete book
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo id");
            }
            else
            {
                _obj.DeleteToDoList(id);
                return Ok();
            }

        }
    }
}
