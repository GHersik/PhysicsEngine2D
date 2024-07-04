using PhysicsLibrary;

namespace Physics {
    internal class CollisionDetector {

        public List<Collision2D> DetectCollisions(ICollection<IPhysicsEntity> physicsEntities) {
            IPhysicsEntity[] collisions = physicsEntities.ToArray();
            List<Collision2D> collisionsDetected = BroadPhase(collisions);
            return collisionsDetected;
        }

        List<Collision2D> BroadPhase(IPhysicsEntity[] physicsEntities) {
            List<Collision2D> collisionsToResolve = new List<Collision2D>();
            if (physicsEntities.Length < 1)
                return collisionsToResolve;

            for (int i = 0; i < physicsEntities.Length; i++) {
                for (int j = i + 1; j < physicsEntities.Length; j++) {
                    Collision2D collision = null;
                    bool isColliding = DetectCollision(physicsEntities[i], physicsEntities[j], out collision);
                    if (isColliding) { collisionsToResolve.Add(collision); }
                }
            }
            return collisionsToResolve;
        }

        void NarrowPhase() {

        }

        bool DetectCollision(IPhysicsEntity physicsEntityA, IPhysicsEntity physicsEntityB, out Collision2D collisionData) {
            collisionData = null;
            switch (physicsEntityA.collider.type) {
                case Collider2DType.Circle:
                    switch (physicsEntityB.collider.type) {
                        case Collider2DType.Circle:
                            return Collisions.CircleCircleCollision((CircleCollider2D)physicsEntityA.collider, (CircleCollider2D)physicsEntityB.collider, out collisionData);
                        case Collider2DType.Box:
                            return Collisions.CircleBoxCollision((CircleCollider2D)physicsEntityA.collider, (BoxCollider2D)physicsEntityB.collider, out collisionData);
                    }
                    break;
                case Collider2DType.Box:
                    switch (physicsEntityB.collider.type) {
                        case Collider2DType.Circle:
                            return Collisions.CircleBoxCollision((CircleCollider2D)physicsEntityB.collider, (BoxCollider2D)physicsEntityA.collider, out collisionData);
                        case Collider2DType.Box:
                            return Collisions.BoxBoxCollision((BoxCollider2D)physicsEntityA.collider, (BoxCollider2D)physicsEntityB.collider, out collisionData);
                    }
                    break;
            }
            return false;
        }
    }
}
