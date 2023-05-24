using MassTransit;
using MoviesMessaging.Contracts;

namespace Movies.Consumer.Consumers;

public class MovieCreatedConsumer : IConsumer<MovieCreated>
{
    private readonly ILogger<MovieCreatedConsumer> _logger;

    public MovieCreatedConsumer(ILogger<MovieCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<MovieCreated> context)
    {
        _logger.LogInformation($"MovieAddedConsumer:{context.Message.ToString()}");
        return Task.CompletedTask;
    }
}
