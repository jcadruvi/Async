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
                2000,
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

            var tasks = new[]
            {
                Task.Run(() =>Sleep(2000)), 
                Task.Run(() =>Sleep(1000)), 
                Task.Run(() =>Sleep(1500))
            };

            // Asynchronously wait for them all to complete.
            await Task.WhenAll(tasks);
           
            DateTime endDate = DateTime.Now;
            TimeSpan span = (endDate - startDate);
            response.Seconds = span.Seconds + (span.Milliseconds / 1000.0);
            
            return response;
        }

        //private void RunTasks()
        //{
        //    Task<bool>[] tasks = (from t in _sleepTimes
        //                          select Sleep(t)).ToArray();
        //    Task.WaitAll(tasks);
        //    //var task = Sleep(1000);
        //    //task.Wait();
        //}

        //private async Task<bool> Sleep(int sleepTime)
        //{
        //    await Task.Delay(sleepTime);
        //    return true;
        //}

        private void Sleep(int sleepTime)
        {
            Thread.Sleep(sleepTime);
        }
    }
}
