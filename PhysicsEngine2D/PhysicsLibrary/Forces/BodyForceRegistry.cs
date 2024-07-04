
namespace PhysicsLibrary {
    public class BodyForceRegistry {

        public struct BodyForceRegistration {

            public IForceGenerator forceGenerator;
            public Body body;

            public BodyForceRegistration(IForceGenerator forceGenerator, Body body) {
                this.forceGenerator = forceGenerator;
                this.body = body;
            }

            public void UpdateForce(double timeStep) {
                forceGenerator.UpdateForce(body, timeStep);
            }
        }

        HashSet<BodyForceRegistration> forceRegistrations = new HashSet<BodyForceRegistration>();

        public bool Add(Body body, IForceGenerator forceGenerator) {
            BodyForceRegistration registration = new BodyForceRegistration(forceGenerator, body);
            if (forceRegistrations.Contains(registration))
                return false;

            forceRegistrations.Add(registration);
            return true;
        }

        public bool Remove(Body body, IForceGenerator forceGenerator) {
            BodyForceRegistration registration = new BodyForceRegistration(forceGenerator, body);
            if (!forceRegistrations.Contains(registration))
                return false;

            forceRegistrations.Remove(registration);
            return true;
        }

        public void Clear() {
            forceRegistrations.Clear();
        }

        public void UpdateForces() {
            foreach (BodyForceRegistration registry in forceRegistrations)
                registry.UpdateForce(PhysicsSettings.FixedTimeStep);
        }
    }
}
