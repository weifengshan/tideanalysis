using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TidalException
{
    class Utility
    {
        private Stopwatch _stopwatch;
        public void Start()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Time taken : {0}", elapsedTime);
        }

    }
}
