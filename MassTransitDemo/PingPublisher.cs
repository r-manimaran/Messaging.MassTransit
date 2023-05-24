using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitDemo;

public class PingPublisher : BackgroundService
{
    private readonly ILogger<PingPublisher> _logger;
    private readonly IBus _bus;
    public PingPublisher(ILogger<PingPublisher> logger,IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();

            var keyPressed = Console.ReadKey(true);
            if(keyPressed.Key != ConsoleKey.Escape)
            {
                //_logger.LogInformation("Pressed {Button}", keyPressed.Key.ToString());
                await _bus.Publish(new Ping(keyPressed.Key.ToString()));
            }
            await Task.Delay(200);
        }
    }
}
