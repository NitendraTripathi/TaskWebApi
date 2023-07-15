using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public interface IToDoListRepo
    {
        TaskDbContext _DbContext { get; }

        TodoList AddToDoList(TodoList todolst);
        void DeleteToDoList(int todoidlst);
        List<TodoList> GetTodoItems();
        TodoList GetToDoListId(int todolstId);
        TodoList UpdateToDoItem(TodoList todolst);
    }
}