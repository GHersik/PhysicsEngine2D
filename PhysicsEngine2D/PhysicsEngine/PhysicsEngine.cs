using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics2D {
    public class PhysicsEngine {

        public PhysicsSettings PhysicsSettings { get; private set; }

        private EulerIntegrator integrator;
        private CollisionSolver collisionSolver;
        private World world;

        public PhysicsEngine(PhysicsSettings physicsSettings) {
            PhysicsSettings = physicsSettings;
            integrator = new EulerIntegrator(PhysicsSettings);
            collisionSolver = new CollisionSolver();
            world = new World();
        }



        public void FixedUpdate() {
            foreach (var body in world.bodies)
                integrator.Integrate(body);
            
            //solve motions
            //detect collisions
            //solve collisions
        }
    }
}
