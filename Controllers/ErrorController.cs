using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Utility;

namespace Services.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult Error()
        {

            var exceptionHandlerDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var errorMessage = new Error()
            {
                Message = exceptionHandlerDetails.Error.Message,
                StackTrace = exceptionHandlerDetails.Error.StackTrace,
                Path = exceptionHandlerDetails.Path

            };
            return BadRequest(errorMessage);
          
        }


        [Route("/Errorcode/{StatusCode}")]
        public IActionResult Errorcode(int StatusCode)
        {

            var exceptionHandlerDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var errorMessage = new Error()
            {
                Message = exceptionHandlerDetails.Error.Message,
                StackTrace = exceptionHandlerDetails.Error.StackTrace,
                Path = exceptionHandlerDetails.Path

            };
            return BadRequest(errorMessage);

        }
    }
}