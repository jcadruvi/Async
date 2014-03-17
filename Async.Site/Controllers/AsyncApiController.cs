using Async.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Async.Services;

namespace Mvc4.Controllers
{
    public class AsyncApiController : ApiController
    {
        IList<int> _sleepTimes;
        AsyncService _service;
        public AsyncApiController()
        {
            _sleepTimes = new List<int>{
                1000,
                3000,
                1500,
                750,
                500
            };
            _service = new AsyncService();
        }

        [HttpGet]
        public async Task<AsyncTestResponse> AsyncTest()
        {
            AsyncTestResponse response = new AsyncTestResponse();
            DateTime startDate = DateTime.Now;

            //var tasks = (from t in _sleepTimes
            //             select Task.Run(() =>Sleep(t)));

            //// Asynchronously wait for them all to complete.
            //await Task.WhenAll(tasks);

            await _service.DoWork();
           
            DateTime endDate = DateTime.Now;
            TimeSpan span = (endDate - startDate);
            response.Seconds = span.Seconds + (span.Milliseconds / 1000.0);
            
            return response;
        }

        private void Sleep(int sleepTime)
        {
            Thread.Sleep(sleepTime);
        }
    }
}
