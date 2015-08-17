using System;
using Xamarin.Forms;
using Todo.ViewModels;
using Todo.Models;

namespace Todo.Views
{
    public class TodoItemPage : ContentPage
    {
        public TodoItemPage (TodoItem model)
        {
            this.BindingContext = new TodoItemPageModel (model);
            var title = model == null ? "New" : "Edit";

            // Modify already created objects, like this ContentPage, with handover as a parameter
            Create.ContentPage (this)
                .Title (title)
                .AddToolbarItem (Create.ToolbarItem ()
                    .Text ("Save")
                    .BindCommand ("Save"))
                .Content (Create.StackLayout ()
                    .Padding (1)
                    .AddChild (Create.Label ()
                        .Text ("Name"))
                    .AddChild (Create.Entry ()
                        .Placeholder ("Add a to-do...")
                        .BindText ("Model.Name"))
                    .AddChild (Create.Label ()
                        .Text ("Done"))
                    .AddChild (Create.Switch ()
                        .BindIsToggled ("Model.IsDone")))
                .Build ();
        }
    }
}