using EventMX.Registration.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventMX.Registration.Application.Common.Interfaces;

public interface IApplicationDbContext
{
   DbSet<EventRegistrationItems> EventRegistrationItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
