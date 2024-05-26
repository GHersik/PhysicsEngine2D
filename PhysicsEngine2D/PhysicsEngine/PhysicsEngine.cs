using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicsLibrary;

namespace Physics2D {
    public class PhysicsEngine {

        private EulerIntegrator integrator;
        private CollisionSolver collisionSolver;
        private World world;

        public PhysicsEngine(World world) {
            integrator = new EulerIntegrator();
            collisionSolver = new CollisionSolver();
            this.world = world;
        }

        public void FixedUpdate() {
            foreach (var body in world.bodies) {
                body.AddForce(PhysicsSettings.Gravity);
                integrator.Integrate(body);
            }


            //solve motions
            //detect collisions
            //solve collisions
        }
    }
}
