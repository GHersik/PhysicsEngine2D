using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics.CollisionDetection.Collisions {
    internal static class Collisions {

        public static bool CircleCircleCollision(CircleCollider2D circleA, CircleCollider2D circleB, out Collision2D? collision) {
            Vector2 distanceDiff = circleB.PhysicsEntityAttached.transform.position - circleA.PhysicsEntityAttached.transform.position;
            double radiusSum = circleA.Radius + circleB.Radius;
            if (Math.Pow(distanceDiff.x, 2) + Math.Pow(distanceDiff.y, 2) < Math.Pow(radiusSum, 2)) {
                collision = new Collision2D(circleA, circleB);
                double dist = Vector2.Distance(circleB.PhysicsEntityAttached.transform.position, circleA.PhysicsEntityAttached.transform.position);
                double distDiff = Math.Abs(dist - radiusSum) * .5f;
                Vector2 normal = distanceDiff.Normalized;
                Vector2 point = circleA.PhysicsEntityAttached.transform.position + (normal * distDiff);
                double separation = 0;
                collision.AddContact(new ContactPoint2D(point, separation, normal));
                return true;
            }
            collision = null;
            return false;
        }

        public static bool CircleBoxCollision(CircleCollider2D circle, BoxCollider2D box, out Collision2D collision) {
            collision = null;

            return false;
        }

        public static bool BoxBoxCollision(BoxCollider2D boxA, BoxCollider2D boxB, out Collision2D collision) {
            collision = null;

            return false;
        }
    }
}
