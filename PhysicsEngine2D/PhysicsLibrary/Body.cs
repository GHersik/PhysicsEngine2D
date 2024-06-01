
namespace PhysicsLibrary {
    public class Body {

        public Vector2 position;

        public Vector2 velocity;

        public Vector2 acceleration;

        public double damping;

        public double inverseMass;

        public Vector2 forceAccumulator;

        public Body() {
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            acceleration = Vector2.Zero;
            damping = .995;
            inverseMass = 1;
            forceAccumulator = Vector2.Zero;
        }

        public void AddForce(Vector2 force) {
            forceAccumulator += force;
        }

        public void ClearAccumulator() {
            forceAccumulator = Vector2.Zero;
        }
    }
}
