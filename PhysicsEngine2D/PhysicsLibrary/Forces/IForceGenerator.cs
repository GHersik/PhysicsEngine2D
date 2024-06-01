
namespace PhysicsLibrary {
    public interface IForceGenerator {
        public abstract void UpdateForce(Body body, double duration = 0);
    }
}
