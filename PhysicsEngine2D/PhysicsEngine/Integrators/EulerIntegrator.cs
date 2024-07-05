using PhysicsLibrary;

namespace Physics {
    internal class EulerIntegrator {

        public void Integrate(IPhysicsEntity physicsEntity) {
            ConsumeForces(physicsEntity.Body);
            if (EvaluateSleepTolerance(physicsEntity.Body)) {
                physicsEntity.Body.Velocity = Vector2.Zero;
                return;
            }

            UpdateLinearPosition(physicsEntity);
            ImposeDrag(physicsEntity.Body);
        }

        void ConsumeForces(Body rigidBody) {
            Vector2 resultingAcc = rigidBody.Acceleration;
            resultingAcc.AddScaledVector(rigidBody.ForceAccumulator, rigidBody.InverseMass);
            rigidBody.TotalForce = resultingAcc;
            rigidBody.Velocity.AddScaledVector(resultingAcc, PhysicsSettings.FixedTimeStep);
            rigidBody.ClearAccumulator();
        }

        bool EvaluateSleepTolerance(Body body) {
            if (Math.Abs(body.Velocity.x) < PhysicsSettings.LinearSleepTolerance && Math.Abs(body.Velocity.y) < PhysicsSettings.LinearSleepTolerance)
                return true;
            return false;
        }

        void UpdateLinearPosition(IPhysicsEntity physicsEntity) {
            physicsEntity.Transform.position.AddScaledVector(physicsEntity.Body.Velocity, PhysicsSettings.FixedTimeStep);
        }

        void ImposeDrag(Body rigidBody) {
            rigidBody.Velocity *= Math.Pow(rigidBody.Damping, PhysicsSettings.FixedTimeStep);
        }
    }
}
