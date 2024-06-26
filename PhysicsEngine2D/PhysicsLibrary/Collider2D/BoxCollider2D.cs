using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class BoxCollider2D : Collider2D {

        public Vector2 MinPoint { get; private set; }
        public Vector2 MaxPoint { get; private set; }

        public BoxCollider2D(Vector2 minPoint, Vector2 maxPoint) {
            MinPoint = minPoint; 
            MaxPoint = maxPoint;
            ColliderType = Collider2DType.Box;
        }

        public BoxCollider2D(): this(new Vector2(-1,-1), new Vector2(1, 1)) { }

        //public override Vector2 FindFurthestPoint(Vector2 direction) {
        //    throw new NotImplementedException();
        //}
    }
}
