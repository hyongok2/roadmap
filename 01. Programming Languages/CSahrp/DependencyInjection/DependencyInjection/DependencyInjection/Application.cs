using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Application : IApplication
    {
        private readonly ILogger<Application> _logger;

        public Application(ILogger<Application> logger)
        {
            _logger = logger;
        }

        public async void StartAsync()
        {
            _logger.LogInformation("Start Application!");

            await Task.Run(() => { });
        }
    }
}
