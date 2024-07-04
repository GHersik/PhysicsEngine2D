using System.Collections.ObjectModel;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsEngine {

        public PhysicsWorld PhysicsWorld { get; private set; }
        public BodyForceRegistry ForceRegistry { get; private set; }

        readonly EulerIntegrator eulerIntegrator;
        readonly CollisionDetector collisionDetector;
        readonly ContactResolver contactResolver;

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
                physicsEntity.Body.AddForce(PhysicsSettings.Gravity, ForceMode.Acceleration);
                ForceRegistry.UpdateForces();
                eulerIntegrator.Integrate(physicsEntity);
            }

            List<Collision2D> collisions = CollisionDetector.DetectCollisions(PhysicsWorld.GetPhysicsEntityArray());
            contactResolver.ResolveContacts(collisions);
        }
    }
}
