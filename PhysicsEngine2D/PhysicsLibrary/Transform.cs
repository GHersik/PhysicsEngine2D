
namespace PhysicsLibrary {
    public class Transform {

        public Vector2 position;

        public Transform(Vector2 position) {
            this.position = position;
        }

        public Transform() : this(Vector2.Zero) { }
    }
}
