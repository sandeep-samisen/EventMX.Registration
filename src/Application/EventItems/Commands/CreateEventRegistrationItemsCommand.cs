using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Domain.Entities;
using EventMX.Registration.Domain.Events.EventRegistrationItemsEvents;
using MediatR;

namespace EventMX.Registration.Application.EventItems.Commands;
public record CreateEventRegistrationItemsCommand : IRequest<int>
{
    public int Min { get; set; }
    public int Max { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class CreateEventRegistrationItemsCommandHandler : IRequestHandler<CreateEventRegistrationItemsCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateEventRegistrationItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEventRegistrationItemsCommand request, CancellationToken cancellationToken)
    {
        var entity = new EventRegistrationItems
        {
            Min = request.Min,
            Max = request.Max,
            Price = request.Price,
            Description = request.Description
        };

        entity.AddDomainEvent(new EventRegistrationItemsCreatedEvent(entity));

         _context.EventRegistrationItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.EventId;
    }
}