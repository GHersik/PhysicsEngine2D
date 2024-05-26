using Physics2D;
using PhysicsEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationWindow {
    public class Renderer {

        private Circle2D[] circles;

        public Renderer(Circle2D[] circles) {
            this.circles = circles;
        }

        public void Render() {
            foreach (var circle in circles)
                circle.Draw();
        }
    }
}
