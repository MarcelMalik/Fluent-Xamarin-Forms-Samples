using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Todo.Models;

namespace Todo.Contracts
{
    public interface IDataService
    {
        IEnumerable<TodoItem> GetTodoItems();
        void AddTodoItem(TodoItem item);
    }
}