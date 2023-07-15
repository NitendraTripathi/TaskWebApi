using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public class ToDoListItemRepo : IToDoListItemRepo
    {


        public TaskDbContext _DbContext { get; }

        public ToDoListItemRepo(TaskDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public TodoListItem AddTodoListItem(TodoListItem todo)
        {
            _DbContext.TodoListItems.Add(todo);
            
            _DbContext.SaveChanges();

            return todo;

        }

        public TodoListItem UpdateTodListIItem(TodoListItem todo)
        {


            _DbContext.TodoListItems.Update(todo);
            _DbContext.SaveChanges();

            return todo;


        }
        public List<TodoListItem> GetTodoListItems()
        {
            var todoitems = _DbContext.TodoListItems.ToList();
            return todoitems;
        }

        public TodoListItem GetTodoListItemId(int todoId)
        {
            var todo = _DbContext.TodoListItems.Where(x => x.Id == todoId).FirstOrDefault();
            return todo;
        }

        public List<TodoListItem> GetTodoListItemPending(int userid)
        {
            var todo = _DbContext.TodoListItems.Where(x => x.Userid == userid && x.Status=="Pending").ToList();
            return todo;
        }

        public List<TodoListItem> GetTodoListItemDone(int userid)
        {
            var todo = _DbContext.TodoListItems.Where(x => x.Userid == userid && x.Status=="Done").ToList();
            return todo;
        }


        public void DeleteTodoListItem(int todoid)
        {
            var todo = _DbContext.TodoListItems.Where(x => x.Id == todoid).FirstOrDefault();

            if (todo != null)
            {
                _DbContext.TodoListItems.Remove(todo);
                _DbContext.SaveChanges();
            }

        }
    }
}
