using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Todo.Features.Todos;
using Todo.Domain;

namespace Todo.Infrastructure;

public static class DependencyInjections
{

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            return services;
        }
}