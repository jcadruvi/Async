using Async.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mvc4.Controllers
{
    public class AsyncApiController : ApiController
    {
        [HttpGet]
        public AsyncTestResponse AsyncTest()
        {
            AsyncTestResponse response = new AsyncTestResponse();
            DateTime startDate = DateTime.Now;


            DateTime endDate = DateTime.Now;
            response.MillSeconds = (startDate - endDate).Milliseconds;
            response.Seconds = response.MillSeconds / 1000.0;
            return response;
        }
    }
}
