using System;
using Xamarin.Forms;

namespace Todo.Views
{
    public class TodoItemCell : ViewCell
    {
        public TodoItemCell ()
        {
            Create.ViewCell (this)
                // Create context action and bind it
                .AddContextAction (Create.MenuItem ()
                    .Text ("Done").Build ())
                // Create second context action and bind it
                .AddContextAction (Create.MenuItem ()
                    .Text ("Delete")
                    .IsDestructive (true).Build ())
                // Create the layout of the cell, with a grid, two columns, text and check image
                .View (Create.Grid ()
                    // Add padding with factor (Android, iOS = 8, WinPhone = 10) to the grid
                    .Padding (1)
                    .ColumnDefinition (1, GridUnitType.Star)
                    .ColumnDefinition (20, GridUnitType.Absolute)
                    .AddChild (Create.Label ()
                        .YAlign (TextAlignment.Center)
                        .BindText ("Name"))
                    .AddChild (Create.Image ()
                        .FromFile ("check.png")
                        .BindIsVisible ("IsDone")
                    , 1))
                .Build ();
        }
    }
}