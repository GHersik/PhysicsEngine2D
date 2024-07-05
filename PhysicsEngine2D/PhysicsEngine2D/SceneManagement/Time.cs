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
        public static double AccumulatedTime { get; private set; } = 0;

        public static void FixedUpdate() => AccumulatedTime += PhysicsSettings.FixedTimeStep;
        public static void ResetSimulationTime() => AccumulatedTime = 0;

    }
}
