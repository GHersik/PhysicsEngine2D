using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationWindow {
    public class Entity : IPhysicsEntity {

        public IRenderer Renderer { get; protected set; }

        public Transform Transform { get; protected set; }

        public Body Body { get; protected set; }

        public Collider2D Collider { get; protected set; }

        public Entity() {
            this.Renderer = new Circle2D();
            this.Transform = new Transform();
            this.Body = new Body();
            this.Collider = new CircleCollider2D(this);
        }

        public void DrawEntity() => Renderer.Draw(Transform.position);

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
