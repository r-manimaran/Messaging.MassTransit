using MassTransit;
using MassTransitDemo;

var builder = WebApplication.CreateBuilder();

//Register the MassTransit
builder.Services.AddMassTransit(c =>
{
    c.AddConsumers(typeof(Program).Assembly); //Register the consumer from the Assembly which has the IConsumer implementation

    c.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});


//Regiter the Background Service
builder.Services.AddHostedService<PingPublisher>();

var app = builder.Build();

app.Run();
