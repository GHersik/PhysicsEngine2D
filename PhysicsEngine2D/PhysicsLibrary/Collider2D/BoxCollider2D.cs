
namespace PhysicsLibrary {
    public class BoxCollider2D : Collider2D {

        public Vector2 MinPoint { get; private set; }
        public Vector2 MaxPoint { get; private set; }

        public BoxCollider2D(IPhysicsEntity physicsEntity, Vector2 minPoint, Vector2 maxPoint) {
            attachedEntity = physicsEntity;
            MinPoint = minPoint;
            MaxPoint = maxPoint;
            type = Collider2DType.Box;
        }

        public BoxCollider2D(IPhysicsEntity physicsEntity) : this(physicsEntity, new Vector2(-1, -1), new Vector2(1, 1)) { }

        public override Vector2 ClosestPoint(Vector2 point) {
            Vector2 boxMin = attachedEntity.transform.position + MinPoint;
            Vector2 boxMax = attachedEntity.transform.position + MaxPoint;
            double clampedX = Math.Max(boxMin.x, Math.Min(point.x, boxMax.x));
            double clampedY = Math.Max(boxMin.y, Math.Min(point.y, boxMax.y));

            if (point.x < boxMin.x || point.x > boxMax.x) {
                clampedY = point.y;
                clampedY = Math.Max(boxMin.y, Math.Min(clampedY, boxMax.y));
            }
            else if (point.y < boxMin.y || point.y > boxMax.y) {
                clampedX = point.x;
                clampedX = Math.Max(boxMin.x, Math.Min(clampedX, boxMax.x));
            }
            return new Vector2(clampedX, clampedY);
        }
    }
}
