using EventMX.Registration.Application.Common.Interfaces;
using EventMX.Registration.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventMX.Application.EventItemsService.Queries;

public record GetEventRegistrationItemsListQuery : IRequest<List<EventRegistrationItems>>;

public class EventItemsListQueryHandler : IRequestHandler<GetEventRegistrationItemsListQuery, List<EventRegistrationItems>>
{
    private readonly IApplicationDbContext _context;
    public EventItemsListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<EventRegistrationItems>> Handle(GetEventRegistrationItemsListQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.EventRegistrationItems.ToListAsync(cancellationToken);

        return records;
    }
}
