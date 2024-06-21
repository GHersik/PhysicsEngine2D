using PhysicsLibrary;

namespace Physics.Integrators {
    internal class EulerIntegrator {

        public void Integrate(IPhysicsEntity physicsEntity) {
            UpdateLinearPosition(physicsEntity);
            UpdateLinearVelocity(physicsEntity.Body);
            ImposeDrag(physicsEntity.Body);
            physicsEntity.Body.ClearAccumulator();
        }

        private void UpdateLinearPosition(IPhysicsEntity physicsEntity) {
            physicsEntity.Transform.position.AddScaledVector(physicsEntity.Body.velocity, PhysicsSettings.FixedTimeStep);
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
