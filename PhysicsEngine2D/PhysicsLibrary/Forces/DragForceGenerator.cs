
namespace PhysicsLibrary {
    public class DragForceGenerator : IForceGenerator {

        readonly double velocityDragCoefficient;
        readonly double velocityDragSquaredCoefficient;

        public DragForceGenerator(double velDragCoef, double velDragSquaredCoef) {
            velocityDragCoefficient = velDragCoef;
            velocityDragSquaredCoefficient = velDragSquaredCoef;
        }

        public void UpdateForce(Body body, double duration = 0) {
            Vector2 force = body.Velocity;

            double dragCoefficient = force.Magnitude;
            dragCoefficient = velocityDragCoefficient * dragCoefficient + velocityDragSquaredCoefficient * dragCoefficient;

            force.Normalize();
            force *= -dragCoefficient;
            body.AddForce(force);
        }
    }
}
