
namespace PhysicsLibrary {
    public static class PhysicsSettings {

        public static readonly Vector2 EarthGravity = new(0, 9.81);
        public static readonly Vector2 NoGravity = Vector2.Zero;

        public static double FixedTimeStep { get; private set; } = 0.02;
        public static Vector2 Gravity { get; private set; } = EarthGravity;
        public static double DefaultContactOffset { get; private set; } = 0.01;
        public static double VelocityThreshold { get; private set; } = 1;
        public static double LinearSleepTolerance { get; private set; } = 0.01;


        public static void SetFixedTimeStep(double value) => FixedTimeStep = Math.Clamp(value, 0.01, 0.1);
        public static void SetGravity(Vector2 gravity) => Gravity = gravity;
        public static void SetDefaultContactOffset(double value) => DefaultContactOffset = Math.Clamp(value, 0, 8);
        public static void SetVelocityThreshold(double value) => VelocityThreshold = Math.Clamp(value, 0, 8);
        public static void SetSleepTolerance(double value) => LinearSleepTolerance = Math.Clamp(value, 0, 8);

    }
}
