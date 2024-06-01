using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PhysicsLibrary;

namespace Physics {
    public static class Time {
        
        public static TimeSpan TotalTimeElapsed { get; private set; }
        public static TimeSpan FixedTimeStep = TimeSpan.FromMilliseconds(30);



        public static void FixedUpdate() {
            TotalTimeElapsed += FixedTimeStep;
        }
    }
}
