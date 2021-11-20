using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace InventoryService.Utils
{
    [Route("/healthz")]
    [ApiController]
    public class HealthController : IHealthCheck
    {
        public HealthController()
        {
        }

        public Task<HealthCheckResult> CheckHealthAsync(
       HealthCheckContext context,
       CancellationToken cancellationToken = default(CancellationToken))
        {
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            }

            return Task.FromResult(
                new HealthCheckResult(context.Registration.FailureStatus,
                "An unhealthy result."));
        }


        [HttpGet]
        public String HealthCheck()
        {
            return "Hello";
        }

    }
}


