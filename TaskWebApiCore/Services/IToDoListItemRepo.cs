using TaskWebApiCore.Data;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Services
{
    public interface IToDoListItemRepo
    {
        TaskDbContext _DbContext { get; }

        TodoListItem AddTodoListItem(TodoListItem todo);
        void DeleteTodoListItem(int todoid);
        TodoListItem GetTodoListItemId(int todoId);
        List<TodoListItem> GetTodoListItems();
        TodoListItem UpdateTodListIItem(TodoListItem todo);
        List<TodoListItem> GetTodoListItemPending(int todoId);
        List<TodoListItem> GetTodoListItemDone(int todoId);
    }
}