using Physics.CollisionDetection.Collisions;
using PhysicsLibrary;

namespace Physics {
    internal class ContactResolver {

        public void ResolveContacts(List<Collision2D> collisions) {
            foreach (var collision in collisions) {
                if (collision.ContactCount < 1)
                    continue;

                List<ContactPoint2D> contacts = RetrieveContacts(collision);
                Vector2 impulseApplied = Resolve(collision.ColliderA.attachedEntity, collision.ColliderB.attachedEntity, contacts);
                SendCollisionMessages(collision);
            }
        }

        public List<ContactPoint2D> RetrieveContacts(Collision2D collision) {
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            collision.GetContacts(contacts);
            return contacts;
        }

        public Vector2 Resolve(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            if (entityA.body.inverseMass == 0 && entityB.body.inverseMass == 0)
                return Vector2.Zero;
            else if (entityA.body.inverseMass == 0 && entityB.body.inverseMass != 0) {
                Vector2 impulse = CalculateSingleBodyImpulse(entityB.body, contacts);
                entityB.body.velocity -= impulse / entityB.body.mass;
                SeparateSingleEntity(entityB, contacts);
                return impulse;
            }
            else if (entityB.body.inverseMass == 0 && entityA.body.inverseMass != 0) {
                Vector2 impulse = CalculateSingleBodyImpulse(entityA.body, contacts);
                entityA.body.velocity += impulse / entityA.body.mass;
                SeparateSingleEntity(entityA, contacts);
                return impulse;
            }
            Vector2 twoBodyImpulse = CalculateBodiesImpulse(entityA.body, entityB.body, contacts);
            entityA.body.velocity -= twoBodyImpulse / entityA.body.mass;
            entityB.body.velocity += twoBodyImpulse / entityB.body.mass;
            SeparateBodies(entityA, entityB, contacts);
            return twoBodyImpulse;
        }

        public Vector2 CalculateSingleBodyImpulse(Body body, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            double massOverSum = 1 / body.mass;
            foreach (var contact in contacts) {
                Vector2 normal = contact.Normal;
                double relativeVelocityAlongNormal = Vector2.Dot(body.velocity, normal);
                if (relativeVelocityAlongNormal < 0) {
                    Vector2 impulse = -(1 + body.restitution) * relativeVelocityAlongNormal * normal / massOverSum;
                    totalImpulse += impulse;
                }
            }
            return totalImpulse;
        }

        public Vector2 CalculateBodiesImpulse(Body bodyA, Body bodyB, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            double restitution = Math.Min(bodyA.restitution, bodyB.restitution);
            double massOverSum = 1 / bodyA.mass + 1 / bodyB.mass;
            foreach (var contact in contacts) {
                Vector2 normal = contact.Normal;
                Vector2 relativeVelocity = bodyB.velocity - bodyA.velocity;
                double relativeVelocityAlongNormal = Vector2.Dot(relativeVelocity, normal);
                if (relativeVelocityAlongNormal < 0) {
                    Vector2 impulse = -(1 + restitution) * relativeVelocityAlongNormal * normal / massOverSum;
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

        public void SeparateBodies(IPhysicsEntity physicsEntityA, IPhysicsEntity physicsEntityB, List<ContactPoint2D> contacts) {
            Vector2 maxSeparation = Vector2.Zero;
            double maxPenetration = 0;
            foreach (var contact in contacts) {
                if (contact.Separation > maxPenetration) {
                    maxPenetration = contact.Separation;
                    maxSeparation = contact.Normal * contact.Separation * PhysicsSettings.DefaultContactOffset;
                }
            }
            double totalMass = physicsEntityA.body.mass + physicsEntityB.body.mass;
            double massProportionA = physicsEntityA.body.mass / totalMass;
            double massProportionB = physicsEntityB.body.mass / totalMass;
            Vector2 separationA = massProportionB * maxSeparation;
            Vector2 separationB = massProportionA * maxSeparation;
            physicsEntityA.transform.position -= separationA;
            physicsEntityB.transform.position += separationB;
        }

        public void SendCollisionMessages(Collision2D contact) {
            contact.ColliderA.attachedEntity.OnCollisionEnter2D(contact);
            contact.ColliderB?.attachedEntity.OnCollisionEnter2D(contact);
        }


        //public void ResolveCollision(Collision2D collision) {
        //    if (collision.ContactCount < 1)
        //        return;

        //    List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        //    collision.GetContacts(contacts);

        //    //Vector2 impulse = CalculateImpulse(collision);

        //    //Separate(collision);
        //    //ApplyImpulse(collision, impulse);
        //    //SendCollisionMessages(collision);
        //}


        //public Vector2 CalculateImpulse(Collision2D contact) {
        //    //List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        //    //contact.GetContacts(contacts);

        //    double restitution = contact.ColliderA.attachedEntity.body.restitution;
        //    Vector2 relativeVelocity = contact.ColliderA.attachedEntity.body.velocity;
        //    double massOverOneSum = 1 / contact.ColliderA.attachedEntity.body.mass;
        //    if (contact.ColliderB != null && contact.ColliderB.attachedEntity.body.inverseMass != 0) {
        //        restitution = Math.Min(contact.ColliderA.attachedEntity.body.restitution, contact.ColliderB.attachedEntity.body.restitution);
        //        relativeVelocity = contact.ColliderB.attachedEntity.body.velocity - contact.ColliderA.attachedEntity.body.velocity;
        //        massOverOneSum += 1 / contact.ColliderB.attachedEntity.body.mass;
        //    }



        //    Vector2 normal = contacts[0].Normal;
        //    double relativeVelocityAlongNormal = Vector2.Dot(relativeVelocity, normal);
        //    if (relativeVelocityAlongNormal > 0)
        //        return Vector2.Zero;

        //    Vector2 impulse = -(1 + (float)restitution) * relativeVelocityAlongNormal * normal / (float)massOverOneSum;
        //    return impulse;
        //}

        //public void ApplyImpulse(Collision2D contact, Vector2 impulse) {
        //    if (impulse == Vector2.Zero)
        //        return;

        //    IPhysicsEntity entityA = contact.ColliderA.attachedEntity;
        //    IPhysicsEntity entityB = contact.ColliderB?.attachedEntity;
        //    entityA.body.velocity -= impulse / entityA.body.mass;
        //    if (entityB != null && entityB.body.inverseMass != 0)
        //        entityB.body.velocity += impulse / entityB.body.mass;
        //}



        //public void ResolveCollision(Contact contact) {
        //    Vector2 impulse = CalculateImpulse(contact);
        //    ApplyImpulse(contact, impulse);
        //}
    }
}