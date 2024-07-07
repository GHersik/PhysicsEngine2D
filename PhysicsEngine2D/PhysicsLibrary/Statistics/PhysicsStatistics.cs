
namespace PhysicsLibrary {
    public static class PhysicsStatistics {

        public static int PhysicsEntities { get; set; } = 0;
        public static int TotalFixedSteps { get; set; } = 0;
        public static int TotalCollisions { get; set; } = 0;
        public static int CollisionsThisStep { get; set; } = 0;
        public static double AverageCollisionsPerStep { get; set; } = 0;

        public static void ResetStatistics() {
            PhysicsEntities = 0;
            TotalFixedSteps = 0;
            TotalCollisions = 0;
            CollisionsThisStep = 0;
            AverageCollisionsPerStep = 0;
        }
    }
}
