using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;
using InventoryService.Interfaces;
using System;

namespace InventoryService.Utils
{
    [Route("/healthz")]
    [ApiController]
    public class HealthController : Controller
    {
        public HealthController()
        {
        }

        [HttpGet]
        public String HealthCheck()
        {
            return "Hello";
        }
    }
}


