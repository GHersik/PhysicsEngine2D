using PhysicsLibrary;

namespace Physics {
    internal static class Collisions {

        public static bool CircleCircleCollision(CircleCollider2D circleA, CircleCollider2D circleB, out Collision2D? collision) {
            Vector2 distanceDiff = circleB.attachedEntity.transform.position - circleA.attachedEntity.transform.position;
            double sqrDistance = distanceDiff.SqrMagnitude;
            double radiusSumSqr = Math.Pow(circleA.Radius + circleB.Radius,2);
            if (sqrDistance < radiusSumSqr) {
                collision = new Collision2D(circleA, circleB);
                Vector2 normal = distanceDiff.Normalized;
                Vector2 point = circleA.attachedEntity.transform.position + (normal * circleA.Radius);
                double separation = Math.Abs(sqrDistance - radiusSumSqr);
                collision.AddContact(new ContactPoint2D(point, separation, normal));

                //middle in between points
                //double distance = Vector2.Distance(circleB.attachedEntity.transform.position, circleA.attachedEntity.transform.position);
                //double distDiff = Math.Abs(distance - radiusSum) * .5f;
                //Vector2 point = circleA.attachedEntity.transform.position + (normal * distDiff);
                return true;
            }
            collision = null;
            return false;
        }

        public static bool CircleBoxCollision(CircleCollider2D circle, BoxCollider2D box, out Collision2D? collision) {
            Vector2 circleCenter = circle.attachedEntity.transform.position;
            Vector2 closestPoint = box.ClosestPoint(circleCenter);
            Vector2 distance = circleCenter - closestPoint;

            if (distance.SqrMagnitude < circle.Radius * circle.Radius) {
                collision = new Collision2D(circle, box);
                Vector2 normal = distance.Normalized;
                Vector2 contactPoint = closestPoint;
                double separation = circle.Radius - distance.Magnitude;

                collision.AddContact(new ContactPoint2D(contactPoint, separation, normal));
                return true;
            }

            collision = null;
            return false;
        }

        public static bool BoxBoxCollision(BoxCollider2D boxA, BoxCollider2D boxB, out Collision2D collision) {
            collision = null;

            return false;
        }
    }
}
