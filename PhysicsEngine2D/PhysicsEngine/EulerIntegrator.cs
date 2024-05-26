using PhysicsLibrary;

namespace Physics2D {
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
            Vector2 resultingAcc = rigidBody.velocity;
            resultingAcc.AddScaledVector(rigidBody.forceAccum, rigidBody.inverseMass);
            rigidBody.velocity.AddScaledVector(resultingAcc, PhysicsSettings.FixedTimeStep);
        }

        private void ImposeDrag(Body rigidBody) {
            rigidBody.velocity *= Math.Pow(rigidBody.damping, PhysicsSettings.FixedTimeStep);
        }



        //private void CalculatePosition(RigidBody rigidBody) {


        //    rigidBody.position.AddScaledVector(rigidBody.velocity, physicsSettings.FixedTimeStep);

        //    //could be ignored possibly
        //    //rigidBody.position.AddScaledVector(rigidBody.acceleration, physicsSettings.FixedTimeStep * physicsSettings.FixedTimeStep * 0.5f);


        //    //rigidBody.position += rigidBody.velocity * physicsSettings.FixedTimeStep + rigidBody.acceleration * physicsSettings.FixedTimeStep * physicsSettings.FixedTimeStep * .5f;
        //}
    }
}
