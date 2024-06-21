using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary.Colliders {
    public class ContactPoint2D {

        private Collider colliderOne;
        private Collider? colliderTwo;

        private double restitution;
        private Vector2 contactNormal;

        protected void Resolve(double duration) {

        }

        //private 
    }
}
