using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class GravityForceGenerator : IForceGenerator {
        public void UpdateForce(Body body, double duration = 0) {
            if (body.InverseMass == 0) return;
            body.AddForce(PhysicsSettings.Gravity * body.Mass);
        }
    }
}
