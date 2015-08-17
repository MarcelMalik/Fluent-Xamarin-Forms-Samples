using System;
using Xamarin.Forms;
using Todo.Views;
using Todo.ViewModels;
using System.Collections.ObjectModel;
using Todo.Models;
using Todo.Contracts;

namespace Todo.ViewModels
{
    public class TodoListPageModel : BaseViewModel
    {
        public TodoListPageModel ()
        {
            this.Add = new Command (async () => {
                    await App.Current.MainPage.Navigation.PushAsync (new TodoItemPage (null));
                });
            this.Items = new ObservableCollection<TodoItem> ();

            MessagingCenter.Subscribe<TodoItemPageModel> (this, "Reload", (sender) => {
                    this.LoadData ();
                });

            this.LoadData ();
        }

        public Command Add { get; }

        public ObservableCollection<TodoItem> Items { get; private set; }

        private void LoadData ()
        {
            var dataService = DependencyService.Get<IDataService> ();
            var todoItems = dataService.GetTodoItems ();
            this.Items.Clear ();
            foreach (var item in todoItems)
            {
                this.Items.Add (item);
            }
        }
    }
}