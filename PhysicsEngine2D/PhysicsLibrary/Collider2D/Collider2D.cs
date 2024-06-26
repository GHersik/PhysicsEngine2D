using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public abstract class Collider2D {

        public Collider2DType ColliderType { get; protected set; }

        public IPhysicsEntity PhysicsEntityAttached { get; protected set; }

        //public abstract Vector2 FindFurthestPoint(Vector2 direction);

    }
}
