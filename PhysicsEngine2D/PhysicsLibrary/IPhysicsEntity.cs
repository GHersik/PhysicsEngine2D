

namespace PhysicsLibrary {
    public interface IPhysicsEntity {

        public Transform Transform { get; }

        public Body Body { get; }

        public Collider2D Collider { get; }

        public abstract void OnCollisionEnter2D(Collision2D collision);

        public abstract void OnCollisionExit2D(Collision2D collision);

        public abstract void OnCollisionStay2D(Collision2D collision);

        public abstract void OnTriggerEnter2D();

        public abstract void OnTriggerExit2D();

        public abstract void OnTriggerStay2D();

    }
}
