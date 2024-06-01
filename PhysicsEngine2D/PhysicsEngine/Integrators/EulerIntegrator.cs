using PhysicsLibrary;

namespace Physics.Integrators {
    internal class EulerIntegrator {

        public void Integrate(Body rigidBody) {
            UpdateLinearPosition(rigidBody);
            UpdateLinearVelocity(rigidBody);
            ImposeDrag(rigidBody);
            rigidBody.ClearAccumulator();
        }

        private void UpdateLinearPosition(Body rigidBody) {
            rigidBody.position.AddScaledVector(rigidBody.velocity, PhysicsSettings.FixedTimeStep);
        }

        private void UpdateLinearVelocity(Body rigidBody) {
            Vector2 resultingAcc = rigidBody.acceleration;
            resultingAcc.AddScaledVector(rigidBody.forceAccumulator, rigidBody.inverseMass);
            rigidBody.velocity.AddScaledVector(resultingAcc, PhysicsSettings.FixedTimeStep);
        }

        private void ImposeDrag(Body rigidBody) {
            rigidBody.velocity *= Math.Pow(rigidBody.damping, PhysicsSettings.FixedTimeStep);
        }
    }
}
