using PhysicsLibrary;

namespace Physics {
    internal class ContactResolver {

        public void ResolveContacts(List<Collision2D> collisions) {

            foreach (var contact in collisions) {
                contact.ColliderA.PhysicsEntityAttached.OnCollisionEnter2D(contact);
                contact.ColliderB?.PhysicsEntityAttached.OnCollisionEnter2D(contact);

                //double restitution = contact.ColliderA.PhysicsEntityAttached.body.restitution;
                //Vector2 relativeVelocity = contact.ColliderA.PhysicsEntityAttached.body.velocity;
                //double massOverOneSum = 0;
                //if (contact.ColliderB != null) {
                //    restitution = Math.Min(contact.ColliderA.PhysicsEntityAttached.body.restitution, contact.ColliderB.PhysicsEntityAttached.body.restitution);
                //    relativeVelocity = contact.ColliderB.PhysicsEntityAttached.body.velocity - contact.ColliderA.PhysicsEntityAttached.body.velocity;
                //    massOverOneSum = (1/contact.ColliderA.PhysicsEntityAttached.body.mass) + 1 / contact.ColliderB.PhysicsEntityAttached.body.mass);
                //}

                //List<ContactPoint2D> contacts = new();
                //contact.GetContacts(contacts);

                ////Vector2 impulse = -(1 + restitution) * relativeVelocity * contacts[0].Normal / massOverOneSum;
                //Vector2 impulse = -(1 + (double)restitution) * relativeVelocity * contacts[0].Normal / (double)massOverOneSum;


                double restitution = contact.ColliderA.PhysicsEntityAttached.body.restitution;
                Vector2 relativeVelocity = contact.ColliderA.PhysicsEntityAttached.body.velocity;
                double massOverOneSum = 1 / contact.ColliderA.PhysicsEntityAttached.body.mass;

                if (contact.ColliderB != null) {
                    restitution = Math.Min(contact.ColliderA.PhysicsEntityAttached.body.restitution, contact.ColliderB.PhysicsEntityAttached.body.restitution);
                    relativeVelocity = contact.ColliderB.PhysicsEntityAttached.body.velocity - contact.ColliderA.PhysicsEntityAttached.body.velocity;
                    massOverOneSum += 1 / contact.ColliderB.PhysicsEntityAttached.body.mass;
                }

                List<ContactPoint2D> contacts = new List<ContactPoint2D>();
                contact.GetContacts(contacts);

                if (contacts.Count == 0) {
                    //throw new InvalidOperationException("No contact points available.");
                    return;
                }

                Vector2 normal = contacts[0].Normal;
                double relativeVelocityAlongNormal = Vector2.Dot(relativeVelocity, normal);

                if (relativeVelocityAlongNormal > 0) {
                    // They are moving away from each other, no impulse needed
                    //return Vector2.Zero;
                    return;
                }

                Vector2 impulse = -(1 + (float)restitution) * relativeVelocityAlongNormal * normal / (float)massOverOneSum;

                ApplyImpulse(contact, impulse);
            }
        }

        public void ApplyImpulse(Collision2D contact, Vector2 impulse) {
            IPhysicsEntity entityA = contact.ColliderA.PhysicsEntityAttached;
            IPhysicsEntity entityB = contact.ColliderB?.PhysicsEntityAttached;

            // Apply impulse to Collider A
            entityA.body.velocity -= impulse / (float)entityA.body.mass;

            // Apply impulse to Collider B (if it exists)
            if (entityB != null) {
                entityB.body.velocity += impulse / (float)entityB.body.mass;
            }
        }

        //public void ResolveCollision(Contact contact) {
        //    Vector2 impulse = CalculateImpulse(contact);
        //    ApplyImpulse(contact, impulse);
        //}

    }
}