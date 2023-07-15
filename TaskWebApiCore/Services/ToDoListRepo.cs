using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public class ToDoListRepo : IToDoListRepo
    {

        public TaskDbContext _DbContext { get; }

        public ToDoListRepo(TaskDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public TodoList AddToDoList(TodoList todolst)
        {
            _DbContext.TodoLists.Add(todolst);
            _DbContext.SaveChanges();

            return todolst;

        }

        public TodoList UpdateToDoItem(TodoList todolst)
        {

            _DbContext.TodoLists.Update(todolst);
            _DbContext.SaveChanges();
            return todolst;
        }
        public List<TodoList> GetTodoItems()
        {
            var todoLists = _DbContext.TodoLists.ToList();
            return todoLists;
        }

        public TodoList GetToDoListId(int todolstId)
        {
            var todolst = _DbContext.TodoLists.Where(x => x.Id == todolstId).FirstOrDefault();
            return todolst;
        }


        public void DeleteToDoList(int todoidlst)
        {
            var todolst = _DbContext.TodoLists.Where(x => x.Id == todoidlst).FirstOrDefault();

            if (todolst != null)
            {
                _DbContext.TodoLists.Remove(todolst);
                _DbContext.SaveChanges();
            }

        }
    }
}
