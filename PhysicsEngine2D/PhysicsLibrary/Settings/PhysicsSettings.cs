
namespace PhysicsLibrary {
    public static class PhysicsSettings {

        public static readonly Vector2 EarthGravity = new(0, 9.81);
        public static readonly Vector2 NoGravity = Vector2.Zero;
        public static readonly double DefaultContactOffset = 0;
        public static readonly double VelocityThreshold = 1;
        public static readonly double LinearSleepTolerance = .01;

        public static Vector2 Gravity { get; private set; } = EarthGravity;

        public static double FixedTimeStep { get; private set; } = 0.02;

        public static void SetNewGravity(Vector2 gravity) => Gravity = gravity;

        public static void SetNewFixedTimeStep(double value) => FixedTimeStep = value;
    }
}
