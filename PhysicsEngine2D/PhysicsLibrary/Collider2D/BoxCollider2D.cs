using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Vector2 boxMin = attachedEntity.transform.position + MinPoint;
            //Vector2 boxMax = attachedEntity.transform.position + MaxPoint;
            //double x = Math.Max(boxMin.x, Math.Min(point.x, boxMax.x));
            //double y = Math.Max(boxMin.y, Math.Min(point.y, boxMax.y));
            //return new Vector2(x, y);

            // Compute the world position of the box's minimum and maximum points
            Vector2 boxMin = attachedEntity.transform.position + MinPoint;
            Vector2 boxMax = attachedEntity.transform.position + MaxPoint;

            // Clamp the point to the bounds of the box to find the closest point on the edges
            double clampedX = Math.Max(boxMin.x, Math.Min(point.x, boxMax.x));
            double clampedY = Math.Max(boxMin.y, Math.Min(point.y, boxMax.y));

            // Determine if the closest point is on a vertical or horizontal edge
            if (point.x < boxMin.x || point.x > boxMax.x) {
                // Point is to the left or right of the box, so the closest point must be on a vertical edge
                clampedY = point.y; // Project the point onto the vertical edge
                clampedY = Math.Max(boxMin.y, Math.Min(clampedY, boxMax.y)); // Clamp to vertical bounds
            }
            else if (point.y < boxMin.y || point.y > boxMax.y) {
                // Point is above or below the box, so the closest point must be on a horizontal edge
                clampedX = point.x; // Project the point onto the horizontal edge
                clampedX = Math.Max(boxMin.x, Math.Min(clampedX, boxMax.x)); // Clamp to horizontal bounds
            }

            return new Vector2(clampedX, clampedY);
        }

        // Compute the world position of the box's minimum and maximum points
        //Vector2 boxMin = attachedEntity.transform.position + MinPoint;
        //Vector2 boxMax = attachedEntity.transform.position + MaxPoint;

        //// Clamp the point to the bounds of the box to find the closest point on the edges
        //double clampedX = Math.Max(boxMin.x, Math.Min(point.x, boxMax.x));
        //double clampedY = Math.Max(boxMin.y, Math.Min(point.y, boxMax.y));

        //// Determine if the closest point is on a vertical or horizontal edge
        //if (point.x < boxMin.x || point.x > boxMax.x) {
        //    // Point is to the left or right of the box, so the closest point must be on a vertical edge
        //    clampedY = point.y; // Project the point onto the vertical edge
        //    clampedY = Math.Max(boxMin.y, Math.Min(clampedY, boxMax.y)); // Clamp to vertical bounds
        //}
        //else if (point.y < boxMin.y || point.y > boxMax.y) {
        //    // Point is above or below the box, so the closest point must be on a horizontal edge
        //    clampedX = point.x; // Project the point onto the horizontal edge
        //    clampedX = Math.Max(boxMin.x, Math.Min(clampedX, boxMax.x)); // Clamp to horizontal bounds
        //}

        //return new Vector2(clampedX, clampedY);
    }
}
