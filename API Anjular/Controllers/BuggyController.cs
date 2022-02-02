﻿using API_Anjular.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Anjular.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet(" not found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
            {
                return NotFound( new ApiResponse(404));
            }

            return Ok();
        
        }
        [HttpGet(" Server Error")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);
            var tingToReTurn = thing.ToString();

            return Ok();

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));

        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();

        }
    }
}
