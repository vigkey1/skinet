﻿using API_Anjular.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Anjular.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _ent;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment ent)
        {
            _next = next;
            _logger = logger;
            _ent = ent;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _ent.IsDevelopment()
                    ? new APIException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new APIException((int)HttpStatusCode.InternalServerError);
               
                var option = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase  }
                var json = JsonSerializer.Serialize(response,option);
                await context.Response.WriteAsync(json);
                      

                
            }
        
        }

    }
}
