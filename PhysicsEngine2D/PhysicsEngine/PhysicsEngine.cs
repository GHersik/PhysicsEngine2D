using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics.Integrators;
using PhysicsLibrary;

namespace Physics {
    public class PhysicsEngine {

        public PhysicsWorld PhysicsWorld { get; private set; }
        public BodyForceRegistry ForceRegistry { get; private set; }

        EulerIntegrator eulerIntegrator;
        //VerletIntegrator verletIntegrator;
        CollisionDetector collisionDetector;
        ContactResolver contactResolver;

        public PhysicsEngine() {
            eulerIntegrator = new EulerIntegrator();
            //verletIntegrator = new VerletIntegrator();
            collisionDetector = new CollisionDetector();
            contactResolver = new ContactResolver();
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
        }

        public PhysicsEngine(Collection<IPhysicsEntity> physicsObjects) {
            eulerIntegrator = new EulerIntegrator();
            //verletIntegrator = new VerletIntegrator();
            collisionDetector = new CollisionDetector();
            contactResolver = new ContactResolver();
            ForceRegistry = new BodyForceRegistry();
            PhysicsWorld = new PhysicsWorld();
            PhysicsWorld.ReplaceRegistry(physicsObjects);
        }

        public void FixedUpdate() {
            foreach (var physicsEntity in PhysicsWorld) {
                physicsEntity.body.AddForce(PhysicsSettings.Gravity);
                //ForceRegistry.UpdateForces();
                eulerIntegrator.Integrate(physicsEntity);
                //verletIntegrator.Integrate(physicsEntity, PhysicsSettings.FixedTimeStep);
            }

            List<Collision2D> collisions = collisionDetector.DetectCollisions(PhysicsWorld.GetPhysicsEntityArray());
            contactResolver.ResolveContacts(collisions);
        }
    }
}
