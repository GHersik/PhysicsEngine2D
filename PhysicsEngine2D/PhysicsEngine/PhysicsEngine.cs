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


        private EulerIntegrator eulerIntegrator;
        private ContactResolver contactResolver;

        public PhysicsEngine() {
            PhysicsWorld = new PhysicsWorld();
            ForceRegistry = new BodyForceRegistry();
            eulerIntegrator = new EulerIntegrator();
            contactResolver = new ContactResolver();
        }

        public PhysicsEngine(Collection<IPhysicsEntity> physicsObjects) {
            eulerIntegrator = new EulerIntegrator();
            ForceRegistry = new BodyForceRegistry();
            contactResolver = new ContactResolver();
            PhysicsWorld = new PhysicsWorld();
            PhysicsWorld.ReplaceRegistry(physicsObjects);
        }

        public void FixedUpdate() {
            foreach (var physicsEntity in PhysicsWorld) {
                physicsEntity.Body.AddForce(PhysicsSettings.Gravity);
                ForceRegistry.UpdateForces();
                eulerIntegrator.Integrate(physicsEntity);
                
            }


            //solve motions
            //detect collisions // callcollisionmethods
            //solve collisions
        }
    }
}
