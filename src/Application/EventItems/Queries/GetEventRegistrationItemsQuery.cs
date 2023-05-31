using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Domain.Entities;
using MediatR;

namespace EventMX.Application.EventItemsService.Queries;
public record GetEventRegistrationItemsQuery : IRequest<EventRegistrationItems?>
{
    public int Id { get; init; }
}

public class GetEventRegistrationItemsQueryHandler : IRequestHandler<GetEventRegistrationItemsQuery, EventRegistrationItems?>
{
    private readonly IApplicationDbContext _context;
    public GetEventRegistrationItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EventRegistrationItems?> Handle(GetEventRegistrationItemsQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.EventRegistrationItems.FindAsync(new object[] { request.Id }, cancellationToken);

        return records;
    }
}