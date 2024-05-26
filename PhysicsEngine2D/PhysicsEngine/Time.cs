using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Physics2D {
    public class Time {
        
        public TimeSpan TotalTimeElapsed { get; private set; }
        public TimeSpan FixedTimeStep { get; private set; }

        public Time(int timeStep = 30) {
            FixedTimeStep = TimeSpan.FromMilliseconds(timeStep);
            TotalTimeElapsed = TimeSpan.Zero;
        }

        public void FixedUpdate() {
            TotalTimeElapsed += FixedTimeStep;
        }
    }
}
