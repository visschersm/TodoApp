using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTech.TodoApp.DataModel;
using System;
using System.Drawing;

namespace MTech.TodoApp.Api
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TodoContext(serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>());

            if (!context.Database.IsInMemory())
                return;

            context.TodoLists.AddRange(new Entities.TodoList[]
            {
                new Entities.TodoList
                {
                    Title = "Test List - Shopping",
                    LabelColor = Color.CornflowerBlue,
                    TodoItems = new Entities.TodoItem[]
                    {
                        new Entities.TodoItem
                        {
                            Title = "Milk",
                            IsDone = false,
                        },
                        new Entities.TodoItem
                        {
                            Title = "Bread",
                            IsDone = true
                        }
                    }
                },
                new Entities.TodoList
                {
                    Title = "Test List - Development",
                    LabelColor = Color.Chartreuse,
                    TodoItems = new Entities.TodoItem[]
                    {
                        new Entities.TodoItem
                        {
                            Title = "Learn Blazor",
                            IsDone = false,
                            CreatedDate = DateTime.Today.AddDays(-5),
                            DueDate = DateTime.Today.AddDays(1),
                            Priority = Priority.Highest,
                        },
                        new Entities.TodoItem
                        {
                            Title = "Architecture",
                            IsDone = true,
                            CreatedDate = DateTime.Today,
                            DueDate = DateTime.Today.AddDays(7),
                            Priority = Priority.High
                        },
                        new Entities.TodoItem
                        {
                            Title = "Learn Vue",
                            IsDone = false,
                            CreatedDate = DateTime.Today,
                            DueDate = DateTime.Today.AddDays(3),
                            Priority = Priority.Low
                        }
                    }
                }
            });

            context.SaveChanges();
        }
    }
}
