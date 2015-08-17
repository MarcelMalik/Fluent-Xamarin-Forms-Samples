using System;
using Todo.Contracts;
using Xamarin.Forms;
using Todo.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Todo.Models;

[assembly: Dependency(typeof(DummyDataService))]

namespace Todo.Data
{
    public class DummyDataService : IDataService
    {
        private readonly List<TodoItem> data;

        public DummyDataService ()
        {
            this.data = new List<TodoItem> {
                new TodoItem { Name = "Buy pears", IsDone = true },
                new TodoItem { Name = "Buy oranges" },
                new TodoItem { Name = "Buy mangos" },
                new TodoItem { Name = "Buy apples", IsDone = true },
                new TodoItem { Name = "Buy bananas" }
            };
        }
        #region IDataService implementation

        public IEnumerable<TodoItem> GetTodoItems ()
        {
            return data;
        }

        public void AddTodoItem (TodoItem item)
        {
            data.Add (item);
        }

        #endregion
    }
}

