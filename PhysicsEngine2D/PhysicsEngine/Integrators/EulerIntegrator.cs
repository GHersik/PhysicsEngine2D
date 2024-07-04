using PhysicsLibrary;

namespace Physics {
    internal class EulerIntegrator {

        public void Integrate(IPhysicsEntity physicsEntity) {
            ConsumeForces(physicsEntity.body);
            if (EvaluateSleepTolerance(physicsEntity.body)) {
                physicsEntity.body.Velocity = Vector2.Zero;
                return;
            }

            UpdateLinearPosition(physicsEntity);
            ImposeDrag(physicsEntity.body);
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
            physicsEntity.transform.position.AddScaledVector(physicsEntity.body.Velocity, PhysicsSettings.FixedTimeStep);
        }

        void ImposeDrag(Body rigidBody) {
            rigidBody.Velocity *= Math.Pow(rigidBody.Damping, PhysicsSettings.FixedTimeStep);
        }
    }
}
