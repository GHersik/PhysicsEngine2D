using System.Collections.ObjectModel;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsEngine {

        public PhysicsWorld PhysicsWorld { get; private set; }
        public BodyForceRegistry ForceRegistry { get; private set; }

<<<<<<< HEAD
        readonly EulerIntegrator eulerIntegrator;
        readonly ContactResolver contactResolver;

        public PhysicsEngine() {
            eulerIntegrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
=======
        IIntegrator integrator;
        CollisionDetector collisionDetector;
        ContactResolver contactResolver;

        public PhysicsEngine() {
>>>>>>> development
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
            integrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
            collisionDetector = new CollisionDetector();
        }

        public PhysicsEngine(Collection<IPhysicsEntity> physicsObjects) {
<<<<<<< HEAD
            eulerIntegrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
=======
>>>>>>> development
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
            PhysicsWorld.ReplaceRegistry(physicsObjects);
            integrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
            collisionDetector = new CollisionDetector();
        }

        public void FixedUpdate() {
            foreach (var physicsEntity in PhysicsWorld) {
                physicsEntity.Body.AddForce(PhysicsSettings.Gravity, ForceMode.Acceleration);
                ForceRegistry.UpdateForces();
                integrator.Integrate(physicsEntity);
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
