using EventMX.Registration.Application.Common.Exceptions;
using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Domain.Entities;
using MediatR;

namespace EventMX.Application.EventItemsService.Commands;

public record UpdateEventRegistrationItemsCommand : IRequest
{
    public int EventId { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = String.Empty;
}

public class UpdateEventRegistrationItemsCommandHandler : IRequestHandler<UpdateEventRegistrationItemsCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEventRegistrationItemsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateEventRegistrationItemsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.EventRegistrationItems
            .FindAsync(new object[] { request.EventId }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(EventRegistrationItems), request.EventId);
        }

        entity.Min = request.Min;
        entity.Max = request.Max;
        entity.Price = request.Price;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
