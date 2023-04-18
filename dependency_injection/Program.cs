using Microsoft.Extensions.DependencyInjection;
using Exec;
using Model;

internal class Program
{
    private static void Main(string[] args)
    {
        var service = new ServiceCollection()
            .AddSingleton<IExecute, Execute>()
            .AddScoped<ICalc, Calc>()
            .BuildServiceProvider();

        service.GetService<IExecute>()?.Start();
    }
}