
namespace PhysicsLibrary {
    public class Body {

        public double mass { get; private set; }
        public double inverseMass { get; private set; }
        public Vector2 forceAccumulator { get; private set; }

        public Vector2 velocity;

        public Vector2 acceleration;

        public double damping;

        public Body() {
            velocity = Vector2.Zero;
            acceleration = Vector2.Zero;
            damping = .995;
            inverseMass = 1;
            mass = 1;
            forceAccumulator = Vector2.Zero;
        }

        public void SetMass(double mass) => this.mass = mass;

        public void AddForce(Vector2 force) => forceAccumulator += force;

        public void ClearAccumulator() => forceAccumulator = Vector2.Zero;

    }
}
