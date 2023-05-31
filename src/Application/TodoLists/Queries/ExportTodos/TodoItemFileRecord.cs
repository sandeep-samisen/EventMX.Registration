using EventMX.Registration.Application.Common.Mappings;
using EventMX.Registration.Domain.Entities;

namespace EventMX.Registration.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
