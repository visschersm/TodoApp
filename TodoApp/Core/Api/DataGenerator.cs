using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTech.TodoApp.DataModel;
using System;
using System.Drawing;
using System.Linq;

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
                    Id = 1,
                    Title = "Test List - Shopping",
                    LabelColor = Color.CornflowerBlue,
                    TodoItems = new Entities.TodoItem[]
                    {
                        new Entities.TodoItem
                        {
                            Id = 1,
                            ParentId = 1,
                            Title = "Milk",
                            Status = TodoStatus.Planned
                        },
                        new Entities.TodoItem
                        {
                            Id = 2,
                            ParentId = 1,
                            Title = "Bread",
                            Status = TodoStatus.Done
                        }
                    }.ToList()
                },
                new Entities.TodoList
                {
                    Id = 2,
                    Title = "Test List - Development",
                    LabelColor = Color.DarkSeaGreen,
                    TodoItems = new Entities.TodoItem[]
                    {
                        new Entities.TodoItem
                        {
                            Id = 3,
                            ParentId = 2,
                            Title = "Learn Blazor",
                            Status = TodoStatus.Busy,
                            CreatedDate = DateTime.Today.AddDays(-5),
                            DueDate = DateTime.Today.AddDays(1),
                            Priority = Priority.Highest,
                        },
                        new Entities.TodoItem
                        {
                            Id = 4,
                            ParentId = 2,
                            Title = "Architecture",
                            Status = TodoStatus.Done,
                            CreatedDate = DateTime.Today,
                            DueDate = DateTime.Today.AddDays(7),
                            Priority = Priority.High
                        },
                        new Entities.TodoItem
                        {
                            Id = 5,
                            ParentId = 2,
                            Title = "Learn Vue",
                            Status = TodoStatus.Planned,
                            CreatedDate = DateTime.Today,
                            DueDate = DateTime.Today.AddDays(3),
                            Priority = Priority.Low
                        }
                    }.ToList()
                }
            });

            context.SaveChanges();
        }
    }
}
