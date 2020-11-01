using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController() 
        {
        }

        internal string GetCurrentUserId() 
        {
            return "abc";
        }

        protected async Task<IActionResult> GetResultAsync<T>([NotNull] Func<Task<T>> getDataFunction) 
        {
            T result = await getDataFunction();

            if (result == null) 
            {
                return NotFound();
            }

            return new JsonResult(result);
        }

        internal DateTime GetCurrentDate() 
        {
            string dateFromRequest = Request.Headers["Current-Date"].ToString();
            if (string.IsNullOrEmpty(dateFromRequest))
                return DateTime.Now;
            return DateTime.TryParse(dateFromRequest, null, DateTimeStyles.AdjustToUniversal, out var currentDate) ? currentDate : DateTime.Now;
        }
    }
}
