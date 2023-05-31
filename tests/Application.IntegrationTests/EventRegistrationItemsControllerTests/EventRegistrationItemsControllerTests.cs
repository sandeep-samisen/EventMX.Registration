using EventMX.Registration.Application.EventItems.Commands;
using EventMX.Registration.WebUI.Controllers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WebUI.Controllers;

namespace EventMX.Registration.Application.IntegrationTests.EventRegistrationItemsControllerTests;
[TestFixture]
public class EventRegistrationItemsControllerTests : ApiControllerBase
{
    private IMediator _mediator;
    [SetUp]
    public void Setup()
    {
        // Set up the necessary dependencies
        var services = new ServiceCollection();
        services.AddMediatR(typeof(Program));
        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }


    [Test]
    public void AddEventRegistrationItems_GivenEventRegistrationItems_ThenReturnsNewlyGeneratedEventId()
    {
        var controller = new EventRegistrationItemsController(_mediator);

        var command = new CreateEventRegistrationItemsCommand
        {
            Min = 1,
            Max = 2,
            Price = 3,
            Description = "hello"
        };

        var result = controller.AddEventRegistrationItems(command);

        Assert.AreEqual(2, result);
    }
}
