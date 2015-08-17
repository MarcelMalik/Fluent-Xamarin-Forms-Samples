using System;
using Xamarin.Forms;
using Todo.Models;
using Todo.Contracts;

namespace Todo.ViewModels
{
    public class TodoItemPageModel : BaseViewModel
    {
        public TodoItemPageModel (TodoItem model)
        {
            if (model == null)
                model = new TodoItem ();
            this.Model = model;

            this.Save = new Command (async () => {
                    if (string.IsNullOrWhiteSpace (this.Model.Name))
                    {
                        await App.Current.MainPage.DisplayAlert ("Validation Error", "Please enter a name", "OK");
                    
                    } else
                    {
                        var dataService = DependencyService.Get<IDataService> ();
                        dataService.AddTodoItem (this.Model);
                        MessagingCenter.Send (this, "Reload");
                    
                        await App.Current.MainPage.Navigation.PopAsync ();
                    }
                });
        }

        public TodoItem Model { get; }

        public Command Save { get; }
    }
}