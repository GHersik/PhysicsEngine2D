using Physics.CollisionDetection.Collisions;
using PhysicsLibrary;

namespace Physics {
    internal class ContactResolver {

        public void ResolveContacts(List<Collision2D> collisions) {
            foreach (var collision in collisions) {
                if (collision.ContactCount < 1)
                    continue;

                List<ContactPoint2D> contacts = RetrieveContacts(collision);
                Resolve(collision.ColliderA.attachedEntity, collision.ColliderB.attachedEntity, contacts);
                SendCollisionMessages(collision);
            }
        }

        public List<ContactPoint2D> RetrieveContacts(Collision2D collision) {
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            collision.GetContacts(contacts);
            return contacts;
        }

        public void Resolve(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            if (entityA.body.InverseMass == 0 && entityB.body.InverseMass == 0)
                return;
            else if (entityB.body.InverseMass == 0 && entityA.body.InverseMass != 0)
                ResolveEntity(entityA, contacts);
            else if (entityA.body.InverseMass == 0 && entityB.body.InverseMass != 0)
                ResolveEntity(entityB, contacts);
            else
                ResolveEntities(entityA, entityB, contacts);
        }

        public void ResolveEntity(IPhysicsEntity entity, List<ContactPoint2D> contacts) {
            Vector2 impulse = CalculateSingleEntityImpulse(entity.body, contacts);
            entity.body.Velocity += impulse;
            SeparateSingleEntity(entity, contacts);
        }

        public Vector2 CalculateSingleEntityImpulse(Body body, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            double restitution = body.Restitution;
            if (EvaluateVelocityThreshold(body.Velocity))
                restitution = 0;
            foreach (var contact in contacts) {
                Vector2 normal = contact.Normal;
                double relativeVelocityAlongNormal = Vector2.Dot(body.Velocity, normal);
                if (relativeVelocityAlongNormal < 0) {
                    Vector2 impulse = -(1 + restitution) * relativeVelocityAlongNormal * normal;
                    totalImpulse += impulse;
                }
            }
            return totalImpulse;
        }

        public void SeparateSingleEntity(IPhysicsEntity physicsEntity, List<ContactPoint2D> contacts) {
            Vector2 maxSeparation = Vector2.Zero;
            double maxPenetration = 0;
            foreach (var contact in contacts) {
                if (contact.Separation > maxPenetration) {
                    maxPenetration = contact.Separation;
                    maxSeparation = contact.Normal * contact.Separation * PhysicsSettings.DefaultContactOffset;
                }
            }
            physicsEntity.transform.position += maxSeparation;
        }

        public void ResolveEntities(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            Vector2 twoBodyImpulse = CalculateBodiesImpulse(entityA.body, entityB.body, contacts);
            entityA.body.Velocity -= twoBodyImpulse / entityA.body.Mass;
            entityB.body.Velocity += twoBodyImpulse / entityB.body.Mass;
            SeparateBodies(entityA, entityB, contacts);
        }

        public Vector2 CalculateBodiesImpulse(Body bodyA, Body bodyB, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            Vector2 relativeVelocity = bodyB.Velocity - bodyA.Velocity;
            double restitution = Math.Min(bodyA.Restitution, bodyB.Restitution);
            double massOverSum = 1 / bodyA.Mass + 1 / bodyB.Mass;
            if (EvaluateVelocityThreshold(relativeVelocity))
                restitution = 0;
            foreach (var contact in contacts) {
                double relativeVelocityAlongNormal = Vector2.Dot(relativeVelocity, contact.Normal);
                if (relativeVelocityAlongNormal < 0)
                    totalImpulse += -(1 + restitution) * relativeVelocityAlongNormal * contact.Normal / massOverSum;
            }
            return totalImpulse;
        }

        public void SeparateBodies(IPhysicsEntity physicsEntityA, IPhysicsEntity physicsEntityB, List<ContactPoint2D> contacts) {
            Vector2 maxSeparation = Vector2.Zero;
            double maxPenetration = 0;
            foreach (var contact in contacts) {
                if (contact.Separation > maxPenetration) {
                    maxPenetration = contact.Separation;
                    maxSeparation = contact.Normal * contact.Separation * PhysicsSettings.DefaultContactOffset;
                }
            }
            double totalMass = physicsEntityA.body.Mass + physicsEntityB.body.Mass;
            double massProportionA = physicsEntityA.body.Mass / totalMass;
            double massProportionB = physicsEntityB.body.Mass / totalMass;
            Vector2 separationA = massProportionB * maxSeparation;
            Vector2 separationB = massProportionA * maxSeparation;
            physicsEntityA.transform.position -= separationA;
            physicsEntityB.transform.position += separationB;
        }

        bool EvaluateVelocityThreshold(Vector2 velocity) {
            if (Math.Abs(velocity.x) < PhysicsSettings.VelocityThreshold && Math.Abs(velocity.y) < PhysicsSettings.VelocityThreshold)
                return true;
            return false;
        }

        public void SendCollisionMessages(Collision2D contact) {
            contact.ColliderA.attachedEntity.OnCollisionEnter2D(contact);
            contact.ColliderB.attachedEntity.OnCollisionEnter2D(contact);
        }
    }
}