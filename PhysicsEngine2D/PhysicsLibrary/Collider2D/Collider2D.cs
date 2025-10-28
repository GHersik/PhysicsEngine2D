
namespace PhysicsLibrary {
    public abstract class Collider2D {

        public Collider2DType Type { get; protected set; }

<<<<<<< HEAD
        public IPhysicsEntity AttachedEntity { get; protected set; }
=======
        public IPhysicsEntity? AttachedEntity { get; protected set; }
>>>>>>> development

        public abstract Vector2 ClosestPoint(Vector2 point);

    }
}
