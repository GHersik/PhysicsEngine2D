using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class CircleCollider2D : Collider2D {

        public double Radius { get; private set; }

        public CircleCollider2D(IPhysicsEntity physicsEntity, double radius) {
            Radius = radius;
            ColliderType = Collider2DType.Circle;
            PhysicsEntityAttached = physicsEntity;
        }

        public CircleCollider2D(IPhysicsEntity physicsEntity) : this(physicsEntity, 3) { }

        //public override Vector2 FindFurthestPoint(Vector2 direction) {
        //    throw new NotImplementedException();
        //}
    }
}
