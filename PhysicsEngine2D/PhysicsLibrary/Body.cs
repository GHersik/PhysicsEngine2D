
namespace PhysicsLibrary {
    public class Body {

        public Vector2 velocity = Vector2.Zero;

        public Vector2 acceleration = Vector2.Zero;

        public double mass { get; private set; } = 1;
        public double inverseMass { get; private set; } = 1;
        public Vector2 forceAccumulator { get; private set; } = Vector2.Zero;

        public double damping = .995;

        public double restitution = 1;

        public Body() { }

        public void SetMass(double mass) => this.mass = mass;

        public void AddForce(Vector2 force) => forceAccumulator += force;

        public void ClearAccumulator() => forceAccumulator = Vector2.Zero;

    }
}
