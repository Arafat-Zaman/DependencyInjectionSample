using System;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create a service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Step 2: Build a service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Step 3: Resolve and use services
            var messageService = serviceProvider.GetService<IMessageService>();
            messageService.SendMessage("Hello World!");

            // Using ServiceHelper (Optional)
            // var serviceHelper = serviceProvider.GetService<ServiceHelper>();
            // serviceHelper.Execute("Hello from ServiceHelper!");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register services with the DI container
            services.AddTransient<IMessageService, EmailService>(); // Using EmailService

            // Register ServiceHelper if you plan to use it
            // services.AddTransient<ServiceHelper>();
        }
    }
}
