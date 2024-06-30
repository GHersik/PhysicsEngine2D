using PhysicsLibrary;

namespace Physics.Integrators {
    internal class EulerIntegrator {

        public void Integrate(IPhysicsEntity physicsEntity) {
            UpdateLinearPosition(physicsEntity);
            UpdateLinearVelocity(physicsEntity.body);
            ImposeDrag(physicsEntity.body);
            physicsEntity.body.ClearAccumulator();
        }

        private void UpdateLinearPosition(IPhysicsEntity physicsEntity) {
            physicsEntity.transform.position.AddScaledVector(physicsEntity.body.velocity, PhysicsSettings.FixedTimeStep);
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
