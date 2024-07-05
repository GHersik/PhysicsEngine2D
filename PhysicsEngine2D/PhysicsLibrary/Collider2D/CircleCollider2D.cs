
namespace PhysicsLibrary {
    public class CircleCollider2D : Collider2D {

        public double Radius { get; private set; }

        public CircleCollider2D(IPhysicsEntity physicsEntity, double radius) {
            AttachedEntity = physicsEntity;
            Radius = radius;
            Type = Collider2DType.Circle;
        }

        public CircleCollider2D(IPhysicsEntity physicsEntity) : this(physicsEntity, 3) { }

        public override Vector2 ClosestPoint(Vector2 point) {
            Vector2 direction = point - AttachedEntity.Transform.position;
            direction.Normalize();
            return AttachedEntity.Transform.position + (direction * Radius);
        }
    }
}
