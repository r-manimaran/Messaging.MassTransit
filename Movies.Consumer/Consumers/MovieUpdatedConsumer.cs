using MassTransit;
using MoviesMessaging.Contracts;

namespace Movies.Consumer.Consumers;
public class MovieUpdatedConsumer : IConsumer<MovieUpdated>
{
    private readonly ILogger<MovieUpdatedConsumer> _logger;

    public MovieUpdatedConsumer(ILogger<MovieUpdatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MovieUpdated> context)
    {
        _logger.LogInformation($"MovieUpdatedConsumer:{context.Message.ToString()}");
        return Task.CompletedTask;
    }
}
