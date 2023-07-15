using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskWebApiCore.Model;
using TaskWebApiCore.Services;

namespace TaskWebApiCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoListItemController : ControllerBase
    {
        readonly IToDoListItemRepo _obj;


        public ToDoListItemController(IToDoListItemRepo obj)
        {

            _obj = obj;


        }

        [HttpPost()]
        public IActionResult AddToDoItemList(TodoListItem item)
        {
            var Result = _obj.AddTodoListItem(item);
            return Ok(Result);
        }
        
        [HttpPut("")]
        public IActionResult UpdateToDoListItem([FromBody] TodoListItem item)
        {
            var result = _obj.UpdateTodListIItem(item);
            return Ok(result);
        }
        
        [HttpGet]
        public IActionResult GetAllToDoListItems()
        {
            var result = _obj.GetTodoListItems();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetToDoListById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo item id id");
            }
            else
            {
                return Ok(_obj.GetTodoListItemId(id));
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetToDoListByPending(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo item id id");
            }
            else
            {
                return Ok(_obj.GetTodoListItemPending(id));
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetToDoListByDone(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo item id id");
            }
            else
            {
                return Ok(_obj.GetTodoListItemDone(id));
            }

        }
        //delete book
        [HttpDelete("{id}")]
        public IActionResult DeleteToDoListItem(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid todo id");
            }
            else
            {
                _obj.DeleteTodoListItem(id);
                return Ok();
            }

        }
    }
}
