
namespace PhysicsLibrary {
    public interface IPhysicsEntity {

        public Transform Transform { get; }

        public Body Body { get; }

        public Collider Collider { get; }

        public abstract void OnCollisionEnter2D();

        public abstract void OnCollisionExit2D();

        public abstract void OnCollisionStay2D();

        public abstract void OnTriggerEnter2D();

        public abstract void OnTriggerExit2D();

        public abstract void OnTriggerStay2D();

    }
}
