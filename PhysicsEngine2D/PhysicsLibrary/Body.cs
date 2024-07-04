
namespace PhysicsLibrary {
    public class Body {

        public Vector2 Velocity = Vector2.Zero;
        public Vector2 Acceleration { get; private set; } = Vector2.Zero;
        public Vector2 ForceAccumulator { get; private set; } = Vector2.Zero;
        public Vector2 TotalForce { get; set; } = Vector2.Zero;
        public double InverseMass { get; private set; } = 1;

        double mass = 1;
        public double Mass {
            get { return mass; }
            set { mass = Math.Clamp(value, 0.1, 9999); }
        }

        double restitution = 1;
        public double Restitution {
            get { return restitution; }
            set { restitution = Math.Clamp(value, 0, 1); }
        }

        double damping = .995;
        public double Damping {
            get { return damping; }
            set { damping = Math.Clamp(value, 0, 1); }
        }

        public Body() { }

        public void AddForce(Vector2 force, ForceMode mode = ForceMode.Force) {
            switch (mode) {
                case ForceMode.Force: ForceAccumulator += force / mass; break;
                case ForceMode.Acceleration: ForceAccumulator += force; break;
                case ForceMode.Impulse: Velocity += force / mass; break;
                case ForceMode.VelocityChange: Velocity += force; break;
            }
        }

        public void ClearAccumulator() => ForceAccumulator = Vector2.Zero;

        public void SetKinematic(bool value) => InverseMass = value ? 0 : 1;

    }
}
