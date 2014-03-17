using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Async.Services
{
    public class AsyncService
    {
        IList<int> _sleepTimes;
        public AsyncService()
        {
            _sleepTimes = new List<int>{
                1000,
                3200,
                1500,
                750,
                500
            };
        }

        public async Task DoWork()
        {
            var tasks = (from t in _sleepTimes
                         select Task.Run(() => Sleep(t)));

            // Asynchronously wait for them all to complete.
            await Task.WhenAll(tasks);
        }

        private void Sleep (int sleepTime)
        {
            Thread.Sleep(sleepTime);
        }
    }
}