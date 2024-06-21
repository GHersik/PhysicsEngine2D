using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine2D {
    public class Entity : IPhysicsEntity {

        public IRenderer Renderer { get; private set; }

        public Transform Transform { get; private set; }

        public Body Body { get; private set; }

        public Collider Collider { get; private set; }

        public Entity(IRenderer renderer, Collider collider, Transform transform) {
            Renderer = renderer;
            Collider = collider;
            Transform = transform;
            Body = new Body();
        }

        public void DrawEntity() => Renderer.Draw(Transform.position);

        public virtual void FixedUpdate() { }

        public virtual void Update() { }

        public virtual void OnTriggerEnter2D() { }

        public virtual void OnTriggerExit2D() { }

        public virtual void OnCollisionEnter2D() {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionExit2D() {
            throw new NotImplementedException();
        }

        public virtual void OnCollisionStay2D() {
            throw new NotImplementedException();
        }

        public virtual void OnTriggerStay2D() {
            throw new NotImplementedException();
        }
    }
}
