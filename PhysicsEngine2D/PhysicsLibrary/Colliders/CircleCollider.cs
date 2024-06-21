using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class CircleCollider : Collider {

        public double Radius { get; private set; }

        public CircleCollider(double radius) {
            Radius = radius;
        }

        public override Vector2 FindFurthestPoint(Vector2 direction) {
            throw new NotImplementedException();
        }
    }
}
