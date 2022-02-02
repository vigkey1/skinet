﻿using API_Anjular.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Anjular.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("errors/{code}")]
    public class ErrorController : BaseAPIController
    {
       
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));

        }



    }
}
