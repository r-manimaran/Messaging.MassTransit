using MassTransit;

namespace Movies.Api.Extensions;

public static class RegisterServiceExtensions
{
    public static IServiceCollection RegisterMassTransitAmzSQS(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingAmazonSqs((context, config) =>
            {
                config.Host("us-east-1", _ => { });
                config.ConfigureEndpoints(context);
            });
        });
        return services;

    }

    public static IServiceCollection RegisterMassTransitRabbitMQ(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, config) =>
            {
                config.Host("moose.rmq.cloudamqp.com", "vhost",h=> {
                    h.Username("username");
                    h.Password("password");
                });
                config.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
