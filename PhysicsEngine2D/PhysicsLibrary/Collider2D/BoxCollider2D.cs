
namespace PhysicsLibrary {
    public class BoxCollider2D : Collider2D {

        public Vector2 MinPoint { get; private set; }
        public Vector2 MaxPoint { get; private set; }

        public BoxCollider2D(IPhysicsEntity physicsEntity, Vector2 minPoint, Vector2 maxPoint) {
            AttachedEntity = physicsEntity;
            MinPoint = minPoint;
            MaxPoint = maxPoint;
            Type = Collider2DType.Box;
        }

        public BoxCollider2D(IPhysicsEntity physicsEntity) : this(physicsEntity, new Vector2(-1, -1), new Vector2(1, 1)) { }

        public override Vector2 ClosestPoint(Vector2 point) {
            Vector2 boxMin = AttachedEntity.Transform.position + MinPoint;
            Vector2 boxMax = AttachedEntity.Transform.position + MaxPoint;
            double clampedX = Math.Max(boxMin.x, Math.Min(point.x, boxMax.x));
            double clampedY = Math.Max(boxMin.y, Math.Min(point.y, boxMax.y));
            return new Vector2(clampedX, clampedY);
        }
    }
}
