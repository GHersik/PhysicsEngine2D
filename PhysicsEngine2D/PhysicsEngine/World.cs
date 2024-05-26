using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics2D {
    public class World {

        public HashSet<Body> bodies = new HashSet<Body>();

        public void NewWorld() {
            bodies.Clear();

        }

        public void AddBody(Body body) {
            bodies.Add(body);
        }

    }
}
