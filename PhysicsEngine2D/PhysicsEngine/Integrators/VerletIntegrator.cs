using PhysicsLibrary;

namespace Physics {
    internal class VerletIntegrator {
        public void Integrate(IPhysicsEntity physicsEntity, double fixedTimeStep) {
            //// Update position
            //UpdateLinearPosition(physicsEntity, fixedTimeStep);

            //// Update velocity based on the new and old positions
            //UpdateLinearVelocity(physicsEntity, fixedTimeStep);

            //// Impose drag if necessary
            //ImposeDrag(physicsEntity.body);
        }

        //void UpdateLinearPosition(IPhysicsEntity physicsEntity, double fixedTimeStep) {
        //    Body body = physicsEntity.body;
        //    Vector2 currentPosition = physicsEntity.transform.position;
        //    Vector2 previousPosition = physicsEntity.transform.PreviousPosition;

        //    Vector2 newPosition = currentPosition + (currentPosition - previousPosition) + body.Acceleration * fixedTimeStep * fixedTimeStep;
        //    physicsEntity.transform.PreviousPosition = currentPosition;
        //    physicsEntity.transform.position = newPosition;

        //    // Clear force accumulator after updating the position
        //    body.ClearAccumulator();
        //}

        //void UpdateLinearVelocity(IPhysicsEntity physicsEntity, double fixedTimeStep) {
        //    Body body = physicsEntity.body;
        //    Vector2 currentPosition = physicsEntity.transform.position;
        //    Vector2 previousPosition = physicsEntity.transform.PreviousPosition;

        //    body.Velocity = (currentPosition - previousPosition) / fixedTimeStep;
        //}

        //void ImposeDrag(Body body) {
        //    // Apply drag to the velocity if needed
        //    body.Velocity *= body.Damping;
        //}
    }
}
