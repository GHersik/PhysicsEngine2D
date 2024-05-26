using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicsLibrary;

namespace Physics2D {
    public class PhysicsSettings {

        public Vector2 Gravity { get; private set; }

        public double FixedTimeStep { get; private set; }

        public PhysicsSettings(Vector2 gravity, double fixedTimeStep = 0.030) {
            Gravity = gravity;
            FixedTimeStep = fixedTimeStep;
        }
    }
}
