
namespace PhysicsLibrary {
    public class Body {

        public Vector2 position;

        public Vector2 velocity;

        public Vector2 acceleration;

        public double damping;

        public double inverseMass;

        public Vector2 forceAccum;

        public Body() {
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            acceleration = Vector2.Zero;
            damping = .7;
            inverseMass = .5;
            forceAccum = Vector2.Zero;
        }

        //public RigidBody(Vector2 position)
        //{


        //}
        //public Vector2 Position { get; private set; }
        //public Vector2 Velocity { get; private set; }
        //public double Mass { get; private set; }

        //public RigidBody(Vector2 position, Vector2 velocity, double mass) {
        //    Position = position;
        //    Velocity = velocity;
        //    Mass = mass;
        //}
    }
}
