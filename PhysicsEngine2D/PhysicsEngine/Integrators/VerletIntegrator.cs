using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.Integrators {
    internal class VerletIntegrator {

        //public void Integrate(Body rigidBody) {
        //    UpdateAcceleration(rigidBody);
        //    UpdateLinearPosition(rigidBody);
        //    UpdateLinearVelocity(rigidBody);
        //    rigidBody.ClearAccumulator();
        //}

        //private void UpdateAcceleration(Body rigidBody) {
        //    if (rigidBody.inverseMass > 0) {
        //        rigidBody.acceleration = rigidBody.forceAccumulator * rigidBody.inverseMass;
        //    }
        //    else {
        //        rigidBody.acceleration = Vector2.Zero;
        //    }
        //}

        //private void UpdateLinearPosition(Body rigidBody) {
        //    Vector2 newPosition = rigidBody.position
        //                          + (rigidBody.position - rigidBody.previousPosition) * rigidBody.damping
        //                          + rigidBody.acceleration * PhysicsSettings.FixedTimeStep * PhysicsSettings.FixedTimeStep;

        //    rigidBody.previousPosition = rigidBody.position;
        //    rigidBody.position = newPosition;
        //}

        //private void UpdateLinearVelocity(Body rigidBody) {
        //    rigidBody.velocity = (rigidBody.position - rigidBody.previousPosition) / PhysicsSettings.FixedTimeStep;
        //}
    }
}
