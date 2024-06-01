using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class BodyForceRegistry {

        public struct BodyForceRegistration {

            public IForceGenerator forceGenerator;
            public Body body;

            public BodyForceRegistration(IForceGenerator forceGenerator, Body body) {
                this.forceGenerator = forceGenerator;
                this.body = body;
            }

            public void UpdateForces(double timeStep) {
                forceGenerator.UpdateForce(body, timeStep);


            }
        }

        private List<BodyForceRegistration> forceRegistrations = new List<BodyForceRegistration>();

        public void Add(Body body, IForceGenerator forceGenerator) {

        }

        public void Remove(BodyForceRegistry registry) {

        }

        public void Clear() {
            forceRegistrations.Clear();
        }

        public void UpdateForces() {
            foreach (BodyForceRegistration registry in forceRegistrations)
                registry.UpdateForces(PhysicsSettings.FixedTimeStep);
        }
    }
}
