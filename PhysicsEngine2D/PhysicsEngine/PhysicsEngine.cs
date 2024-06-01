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

        private EulerIntegrator eulerIntegrator;
        private CollisionSolver collisionSolver;
        private PhysicsWorld physicsWorld;

        public PhysicsEngine() {
            eulerIntegrator = new EulerIntegrator();
            collisionSolver = new CollisionSolver();
            physicsWorld = new PhysicsWorld();
        }

        public PhysicsEngine(Collection<Body> physicsObjects) {
            eulerIntegrator = new EulerIntegrator();
            collisionSolver = new CollisionSolver();
            physicsWorld = new PhysicsWorld();
            physicsWorld.ReplaceRegistry(physicsObjects);
        }

        public void ReplacePhysicsRegistry(Collection<Body> physicsObjects) => physicsWorld.ReplaceRegistry(physicsObjects);

        public bool AddObject(Body body) => physicsWorld.AddBody(body);

        public bool RemoveObject(Body body) => physicsWorld.RemoveBody(body);

        public bool Contains(Body body) => physicsWorld.Contains(body);

        public void Clear() => physicsWorld.Clear();

        public void FixedUpdate() {
            foreach (var body in physicsWorld) {
                body.AddForce(PhysicsSettings.Gravity);
                eulerIntegrator.Integrate(body);
            }


            //solve motions
            //detect collisions // callcollisionmethods
            //solve collisions
        }
    }
}
