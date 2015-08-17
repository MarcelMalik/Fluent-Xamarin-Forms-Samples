using System;
using Todo.Contracts;
using Xamarin.Forms;
using Todo.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Todo.Models;
using System.Linq;

[assembly: Dependency(typeof(DummyDataService))]

namespace Todo.Data
{
    public class DummyDataService : IDataService
    {
        private readonly List<TodoItem> data;

        public DummyDataService ()
        {
            this.data = new List<TodoItem> {
                new TodoItem { Name = "Buy blueberries" },
                new TodoItem { Name = "Buy pumpkins" },
                new TodoItem { Name = "Buy pears", IsDone = true },
                new TodoItem { Name = "Buy raspberries" },
                new TodoItem { Name = "Buy oranges" },
                new TodoItem { Name = "Buy blackberries" },
                new TodoItem { Name = "Buy mangos" },
                new TodoItem { Name = "Buy raspberries" },
                new TodoItem { Name = "Buy citrons" },
                new TodoItem { Name = "Buy apples", IsDone = true },
                new TodoItem { Name = "Buy coconunts" },
                new TodoItem { Name = "Buy bananas" },
                new TodoItem { Name = "Buy kiwifruits" }
            };
        }

        #region IDataService implementation

        public IEnumerable<TodoItem> GetTodoItems ()
        {
            return data.OrderBy (x => x.Name);
        }

        public void AddTodoItem (TodoItem item)
        {
            data.Add (item);
        }

        #endregion
    }
}