using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsLibrary {
    public class Transform {

        public Vector2 position;
        public Vector2 PreviousPosition { get; set; }

        public Transform(Vector2 position) {
            this.position = position;
        }

        public Transform() : this(Vector2.Zero) { }
    }
}
