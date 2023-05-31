using EventMX.Registration.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventMX.Registration.Infrastructure.Persistence.Configurations;
public class EventRegistrationItemsConfiguration
{
    public void Configure(EntityTypeBuilder<EventRegistrationItems> builder)
    {
        builder.HasKey(x => x.EventId);
        builder.Property(x => x.EventId).ValueGeneratedOnAdd();
    }
}
