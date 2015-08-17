using System;
using Xamarin.Forms;
using FluentXamarinForms;
using Todo.ViewModels;

namespace Todo.Views
{
    public class TodoListPage : ContentPage
    {
        public TodoListPage ()
        {
            this.BindingContext = new TodoListPageModel ();

            // Modify already created objects, like this ContentPage, with handover as a parameter
            Create.ContentPage (this)
                .Title("Todo List")
                // Add directly a toolbar item and bind it
                .AddToolbarItem (Create.ToolbarItem ()
                    .Text ("Add")
                    .BindCommand ("Add"))
                // And define the content, like a list view
                .Content (Create.ListView ()
                    .BindItemSource ("Items")
                    .ItemTemplate (new DataTemplate (typeof(TodoItemCell)))
                    .SeperatorVisibility(SeparatorVisibility.None))
                .Build ();
        }
    }
}