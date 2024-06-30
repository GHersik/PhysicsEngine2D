using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public abstract class Collider2D {

        public Collider2DType type { get; protected set; }

        public IPhysicsEntity attachedEntity { get; protected set; }

        public abstract Vector2 ClosestPoint(Vector2 point);

    }
}
