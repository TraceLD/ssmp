﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ssmp
{
    public class CentralServerBackgroundService : BackgroundService
    {
        private readonly ILogger<CentralServerBackgroundService> _logger;
        private readonly ICentralServerService _centralServerService;

        public CentralServerBackgroundService(
            ILogger<CentralServerBackgroundService> logger,
            ICentralServerService centralServerService
        )
        {
            _logger = logger;
            _centralServerService = centralServerService;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            _logger.LogInformation("Started Ssmp.");
            
            while (!ct.IsCancellationRequested)
            {
                await _centralServerService.SpinOnce();
            }
            
            _logger.LogInformation("Stopped Ssmp.");
        }
    }
}