
namespace PhysicsLibrary {
    public static class PhysicsSettings {

        public static readonly Vector2 EarthGravity = new(0, 9.81);

        public static Vector2 Gravity { get; private set; } = EarthGravity;

        public static double FixedTimeStep { get; private set; } = 0.03;

        public static void SetNewGravity(Vector2 gravity) => Gravity = gravity;

        public static void SetNewFixedTimeStep(double value) => FixedTimeStep = value;
    }
}
