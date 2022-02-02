using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Anjular.Errors
{
    public class APIValidationError : ApiResponse
    {
        public APIValidationError() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }

    }
}
