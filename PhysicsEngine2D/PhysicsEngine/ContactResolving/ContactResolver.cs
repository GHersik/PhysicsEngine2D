using PhysicsLibrary;

namespace Physics {
    internal class ContactResolver {

        public void ResolveContacts(List<Collision2D> collisions) {
            foreach (var collision in collisions) {
                if (collision.ContactCount < 1)
                    continue;

                List<ContactPoint2D> contacts = RetrieveContacts(collision);
                Resolve(collision.ColliderA.AttachedEntity, collision.ColliderB.AttachedEntity, contacts);
                SendCollisionMessages(collision);
            }
        }

        List<ContactPoint2D> RetrieveContacts(Collision2D collision) {
            List<ContactPoint2D> contacts = new();
            collision.GetContacts(contacts);
            return contacts;
        }

        void Resolve(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            if (entityA.Body.InverseMass == 0 && entityB.Body.InverseMass == 0)
                return;
            else if (entityB.Body.InverseMass == 0 && entityA.Body.InverseMass != 0)
                ResolveEntity(entityA, contacts);
            else if (entityA.Body.InverseMass == 0 && entityB.Body.InverseMass != 0)
                ResolveEntity(entityB, contacts);
            else
                ResolveEntities(entityA, entityB, contacts);
        }

        void ResolveEntity(IPhysicsEntity entity, List<ContactPoint2D> contacts) {
            Vector2 impulse = CalculateSingleEntityImpulse(entity.Body, contacts);
            entity.Body.AddForce(impulse, ForceMode.VelocityChange);
            SeparateSingleEntity(entity, contacts);
        }

        Vector2 CalculateSingleEntityImpulse(Body body, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            double restitution = body.Restitution;
            if (EvaluateVelocityThreshold(body.Velocity)) {
                restitution = 0;
                body.AddForce(-body.TotalForce, ForceMode.Acceleration);
            }
            foreach (var contact in contacts) {
                double relativeVelocityAlongNormal = Vector2.Dot(body.Velocity, contact.Normal);
                if (relativeVelocityAlongNormal < 0) {
                    Vector2 impulse = -(1 + restitution) * relativeVelocityAlongNormal * contact.Normal;
                    totalImpulse += impulse;
                }
            }
            return totalImpulse;
        }

        void SeparateSingleEntity(IPhysicsEntity entity, List<ContactPoint2D> contacts) {
            Vector2 correction = CalculateSeparationCorrection(contacts);
            entity.Transform.position += correction;
        }

        void ResolveEntities(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            Vector2 twoBodyImpulse = CalculateBodiesImpulse(entityA.Body, entityB.Body, contacts);
            entityA.Body.AddForce(-twoBodyImpulse, ForceMode.Impulse);
            entityB.Body.AddForce(twoBodyImpulse, ForceMode.Impulse);
            SeparateBodies(entityA, entityB, contacts);
        }

        Vector2 CalculateBodiesImpulse(Body bodyA, Body bodyB, List<ContactPoint2D> contacts) {
            Vector2 totalImpulse = Vector2.Zero;
            Vector2 relativeVelocity = bodyB.Velocity - bodyA.Velocity;
            double restitution = Math.Min(bodyA.Restitution, bodyB.Restitution);
            double massOverSum = 1 / bodyA.Mass + 1 / bodyB.Mass;
            if (EvaluateVelocityThreshold(relativeVelocity)) {
                restitution = 0;
                bodyA.AddForce(-bodyA.TotalForce, ForceMode.Acceleration);
                bodyB.AddForce(-bodyB.TotalForce, ForceMode.Acceleration);
            }
            foreach (var contact in contacts) {
                double relativeVelocityAlongNormal = Vector2.Dot(relativeVelocity, contact.Normal);
                if (relativeVelocityAlongNormal < 0)
                    totalImpulse += -(1 + restitution) * relativeVelocityAlongNormal * contact.Normal / massOverSum;
            }
            return totalImpulse;
        }

        void SeparateBodies(IPhysicsEntity entityA, IPhysicsEntity entityB, List<ContactPoint2D> contacts) {
            Vector2 correction = CalculateSeparationCorrection(contacts);
            double totalMass = entityA.Body.Mass + entityB.Body.Mass;
            double massProportionA = entityA.Body.Mass / totalMass;
            double massProportionB = entityB.Body.Mass / totalMass;
            Vector2 separationA = massProportionB * correction;
            Vector2 separationB = massProportionA * correction;
            entityA.Transform.position -= separationA;
            entityB.Transform.position += separationB;
        }

        Vector2 CalculateSeparationCorrection(List<ContactPoint2D> contacts) {
            Vector2 maxSeparation = Vector2.Zero;
            double maxPenetration = double.MaxValue;
            foreach (var contact in contacts) {
                if (contact.Separation < maxPenetration) {
                    maxPenetration = contact.Separation;
                    maxSeparation = contact.Normal * (contact.Separation + PhysicsSettings.DefaultContactOffset);
                }
            }
            return maxSeparation;
        }

        bool EvaluateVelocityThreshold(Vector2 velocity) {
            if (Math.Abs(velocity.x * PhysicsSettings.FixedTimeStep) < PhysicsSettings.VelocityThreshold && Math.Abs(velocity.y * PhysicsSettings.FixedTimeStep) < PhysicsSettings.VelocityThreshold)
                return true;
            return false;
        }

        void SendCollisionMessages(Collision2D contact) {
            contact.ColliderA.AttachedEntity.OnCollisionEnter2D(contact);
            contact.ColliderB.AttachedEntity.OnCollisionEnter2D(contact);
        }
    }
}