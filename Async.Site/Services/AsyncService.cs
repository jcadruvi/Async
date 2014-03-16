using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Async.Services
{
    public class AsyncService
    {
        public void ThreadSleep ()
        {
            Thread.Sleep(1000);
        }
    }
}