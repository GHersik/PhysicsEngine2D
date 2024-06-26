using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public struct ContactPoint2D {

        //public Collider2D ColliderA { get; private set; }
        //public Collider2D? ColliderB { get; private set; }
        public Vector2 Point { get; private set; }
        public Vector2 Normal { get; private set; }
        public double Separation { get; private set; }

        public ContactPoint2D(Vector2 point, double separation, Vector2 normal) {
            //this.ColliderA = colliderA;
            //this.ColliderB = colliderB;
            this.Point = point;
            this.Separation = separation;
            this.Normal = normal;
        }

        //public ContactPoint2D(Collider2D colliderOne) : this(colliderOne, null) { }


        //private 
    }
}
