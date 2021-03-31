using Attendleave.Erp.Core.APIUtilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingProgram.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IActionResultResponseHandler HttpHandeller;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiControllerBase(
            IActionResultResponseHandler actionResultResponseHandler,
            IHttpContextAccessor httpContextAccessor)
        {
            HttpHandeller = actionResultResponseHandler;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
