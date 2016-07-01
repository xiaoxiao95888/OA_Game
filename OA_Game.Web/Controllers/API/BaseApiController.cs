using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OA_Game.Web.Models;

namespace OA_Game.Web.Controllers.API
{
    public class BaseApiController : ApiController
    {
        protected ResponseModel Success()
        {
            return new ResponseModel
            {
                ErrorCode = 0,
                Message = "success",
                Error = false
            };
        }
        protected ResponseModel Failed(string message = null)
        {
            return new ResponseModel
            {
                ErrorCode = 0,
                Message = message,
                Error = true
            };
        }
    }
}
