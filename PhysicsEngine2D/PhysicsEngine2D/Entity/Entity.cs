using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine2D {
    public class Entity {

        public Body Body { get; protected set; }

        public IRenderer Renderer { get; private set; }

        public Entity(IRenderer renderer) {
            Renderer = renderer;
            Body = new Body();
        }

        public void DrawEntity() => Renderer.Draw(Body.position);

        public virtual void FixedUpdate() { }

        public virtual void Update() { }

        public virtual void OnTriggerEnter2D() { }

        public virtual void OnTriggerExit2D() { }

    }
}
