namespace TaskWebApiCore.Model
{
    public class TodoListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public int Userid { get; set; }



    }
}
