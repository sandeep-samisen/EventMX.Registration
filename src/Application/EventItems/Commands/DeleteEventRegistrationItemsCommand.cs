using EventMX.Domain.Events.EventItemsEvents;
using EventMX.Registration.Application.Common.Exceptions;
using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Domain.Entities;
using MediatR;

namespace EventMX.Application.EventItemsService.Commands;
public record DeleteEventRegistrationItemsCommand(int Id) : IRequest;

public class DeleteEventRegistrationItemsCommandHandler : IRequestHandler<DeleteEventRegistrationItemsCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteEventRegistrationItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteEventRegistrationItemsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.EventRegistrationItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(EventRegistrationItems), request.Id);
        }

        _context.EventRegistrationItems.Remove(entity);

        entity.AddDomainEvent(new EventRegistrationItemsDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

