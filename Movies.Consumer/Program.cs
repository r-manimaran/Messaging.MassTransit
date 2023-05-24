using MassTransit;
using MassTransit.RabbitMqTransport;
var builder = WebApplication.CreateBuilder();

//Register MassTransmit for Consuming the message
builder.Services.AddMassTransit(c =>
{
    c.SetKebabCaseEndpointNameFormatter();
    c.SetInMemorySagaRepositoryProvider();
    var assembly = typeof(Program).Assembly;
    c.AddConsumers(assembly);
    c.AddSagaStateMachines(assembly);
    c.AddSagas(assembly);
    c.AddActivities(assembly);

    //c.UsingAmazonSqs((ctxt, cfg) =>
    //{
    //    cfg.Host("us-east-1", _ => { });
    //    cfg.ConfigureEndpoints(ctxt);
    //});

   
    c.UsingRabbitMq((context, config) =>
    {
        config.Host("moo.rmq.cloudamqp.com", "vhost", h => {
            h.Username("username");
            h.Password("password");
        });
        config.ConfigureEndpoints(context);
    });
   
});


var app = builder.Build();

app.Run();
