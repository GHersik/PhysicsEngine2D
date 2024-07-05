
namespace PhysicsLibrary {
    public struct ContactPoint2D {

        public Vector2 Point { get; private set; }
        public Vector2 Normal { get; private set; }
        public double Separation { get; private set; }

        public ContactPoint2D(Vector2 point, double separation, Vector2 normal) {
            this.Point = point;
            this.Separation = separation;
            this.Normal = normal;
        }
    }
}
