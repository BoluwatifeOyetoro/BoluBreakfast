using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoluBreakfast.Controllers
{
    public class ErrorController : ControllerBase
    {

        [Route("[/error")]

        public IActionResult Error()
        {
            return Problem();
        }
    }
}