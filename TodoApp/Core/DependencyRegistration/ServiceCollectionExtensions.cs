using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTech.TodoApp.CQRS.Commands;
using MTech.TodoApp.DataModel;
using MTech.TodoApp.DataModel.Interfaces;
using MTech.Utilities.RequestHandler;
using System;
using System.Linq;

namespace MTech.DependencyRegistration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddDbContext<TodoContext>(options =>
            //{
            //    options.UseInMemoryDatabase("TodoContext");
            //});

            services.AddDbContext<TodoContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoContext;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddScoped<ITodoContext>(provider => provider.GetService<TodoContext>());

            services.AddCommandQueryHandlers(typeof(ICommandHandler<,>));
            services.AddCommandQueryHandlers(typeof(IQueryHandler<,>));

            services.AddScoped<IHandler, DefaultHandler>();


            return services;
        }

        public static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)
        {
            var types = typeof(BaseTodoCommand).Assembly.GetTypes()
                .Where(x =>
                    x.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface))
                .ToArray();

            foreach (var handler in types)
            {
                var genericType = handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface);
                services.AddScoped(genericType, handler);
            }
        }
    }
}
