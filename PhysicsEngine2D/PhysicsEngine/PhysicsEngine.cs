using System.Collections.ObjectModel;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsEngine {

        public PhysicsWorld PhysicsWorld { get; private set; }
        public BodyForceRegistry ForceRegistry { get; private set; }

        readonly EulerIntegrator eulerIntegrator;
        readonly ContactResolver contactResolver;

        public PhysicsEngine() {
            eulerIntegrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
        }

        public PhysicsEngine(Collection<IPhysicsEntity> physicsObjects) {
            eulerIntegrator = new EulerIntegrator();
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

            PhysicsStatistics.PhysicsEntities = PhysicsWorld.Count;
            PhysicsStatistics.TotalFixedSteps += 1;
            PhysicsStatistics.CollisionsThisStep = collisions.Count;
            PhysicsStatistics.TotalCollisions += PhysicsStatistics.CollisionsThisStep;
            PhysicsStatistics.AverageCollisionsPerStep = (double)PhysicsStatistics.TotalCollisions / PhysicsStatistics.TotalFixedSteps;
        }
    }
}
