using MassTransit;
using MoviesMessaging.Contracts;

namespace Movies.Consumer.Consumers;

public class MovieDeletedConsumer : IConsumer<MovieDeleted>
{
    private readonly ILogger<MovieDeletedConsumer> _logger;

    public MovieDeletedConsumer(ILogger<MovieDeletedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MovieDeleted> context)
    {
        _logger.LogInformation($"MovieDeletedConsumer:{context.Message.ToString()}");
        return Task.CompletedTask;
    }
}
