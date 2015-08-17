using System;

namespace Todo.Models
{
    public class TodoItem
    {
        public TodoItem ()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}