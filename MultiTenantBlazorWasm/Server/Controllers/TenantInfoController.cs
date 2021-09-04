using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantBlazorWasm.Shared;
using OrchardCore.Environment.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantBlazorWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantInfoController : ControllerBase
    {
        private readonly ShellSettings _currentShellSettings;
     
        public TenantInfoController(ShellSettings settings)
        {
            _currentShellSettings = settings;
        }

        [HttpGet]
        public TenantInfo Get()
        {
            return new TenantInfo
            {
                TenantName = _currentShellSettings.Name
            };
        }
            
    }
}
