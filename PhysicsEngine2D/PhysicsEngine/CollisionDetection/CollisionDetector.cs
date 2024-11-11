using PhysicsLibrary;

namespace Physics {
    internal class CollisionDetector {

        public List<Collision2D> DetectCollisions(ICollection<IPhysicsEntity> physicsEntities) {
            IPhysicsEntity[] collisions = physicsEntities.ToArray();
            List<Collision2D> collisionsDetected = BroadPhase(collisions);
            return collisionsDetected;
        }

        List<Collision2D> BroadPhase(IPhysicsEntity[] physicsEntities) {
            List<Collision2D> collisionsToResolve = new();
            if (physicsEntities.Length < 1)
                return collisionsToResolve;

            for (int i = 0; i < physicsEntities.Length; i++) {
                for (int j = i + 1; j < physicsEntities.Length; j++) {
                    bool isColliding = DetectCollision(physicsEntities[i], physicsEntities[j], out Collision2D collision);
                    if (isColliding) { collisionsToResolve.Add(collision); }
                }
            }
            return collisionsToResolve;
        }

        bool DetectCollision(IPhysicsEntity physicsEntityA, IPhysicsEntity physicsEntityB, out Collision2D collisionData) {
            collisionData = null;
            if (physicsEntityA.Body.InverseMass == 0 && physicsEntityB.Body.InverseMass == 0)
                return false;

            switch (physicsEntityA.Collider.Type) {
                case Collider2DType.Circle:
                    switch (physicsEntityB.Collider.Type) {
                        case Collider2DType.Circle:
                            return Collisions.CircleCircleCollision((CircleCollider2D)physicsEntityA.Collider, (CircleCollider2D)physicsEntityB.Collider, out collisionData);
                        case Collider2DType.Box:
                            return Collisions.CircleBoxCollision((CircleCollider2D)physicsEntityA.Collider, (BoxCollider2D)physicsEntityB.Collider, out collisionData);
                    }
                    break;
                case Collider2DType.Box:
                    switch (physicsEntityB.Collider.Type) {
                        case Collider2DType.Circle:
                            return Collisions.CircleBoxCollision((CircleCollider2D)physicsEntityB.Collider, (BoxCollider2D)physicsEntityA.Collider, out collisionData);
                        case Collider2DType.Box:
                            return Collisions.BoxBoxCollision((BoxCollider2D)physicsEntityA.Collider, (BoxCollider2D)physicsEntityB.Collider, out collisionData);
                    }
                    break;
            }
            return false;
        }
    }
}
