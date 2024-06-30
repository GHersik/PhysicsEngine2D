using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine2D {
    public class Entity : IPhysicsEntity {

        public IRenderer renderer { get; protected set; }

        public Transform transform { get; protected set; }

        public Body body { get; protected set; }

        public Collider2D collider { get; protected set; }

        public Entity() {
            this.renderer = new Circle2D();
            this.transform = new Transform();
            this.body = new Body();
            this.collider = new CircleCollider2D(this);
        }

        public void DrawEntity() => renderer.Draw(transform.position);

        public virtual void FixedUpdate() { }

        public virtual void Update() { }

        public virtual void OnCollisionEnter2D(Collision2D collision) { }

        public virtual void OnCollisionExit2D(Collision2D collision) { }

        public virtual void OnCollisionStay2D(Collision2D collision) { }

        public virtual void OnTriggerEnter2D() { }

        public virtual void OnTriggerExit2D() { }

        public virtual void OnTriggerStay2D() { }
    }
}
