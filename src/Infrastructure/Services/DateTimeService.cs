using EventMX.Registration.Application.Common.Interfaces;

namespace EventMX.Registration.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
