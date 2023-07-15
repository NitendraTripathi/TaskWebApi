using Microsoft.EntityFrameworkCore;
using TaskWebApiCore.Model;

namespace TaskWebApiCore.Data

{
    public class TaskDbContext: DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoListItem> TodoListItems { get; set; }
    
    }
}
