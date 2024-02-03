namespace PhysicsLibrary {
    public partial struct Vector2 {

        public static readonly Vector2 One = new Vector2(1, 1);
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 Left = new Vector2(-1, 0);
        public static readonly Vector2 Right = new Vector2(1, 0);
        public static readonly Vector2 Up = new Vector2(0, 1);
        public static readonly Vector2 Down = new Vector2(0, -1);

        public static double Dot(Vector2 a, Vector2 b) => (a.x * b.x) + (a.y * b.y);
        public static double Distance(Vector2 a, Vector2 b) {
            double deltaX = a.x - b.x;
            double deltaY = a.y - b.y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 vectorToMultiply, double scalar) => new Vector2(vectorToMultiply.x * scalar, vectorToMultiply.y * scalar);
        public static Vector2 operator /(Vector2 vectorToDivide, double scalar) => new Vector2(vectorToDivide.x / scalar, vectorToDivide.y / scalar);
    }
}