using System.Collections.ObjectModel;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsEngine {

        public PhysicsWorld PhysicsWorld { get; private set; }
        public BodyForceRegistry ForceRegistry { get; private set; }

        EulerIntegrator eulerIntegrator;
        CollisionDetector collisionDetector;
        ContactResolver contactResolver;

        public PhysicsEngine() {
            eulerIntegrator = new EulerIntegrator();
            collisionDetector = new CollisionDetector();
            contactResolver = new ContactResolver();
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
        }

        public PhysicsEngine(Collection<IPhysicsEntity> physicsObjects) {
            eulerIntegrator = new EulerIntegrator();
            collisionDetector = new CollisionDetector();
            contactResolver = new ContactResolver();
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
            PhysicsWorld.ReplaceRegistry(physicsObjects);
        }

        public void FixedUpdate() {
            foreach (var physicsEntity in PhysicsWorld) {
                physicsEntity.body.AddForce(PhysicsSettings.Gravity, ForceMode.Acceleration);
                ForceRegistry.UpdateForces();
                eulerIntegrator.Integrate(physicsEntity);
            }

            List<Collision2D> collisions = collisionDetector.DetectCollisions(PhysicsWorld.GetPhysicsEntityArray());
            contactResolver.ResolveContacts(collisions);
        }
    }
}
